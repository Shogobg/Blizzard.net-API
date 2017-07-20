﻿// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Security;

namespace WOWSharp.Community
{
    /// <summary>
    ///   A Blizzard's battle.net community API client
    /// </summary>
    public abstract class ApiClient
    {
        private const string RegionNameHttpHeader = "X-WOWSharpProxy-Region";
        private const string ApiUrlHttpHeader = "X-WOWSharpProxy-Url";
        private const string LocaleHttpHeader = "X-WOWSharpProxy-Locale";
        private static Uri _proxyUri;

        /// <summary>
        /// Causes the API to throw serialization exceptions when 
        /// the JSON returned by Blizzard's API contains a property 
        /// not found in the class being deserialized. 
        /// This is useful to detect changes by Blizzard API since they have the habit of changing 
        /// things without announcing it. 
        /// This property is set to true by unit tests
        /// </summary>
        public static bool TestMode
        {
            get;
            set;
        }

        /// <summary>
        ///   Authentication support
        /// </summary>
        private static readonly AuthenticationSupport _authenticationSupport = InitializeAuthenticationSupport();

        /// <summary>
        ///   Reference date for Unix time
        /// </summary>
        private static readonly DateTime _unixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///   The API key used to authenticate the request
        /// </summary>
        private readonly ApiKeyPair _apiKey;

        /// <summary>
        ///   An object that implements _cacheManager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        /// <summary>
        ///   Gets the locale which is used to get item names
        /// </summary>
        private string _locale;

