// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WOWSharp.Community.SilverlightProxy
{
    /// <summary>
    ///   An HTTP handler to route silverlight requests to battle.net sites
    /// </summary>
    public class ApiRequestRouter : IHttpHandler
    {
        /// <summary>
        ///   Region name HTTP header
        /// </summary>
        private const string RegionNameHttpHeader = "X-WOWSharpProxy-Region";

        /// <summary>
        ///   Url HTTP header
        /// </summary>
        private const string ApiUrlHttpHeader = "X-WOWSharpProxy-Url";

        /// <summary>
        ///   Locale HTTP header
        /// </summary>
        private const string LocaleHttpHeader = "X-WOWSharpProxy-Locale";

        #region IHttpHandler Members

        /// <summary>
        ///   There is no resources allocated by this handler, so it's safe to reuse
        /// </summary>
        public virtual bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///   Routes a request to battle.net community site
        /// </summary>
        /// <param name="context"> HttpContext </param>
        public virtual void ProcessRequest(HttpContext context)
        {
            // Region name
            string regionName = context.Request.Headers[RegionNameHttpHeader];
            if (string.IsNullOrEmpty(regionName))
            {
                Error(context,
                      string.Format(CultureInfo.InvariantCulture, ErrorMessages.HeaderMissing, RegionNameHttpHeader));
                return;
            }

            Region region =
                Region.AllRegions.FirstOrDefault(
                    r => string.Equals(r.Name, regionName, StringComparison.OrdinalIgnoreCase));
            if (region == null)
            {
                Error(context,
                      string.Format(CultureInfo.InvariantCulture, ErrorMessages.InvalidRegion, RegionNameHttpHeader));
                return;
            }

            // Url (Required)
            string url = context.Request.Headers[ApiUrlHttpHeader];
            if (string.IsNullOrEmpty(url))
            {
                Error(context,
                      string.Format(CultureInfo.InvariantCulture, ErrorMessages.HeaderMissing, ApiUrlHttpHeader));
                return;
            }

            // Locale (Not required)
            string locale =
                region.GetSupportedLocale(context.Request.Headers[LocaleHttpHeader]).Replace('-', '_');

            var uri = new Uri("http://" + region.Host + url);
            uri = !string.IsNullOrEmpty(uri.Query)
                      ? new Uri(uri + "&locale=" + locale)
                      : new Uri(uri + "?locale=" + locale);

            // Create the request
            var request = (HttpWebRequest) WebRequest.Create(uri);
            SetAuthenticationHeader(request, GetApiKey());


            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                ReturnResponse(context, response);
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse) ex.Response;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                    ReturnResponse(context, response);
                else
                    Error(context, ex.Message);
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        #endregion

        /// <summary>
        ///   Returns a routing error to the silverlight client
        /// </summary>
        /// <param name="context"> Http Context </param>
        /// <param name="errorDescription"> Error message </param>
        public void Error(HttpContext context, string errorDescription)
        {
            context.Response.StatusCode = 500;
            context.Response.StatusDescription = "Proxy Error";
            var error = new ApiError("nok", errorDescription);
            var serializer = new DataContractJsonSerializer(typeof (ApiError));
            serializer.WriteObject(context.Response.OutputStream, error);
        }

        /// <summary>
        ///   Returns the response from battle.net as it is
        /// </summary>
        /// <param name="context"> Http Context </param>
        /// <param name="response"> the battle.net site response </param>
        public void ReturnResponse(HttpContext context, HttpWebResponse response)
        {
            context.Response.StatusCode = (int) response.StatusCode;
            context.Response.StatusDescription = response.StatusDescription;
            var buffer = new byte[32*1024];
            using (Stream stream = response.GetResponseStream())
            {
                int length;
                while (stream != null && (length = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, length);
                }
            }
        }

        /// <summary>
        ///   When overriden gets the API key.
        /// </summary>
        /// <returns> Returns the API key used to get the request </returns>
        public virtual ApiKeyPair GetApiKey()
        {
            // I rather not implement it here 
            // It's up to the application to determine how to secure the keys
            return null;
        }

        /// <summary>
        ///   Sets the request authentication header
        /// </summary>
        /// <param name="request"> request </param>
        /// <param name="apiKey"> api key pair </param>
        internal static void SetAuthenticationHeader(HttpWebRequest request, ApiKeyPair apiKey)
        {
            if (apiKey != null)
            {
                DateTime date = DateTime.Now.ToUniversalTime();
                string dateString = date.ToString("r", CultureInfo.InvariantCulture);
                request.Date = date;

                string stringToSign = request.Method + "\n" + dateString
                                      + "\n" + request.RequestUri.AbsolutePath + "\n";
                using (var hashAlgorithm = new HMACSHA1(apiKey.GetPrivateKeyBytes()))
                {
                    string signature = Convert.ToBase64String(
                        hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                    request.Headers[HttpRequestHeader.Authorization] = "BNET " + apiKey.PublicKey + ":" + signature;
                }
            }
        }
    }
}