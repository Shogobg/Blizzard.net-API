/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WOWSharp.Community.ObjectModel;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;
using System.Reflection;

namespace WOWSharp.Community
{
    /// <summary>
    /// A Blizzard's WOW community API client
    /// </summary>
    // The additional method overloads not available in Silverlight
    public partial class ApiClient
    {
        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="apiKey">Application key used to authenticate requests sent by the ApiClient</param>
        public ApiClient(ApiKeyPair apiKey)
            : this((Region)null, apiKey, null, null)
        {

        }

        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        /// <param name="apiKey">Application key used to authenticate requests sent by the ApiClient</param>
        /// <param name="locale">The locale to use to perform request (item names, class names, etc are retrieved in the locale specified)</param>
        /// <remarks>
        /// Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        public ApiClient(string region, ApiKeyPair apiKey, string locale)
            : this(Region.GetRegion(region), apiKey, locale, null)
        {

        }

        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        /// <param name="apiKey">Application key used to authenticate requests sent by the ApiClient</param>
        /// <param name="locale">The locale to use to perform request (item names, class names, etc are retrieved in the locale specified)</param>
        /// <param name="cacheManager">Cache manager to cache data</param>
        /// <remarks>
        /// Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        public ApiClient(string region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager)
            : this(Region.GetRegion(region), apiKey, locale, cacheManager)
        {

        }

        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        /// <param name="apiKey">Application key used to authenticate requests sent by the ApiClient</param>
        /// <param name="locale">The locale to use to perform request (item names, class names, etc are retrieved in the locale specified)</param>
        /// <param name="cacheManager">Cache manager to cache data</param>
        /// <remarks>
        /// Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        public ApiClient(Region region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager) : this(region, locale, cacheManager)
        {
            this._apiKey = apiKey;
        }

        /// <summary>
        /// The API key used to authenticate the request
        /// </summary>
        private readonly ApiKeyPair _apiKey;

        /// <summary>
        /// Get character profile information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <param name="fieldsToRetrieve">the profile fields to retrieve</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetCharacter(string realm, string characterName, AsyncCallback callback, object asyncState)
        {
            return BeginGetCharacter(realm, characterName, CharacterField.None, callback, asyncState);
        }

        /// <summary>
        /// Get character profile information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <param name="getAllFields">whether to get all optional profile fields</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetCharacter(string realm, string characterName, bool getAllFields, AsyncCallback callback, object asyncState)
        {
            return BeginGetCharacter(realm, characterName, getAllFields ? CharacterField.None : CharacterField.All, callback, asyncState);
        }

        /// <summary>
        /// Gets guild information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetGuild(string realm, string guildName, AsyncCallback callback, object asyncState)
        {
            return BeginGetGuild(realm, guildName, GuildField.None, callback, asyncState);
        }

        /// <summary>
        /// Gets guild information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <param name="getAllFields">Whether to get all fields</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetGuild(string realm, string guildName, bool getAllFields, AsyncCallback callback, object asyncState)
        {
            return BeginGetGuild(realm, guildName, getAllFields ? GuildField.All : GuildField.None, callback, asyncState);
        }

        /// <summary>
        /// Creates a GET request
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>the HTTP request object</returns>
        protected virtual HttpWebRequest CreateGetRequest(string url)
        {
            // Blizzard recommends that SSL is used when authenticating using the API key
            Uri uri = new Uri((this._apiKey == null ? "http://" : "https://")
                + Region.HostUrl + url);
            if (!string.IsNullOrEmpty(uri.Query))
            {
                uri = new Uri(uri.ToString() + "&locale=" + this.Locale.Replace('-', '_'));
            }
            else
            {
                uri = new Uri(uri.ToString() + "?locale=" + this.Locale.Replace('-', '_'));
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            SetAuthenticationHeader(request, this._apiKey);
            return request;
        }

        /// <summary>
        /// Sets the request authentication header
        /// </summary>
        /// <param name="request">request</param>
        public static void SetAuthenticationHeader(HttpWebRequest request, ApiKeyPair apiKey)
        {
            if (apiKey != null)
            {
                DateTime date = DateTime.Now.ToUniversalTime();
                string dateString = date.ToString("r", CultureInfo.InvariantCulture);

                if (Environment.Version.Major >= 4)
                {
                    // In .NET 4 This property is public so it doesn't require any security permissions
                    // Setting the property with reflection to we are still 3.5 compatible
                    PropertyInfo property = typeof(HttpWebRequest).GetProperty("Date");
                    property.SetValue(request, date, null);
                }
                else
                {
                    // API authentication requires FULL trust in .NET framework 3.5
                    // or at least ReflectionPermission with MemberAccess
                    // The other alternative is implementing the entire HttpWebRequest class using sockets or TcpClient
                    MethodInfo setHeadersMethod = typeof(HttpWebRequest).GetMethod("SetSpecialHeaders",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                    try
                    {
                        setHeadersMethod.Invoke(request, new object[] { "Date", dateString });
                    }
                    catch (MethodAccessException)
                    {
                        // if ignore on partial trust is set, we ignore the key and perform the request without authorization
                        if (apiKey.IgnoreOnPartialTrust)
                            return;
                        else
                            throw;
                    }
                }


                string stringToSign = request.Method + "\n" + dateString
                    + "\n" + request.RequestUri.AbsolutePath + "\n";
                using (HMACSHA1 hashAlgorithm = new HMACSHA1(apiKey.PrivateKey))
                {
                    string signature = Convert.ToBase64String(
                        hashAlgorithm.ComputeHash(
                        Encoding.UTF8.GetBytes(stringToSign)));
                    request.Headers.Add(HttpRequestHeader.Authorization, "BNET " + apiKey.PublicKey + ":" + signature);
                }
            }
        }
    }
}