        /// <summary>
        ///   Gets the region to which this ApiClient connects
        /// </summary>
        private Region _region;

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <remarks>
        ///   The default constructor will use the default region and locale determined by the current thread's culture.
        /// </remarks>
        protected ApiClient()
            : this((Region) null, null, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        protected ApiClient(Region region)
            : this(region, null, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        protected ApiClient(Region region, string locale)
            : this(region, locale, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        /// <param name="cacheManager"> Cache manager to cache data </param>
        protected ApiClient(Region region, string locale, ICacheManager cacheManager)
        {
            if (region == null)
                region = Region.Default;
            Region = region;
            Locale = Region.GetSupportedLocale(locale);
            _cacheManager = cacheManager;
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        protected ApiClient(ApiKeyPair apiKey)
            : this((Region) null, apiKey, null, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        /// <param name="locale"> The locale to use to perform request (item names, class names, etc are retrieved in the locale specified) </param>
        /// <remarks>
        ///   Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        protected ApiClient(string region, ApiKeyPair apiKey, string locale)
            : this(Region.GetRegion(region), apiKey, locale, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        /// <param name="locale"> The locale to use to perform request (item names, class names, etc are retrieved in the locale specified) </param>
        /// <param name="cacheManager"> Cache manager to cache data </param>
        /// <remarks>
        ///   Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        protected ApiClient(string region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager)
            : this(Region.GetRegion(region), apiKey, locale, cacheManager)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        /// <param name="locale"> The locale to use to perform request (item names, class names, etc are retrieved in the locale specified) </param>
        /// <param name="cacheManager"> Cache manager to cache data </param>
        /// <remarks>
        ///   Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        protected ApiClient(Region region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager)
            : this(region, locale, cacheManager)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        ///   Gets or sets proxy Host address. 
        ///   In case of running in silverlight without elevated privilates a proxy hosted on the host web application
        ///   is needed to perform requests
        /// </summary>
        public static Uri ProxyUri
        {
            get
            {
                return _proxyUri;
            }
            set
            {
                _proxyUri = value;
            }
        }

        /// <summary>
        ///   Gets the region to which this ApiClient connects
        /// </summary>
        public Region Region
        {
            get
            {
                return _region;
            }
            private set
            {
                _region = value;
            }
        }

        /// <summary>
        ///   Gets the locale which is used to get item names
        /// </summary>
        public string Locale
        {
            get
            {
                return _locale;
            }
            private set
            {
                _locale = value;
            }
        }

        /// <summary>
        ///   Initialize authenticatio support
        /// </summary>
        /// <returns> </returns>
        private static AuthenticationSupport InitializeAuthenticationSupport()
        {
            Type hashType = typeof (int).Assembly.GetType("System.Security.Cryptography.HMACSHA1", false);
            if (hashType == null)
                return null;
            MethodInfo computeHashMethod = hashType.GetMethod("ComputeHash", new[] {typeof (byte[])});
            if (computeHashMethod == null)
                return null;
            return new AuthenticationSupport
                       {
                           ComputeHashMethod = computeHashMethod,
                           HashType = hashType,
                       };
        }

        /// <summary>
        ///   Creates a GET request
        /// </summary>
        /// <param name="client">HttpClient object</param>
        /// <param name="path">request relative url</param>
        /// <param name="ignoreAuthentication">whether to always perform unauthenticatd requests </param>
        /// <returns>Request Url.</returns>
        private Uri SetupRequest(HttpClient client, string path, bool ignoreAuthentication)
        {
            if (ProxyUri != null)
            {
                client.DefaultRequestHeaders.Add(RegionNameHttpHeader, Region.Name);
                client.DefaultRequestHeaders.Add(ApiUrlHttpHeader, path);
                client.DefaultRequestHeaders.Add(LocaleHttpHeader, Locale);

                return ProxyUri;
            }
            else
            {
                // Blizzard recommends that SSL is used when authenticating using the API key
                var uri =
                    new Uri((_apiKey == null || _authenticationSupport == null || ignoreAuthentication
                                 ? "http://"
                                 : "https://")
                            + Region.Host + path);
                if (!uri.AbsolutePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    uri = !string.IsNullOrEmpty(uri.Query)
                              ? new Uri(uri + "&locale=" + Locale.Replace('-', '_'))
                              : new Uri(uri + "?locale=" + Locale.Replace('-', '_'));
                }
                if (!ignoreAuthentication)
                {
                    SetAuthenticationHeader(client, uri, _apiKey);
                }
                return uri;
            }
        }

        /// <summary>
        ///   Sets the request authentication header
        /// </summary>
        /// <param name="client"> Http client</param>
        /// <param name="requestUri">request Url</param>
        /// <param name="apiKey"> battle.net api authenticate keys </param>
        internal static void SetAuthenticationHeader(HttpClient client, Uri requestUri, ApiKeyPair apiKey)
        {
            if (apiKey != null && _authenticationSupport != null)
            {
                DateTimeOffset date = DateTimeOffset.Now.ToUniversalTime();
                client.DefaultRequestHeaders.Date = date;

                string dateString = date.ToString("r", CultureInfo.InvariantCulture);

                string stringToSign = "GET" + "\n" + dateString
                                      + "\n" + requestUri.AbsolutePath + "\n";
                using (
                    var hashAlgorithm =
                        (IDisposable)
                        Activator.CreateInstance(_authenticationSupport.HashType, apiKey.GetPrivateKeyBytes()))
                {
                    string signature = Convert.ToBase64String(
                        (byte[]) _authenticationSupport.ComputeHashMethod.Invoke(hashAlgorithm,
                                                                                 new object[]
                                                                                     {
                                                                                         Encoding.UTF8.GetBytes(
                                                                                             stringToSign)
                                                                                     }));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BNET", apiKey.PublicKey + ":" + signature);
                }
            }
        }

        /// <summary>
        /// Performs Http Get request asynchronously
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="path">relative URL of the object to get</param>
        /// <param name="objectToRefresh">object to refresh</param>
        /// <returns>A task object for the async HTTP get</returns>
        internal async Task<T> GetAsync<T>(string path, T objectToRefresh) where T : class
        {
            var objResult = await GetAsync(path, typeof(T), objectToRefresh);
            return (T)objResult;
        }

        /// <summary>
        /// Performs Http Get request asynchronously
        /// </summary>
        /// <param name="path">relative URL of the object to get</param>
        /// <param name="objectType">object type</param>
        /// <param name="objectToRefresh">object to refresh</param>
        /// <returns>A task object for the async HTTP get</returns>
        internal async Task<object> GetAsync(string path, Type objectType, object objectToRefresh)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }
            if (_cacheManager != null && objectToRefresh == null)
            {
                object cachedObject = await GetObjectFromCacheAsync(path);
                if (cachedObject != null)
                {
                    return cachedObject;
                }
            }
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var client = new HttpClient(handler))
            {
                var objectApiResponse = objectToRefresh as ApiResponse;
                // Set If-Modified-Since header
                if (objectApiResponse != null && path == objectApiResponse.Path && objectApiResponse.LastModifiedUtc != DateTime.MinValue)
                {
                    client.DefaultRequestHeaders.IfModifiedSince = objectApiResponse.LastModifiedUtc;
                }

                bool ignoreAuthentication = objectType.IsDefined(typeof(DoNotAuthenticateAttribute), true);
                var uri = SetupRequest(client, path, ignoreAuthentication);
                var responseMessage = await client.GetAsync(uri);
                if (responseMessage.StatusCode == HttpStatusCode.NotModified)
                {
                    return objectToRefresh;
                }
                else if (responseMessage.IsSuccessStatusCode)
                {
                    object obj;
                    if (typeof(ApiResponse).IsAssignableFrom(objectType))
                    {
                        obj = await DeserializeResponse(path, objectType, responseMessage);
                    }
                    else
                    {
                        obj = await responseMessage.Content.ReadAsByteArrayAsync();
                    }
                    if (_cacheManager != null)
                    {
                        try
                        {
                            await _cacheManager.AddDataAsync(Region.Name
                                                  + "/" + Locale + "/" + path, obj);
                        }
                        catch (CacheManagerException)
                        {
                            // if we failed to add item to cache, swallow and return normally
                        }
                    }
                    return obj;
                }
                else
                {
                    ApiError apiError = null;
                    try
                    {
                        apiError = (ApiError)await DeserializeResponse(path, typeof(ApiError), responseMessage);
                    }
                    catch (JsonException)
                    {
                        // Failed to deserialize error
                        apiError = null;
                    }
                    throw new ApiException(apiError, responseMessage.StatusCode, null);
                }
            }
            
        }

        /// <summary>
        /// Deserializers
        /// </summary>
        /// <param name="path"></param>
        /// <param name="objectType"></param>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        private async Task<object> DeserializeResponse(string path, Type objectType, HttpResponseMessage responseMessage)
        {
            var responseStream = await responseMessage.Content.ReadAsStreamAsync();
            try
            {
                var textReader = new StreamReader(responseStream);
                // textReader now owns responseStream and will dispose it
                // Make sure that responseStream.Dispose is not called more than once
                // by setting responseStream to null
                responseStream = null; 
                try
                {
                    var serializer = CreateJsonSerializer(responseMessage);
                    using (var jsonReader = new JsonTextReader(textReader))
                    {
                        // jsonReader now owns textReader and will dispose it.
                        // Make sure that responseStream.Dispose is not called more than once 
                        // by setting textReader to null
                        textReader = null; 
                        ApiResponse apiResponseResult;
                        
                        // Deserialization is a CPU bound operation
                        // But since some calls return big data (such as auction dump api)
                        // Serialization can take a long time
                        // therefore make it a separate task so that it doesn't block main thread
                        var deserializeTask = new Task<ApiResponse>(() => (ApiResponse)serializer.Deserialize(jsonReader, objectType));
                        deserializeTask.Start();
                        apiResponseResult = await deserializeTask;

                        // Post serialization
                        apiResponseResult.Path = path;
                        return apiResponseResult;
                    }
                }
                finally
                {
                    if (textReader != null)
                        textReader.Dispose();
                }
            }
            finally
            {
                if (responseStream != null)
                    responseStream.Dispose();
            }
        }

        /// <summary>
        /// Creates a JSON serializer to serialize objects
        /// </summary>
        /// <param name="responseMessage">Http response message</param>
        /// <returns>Json serializer</returns>
        internal virtual JsonSerializer CreateJsonSerializer(HttpResponseMessage responseMessage)
        {
            // Store information about serialization context 
            // So that JsonApiResponseConverter would correctly 
            // populate ApiClient property for ApiResponse object
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new JsonApiResponseConverter(this, responseMessage));

            // This is needed for Testing to make sure that new data added by blizzard is not missed
            // Blizzard has the habit of adding new things to the API without an announcement
            // And without a change of documentation
            if (TestMode)
            {
                serializer.MissingMemberHandling = MissingMemberHandling.Error;
            }
            return serializer;
        }

        

        /// <summary>
        /// Tries to fetch an object from cache
        /// </summary>
        /// <param name="path">object path</param>
        /// <returns>The cached object if found or null otherwise.</returns>
        private async Task<object> GetObjectFromCacheAsync(string path)
        {
            object cachedObject = null;
            try
            {
                cachedObject = await _cacheManager.LookupDataAsync(Region.Name
                                                        + "/" + Locale + "/" + path);
            }
            catch (CacheManagerException)
            {
                // if cacheManager fail swallow and continue without caching
                return null;
            }
            return cachedObject;
        }

        /// <summary>
        ///   Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value"> time value returned by API </param>
        /// <returns> Utc time object </returns>
        internal static DateTime GetUtcDateFromUnixTimeMilliseconds(long value)
        {
            try
            {
                return _unixStartDate.AddMilliseconds(value);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the Unit time value from the Date time object
        /// </summary>
        /// <param name="date"> date time object </param>
        /// <returns> Unix time value </returns>
        internal static long GetUnixTimeFromDateMilliseconds(DateTime date)
        {
            return (long) Math.Round((date - _unixStartDate).TotalMilliseconds, 0);
        }

        /// <summary>
        ///   Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value"> time value returned by API </param>
        /// <returns> Utc time object </returns>
        internal static DateTime GetUtcDateFromUnixTimeSeconds(long value)
        {
            try
            {
                return _unixStartDate.AddSeconds(value);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///   Gets the Unit time value from the Date time object
        /// </summary>
        /// <param name="date"> date time object </param>
        /// <returns> Unix time value </returns>
        internal static long GetUnixTimeFromDateSeconds(DateTime date)
        {
            return (long)Math.Round((date - _unixStartDate).TotalSeconds, 0);
        }

        #region Nested type: AuthenticationSupport

        /// <summary>
        ///   Authentication support class
        /// </summary>
        private class AuthenticationSupport
        {
            /// <summary>
            ///   System.Security.Cryptography.HMACSHA1.ComputeHash
            /// </summary>
            public MethodInfo ComputeHashMethod;

            /// <summary>
            ///   System.Security.Cryptography.HMACSHA1
            /// </summary>
            public Type HashType;
        }

        #endregion
    }
}