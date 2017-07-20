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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

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
        ///   Authentication support
        /// </summary>
        private static readonly AuthenticationSupport _authenticationSupport = InitializeAuthenticationSupport();

        /// <summary>
        ///   Compression support
        /// </summary>
        private static readonly CompressionSupport _compressionSupport = InitializeCompressionSupport();

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
            PropertyInfo property = typeof (HttpWebRequest).GetProperty("Date");
            if (property == null)
                return null;
            return new AuthenticationSupport
                       {
                           ComputeHashMethod = computeHashMethod,
                           HashType = hashType,
                           RequestDateProperty = property
                       };
        }

        /// <summary>
        ///   Compression handled throw reflection of GzipStream and DeflateStream classes
        /// </summary>
        /// <returns> A Compression support object </returns>
        private static CompressionSupport InitializeCompressionSupport()
        {
            Assembly systemDllAssembly = typeof (HttpWebRequest).Assembly;
            Type deflateStreamType = systemDllAssembly.GetType("System.IO.Compression.DeflateStream", false);
            Type gzipStreamType = systemDllAssembly.GetType("System.IO.Compression.GZipStream", false);
            Type compressionModeType = systemDllAssembly.GetType("System.IO.Compression.CompressionMode", false);

            if (compressionModeType != null && (deflateStreamType != null || gzipStreamType != null))
            {
                var support = new CompressionSupport
                                  {
                                      DeflateStreamType = deflateStreamType,
                                      GZipStreamType = gzipStreamType
                                  };
                if (gzipStreamType == null)
                    support.SupportedContentEncodings = "deflate";
                else if (deflateStreamType == null)
                    support.SupportedContentEncodings = "gzip";
                else
                    support.SupportedContentEncodings = "gzip,deflate";
                support.DecompressionMode = Enum.Parse(compressionModeType, "Decompress", false);
                return support;
            }
            return null;
        }


        /// <summary>
        ///   Gets response stream from a response
        /// </summary>
        /// <param name="response"> HttpResponse object </param>
        /// <returns> Response stream </returns>
        /// <remarks>
        ///   If the request is compressed using either gzip or deflate, a gzip or deflate stream is returned
        /// </remarks>
        private static Stream GetResponseStream(HttpWebResponse response)
        {
            Stream stream = response.GetResponseStream();
            if (_compressionSupport != null)
            {
                string contentEncoding = null;
                try
                {
                    contentEncoding = response.Headers["Content-Encoding"];
                }
                catch (NotImplementedException)
                {
                }
                if (string.Equals(contentEncoding, "gzip", StringComparison.OrdinalIgnoreCase))
                    stream =
                        (Stream)
                        Activator.CreateInstance(_compressionSupport.GZipStreamType, stream,
                                                 _compressionSupport.DecompressionMode);
                else if (string.Equals(contentEncoding, "deflate", StringComparison.OrdinalIgnoreCase))
                    stream =
                        (Stream)
                        Activator.CreateInstance(_compressionSupport.DeflateStreamType, stream,
                                                 _compressionSupport.DecompressionMode);
            }
            return stream;
        }

        /// <summary>
        ///   Creates a GET request
        /// </summary>
        /// <param name="path"> url </param>
        /// <param name="ignoreAuthentication"> whether to always perform unauthenticatd requests </param>
        /// <returns> the HTTP request object </returns>
        protected virtual HttpWebRequest CreateGetRequest(string path, bool ignoreAuthentication)
        {
            if (ProxyUri != null)
            {
                var request = (HttpWebRequest) WebRequest.Create(ProxyUri);
                request.Headers[RegionNameHttpHeader] = Region.Name;
                request.Headers[ApiUrlHttpHeader] = path;
                request.Headers[LocaleHttpHeader] = Locale;
                return request;
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
                var request = (HttpWebRequest) WebRequest.Create(uri);
                if (!ignoreAuthentication)
                {
                    SetAuthenticationHeader(request, _apiKey);
                }
                if (_compressionSupport != null)
                {
                    request.Headers[HttpRequestHeader.AcceptEncoding] = _compressionSupport.SupportedContentEncodings;
                }
                return request;
            }
        }

        /// <summary>
        ///   Sets the request authentication header
        /// </summary>
        /// <param name="request"> request </param>
        /// <param name="apiKey"> </param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        internal static void SetAuthenticationHeader(HttpWebRequest request, ApiKeyPair apiKey)
        {
            if (apiKey != null && _authenticationSupport != null)
            {
                DateTime date = DateTime.Now.ToUniversalTime();
                string dateString = date.ToString("r", CultureInfo.InvariantCulture);

                _authenticationSupport.RequestDateProperty.SetValue(request, date, null);

                string stringToSign = request.Method + "\n" + dateString
                                      + "\n" + request.RequestUri.AbsolutePath + "\n";
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
                    request.Headers[HttpRequestHeader.Authorization] = "BNET " + apiKey.PublicKey + ":" + signature;
                }
            }
        }

        /// <summary>
        ///   Performs a GET HTTP request to Blizzard's battle.net Community API and deserializes the response.
        /// </summary>
        /// <typeparam name="T"> The type to which the response is deseralized to </typeparam>
        /// <param name="path"> The url of the request (only path and query string are included. Host name, port and protocol not included) </param>
        /// <param name="objectToRefresh"> In case the object was in cache, the LastModifiedUtc is used to add the IfModofiedSince header </param>
        /// <param name="callback"> The callback method to call then the operation is complete </param>
        /// <param name="asyncState"> the user defined state </param>
        /// <returns> The async result object representing the asynchronous operation status. </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public virtual IAsyncResult BeginRequest<T>(string path, T objectToRefresh, AsyncCallback callback,
                                                    object asyncState) where T : class
        {
            var apiAsyncResult = new ApiAsyncResult<T>(callback, asyncState, this);
            // if we have a cache manager, try to use it.
            if (_cacheManager != null && objectToRefresh == null)
            {
                T cachedObject = null;
                try
                {
                    cachedObject = _cacheManager.LookupData(Region.Name
                                                            + "/" + Locale + "/" + path) as T;
                }
                catch (CacheManagerException)
                {
                    // if cacheManager fail swallow and continue without caching
                }
                var cachedApiResponse = cachedObject as ApiResponse;
                if (cachedApiResponse != null)
                {
                    cachedApiResponse.Client = this;
                }
                if (cachedObject != null)
                {
                    apiAsyncResult.SetComplete(cachedObject, true);
                    return apiAsyncResult;
                }
            }
            bool ignoreAuthentication = typeof (T).IsDefined(typeof (DoNotAuthenticateAttribute), true);
            HttpWebRequest request = CreateGetRequest(path, ignoreAuthentication);
            // support compression to save bandwidth
            var objectApiResponse = objectToRefresh as ApiResponse;
            // Set If-Modified-Since header
            if (objectApiResponse != null && path == objectApiResponse.Path)
            {
                PropertyInfo property = typeof (HttpWebRequest).GetProperty("IfModifiedSince");
                if (property == null)
                {
                    request.Headers[HttpRequestHeader.IfModifiedSince] = objectApiResponse.LastModifiedUtc.ToString(
                        "R", CultureInfo.InvariantCulture);
                }
                else
                {
                    property.SetValue(request, objectApiResponse.LastModifiedUtc, null);
                }
            }
            //request.KeepAlive = false;
            request.BeginGetResponse(EndHttpRequest<T>, new object[] {apiAsyncResult, request, objectToRefresh, path});
            return apiAsyncResult;
        }

        /// <summary>
        ///   Ends the HttpRequest
        /// </summary>
        /// <typeparam name="T"> The type of object returned from the HTTP request </typeparam>
        /// <param name="webAsyncResult"> The state of the HTTP web asynchronous request </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void EndHttpRequest<T>(IAsyncResult webAsyncResult) where T : class
        {
            // Get the request state
            var state = (object[]) webAsyncResult.AsyncState;
            var apiAsyncResult = (ApiAsyncResult<T>) state[0];
            var request = (HttpWebRequest) state[1];
            var objectToRefresh = (T) state[2];
            var path = (string) state[3];

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) request.EndGetResponse(webAsyncResult);
                using (Stream responseStream = GetResponseStream(response))
                {
                    T obj;
                    if (typeof (ApiResponse).IsAssignableFrom(typeof (T)))
                    {
                        var serializer = new DataContractJsonSerializer(typeof (T));
                        var apiResponseResult = (ApiResponse) serializer.ReadObject(responseStream);
                        apiResponseResult.OnDeserialized(this);
                        if (apiResponseResult.LastModifiedUtc == DateTime.MinValue)
                        {
                            try
                            {
                                // .NET will add the LastModified property to now if Last-Modified header is missing
                                string lastModifiedHeader = response.Headers["Last-Modified"];
                                if (!string.IsNullOrEmpty(lastModifiedHeader))
                                {
                                    apiResponseResult.LastModifiedUtc = DateTime.ParseExact(lastModifiedHeader, "R",
                                                                                            CultureInfo.InvariantCulture,
                                                                                            DateTimeStyles.
                                                                                                AdjustToUniversal |
                                                                                            DateTimeStyles.
                                                                                                AllowInnerWhite |
                                                                                            DateTimeStyles.
                                                                                                AllowLeadingWhite |
                                                                                            DateTimeStyles.
                                                                                                AllowTrailingWhite |
                                                                                            DateTimeStyles.
                                                                                                AssumeUniversal);
                                }
                            }
                            catch (NotImplementedException)
                            {
                                // Silverlight does not have LastModified property, and response.Headers will throw NotImplemented exception
                                apiResponseResult.LastModifiedUtc = DateTime.UtcNow;
                            }
                        }
                        apiResponseResult.Client = this;
                        apiResponseResult.Path = path;
                        obj = (T) (object) apiResponseResult;
                    }
                    else
                    {
                        var buffer = new byte[response.ContentLength];
                        int l;
                        int offset = 0;
                        while ((l = responseStream.Read(buffer, offset, buffer.Length - offset)) > 0)
                        {
                            offset += l;
                        }
                        obj = (T) (object) buffer;
                    }
                    if (_cacheManager != null)
                    {
                        try
                        {
                            _cacheManager.AddData(Region.Name
                                                  + "/" + Locale + "/" + path, obj);
                        }
                        catch (CacheManagerException)
                        {
                            // if we failed to add item to cache, swallow and return normally
                        }
                    }
                    apiAsyncResult.SetComplete(obj, webAsyncResult.CompletedSynchronously);
                }
            }
                // In Silverlight GetResponseStream returns null, so there is no way we can deserialize the error
                // So in case of silver light we simply let the exception bubble and rely on the caller to handle it
            catch (WebException webException)
            {
                if ((int) webException.Status != 7 /*WebExceptionStatus.ProtocolError*/)
                {
                    apiAsyncResult.SetComplete(webException, webAsyncResult.CompletedSynchronously);
                    return;
                }
                response = (HttpWebResponse) webException.Response;

                if (response.StatusCode == HttpStatusCode.NotModified)
                {
                    apiAsyncResult.SetComplete(objectToRefresh, webAsyncResult.CompletedSynchronously);
                    return;
                }

                // try to parse the error returned in the HTTP response
                using (Stream responseStream = GetResponseStream(response))
                {
                    if (responseStream == null)
                    {
                        apiAsyncResult.SetComplete(webException, webAsyncResult.CompletedSynchronously);
                        return;
                    }

                    ApiError error;
                    try
                    {
                        var serializer = new DataContractJsonSerializer(typeof (ApiError));
                        error = (ApiError) serializer.ReadObject(responseStream);
                    }
                    catch (SerializationException)
                    {
                        error = null;
                    }
                    if (error == null)
                    {
                        apiAsyncResult.SetComplete(webException, webAsyncResult.CompletedSynchronously);
                        return;
                    }
                    // Wrapping the exception into an ApiException
                    var apiException = new ApiException(error, response.StatusCode, webException);
                    apiAsyncResult.SetComplete(apiException, webAsyncResult.CompletedSynchronously);
                }
            }
            catch (Exception ex)
            {
                // the exception will be rethrown by the EndRequest method
                apiAsyncResult.SetComplete(ex, webAsyncResult.CompletedSynchronously);
            }

            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }

        /// <summary>
        ///   Waits for the async operation to complete and returns the result
        /// </summary>
        /// <typeparam name="T"> The type to which the response is deserialized </typeparam>
        /// <param name="result"> The status of the result </param>
        /// <returns> </returns>
        public T EndRequest<T>(IAsyncResult result) where T : class
        {
            if (result == null)
                throw new ArgumentNullException("result");
            var apiResult = result as ApiAsyncResult<T>;
            if (apiResult == null)
                throw new ArgumentException(ErrorMessages.InvalidAsyncResult, "result");
            return apiResult.EndProcessing(this);
        }

        /// <summary>
        ///   Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value"> time value returned by API </param>
        /// <returns> Utc time object </returns>
        public static DateTime GetUtcDateFromUnixTime(long value)
        {
            return _unixStartDate.AddMilliseconds(value);
        }

        /// <summary>
        ///   Gets the Unit time value from the Date time object
        /// </summary>
        /// <param name="date"> date time object </param>
        /// <returns> Unix time value </returns>
        public static long GetUnixTimeFromDate(DateTime date)
        {
            return (long) Math.Round((date - _unixStartDate).TotalMilliseconds, 0);
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

            /// <summary>
            ///   HttpWebRequest.Date
            /// </summary>
            public PropertyInfo RequestDateProperty;
        }

        #endregion

        #region Nested type: CompressionSupport

        /// <summary>
        ///   Compression support
        /// </summary>
        private class CompressionSupport
        {
            /// <summary>
            ///   Enum value for decompression support
            /// </summary>
            public object DecompressionMode;

            /// <summary>
            ///   System.IO.Compression.DeflateStream type
            /// </summary>
            public Type DeflateStreamType;

            /// <summary>
            ///   System.IO.Compression.GZipStream type
            /// </summary>
            public Type GZipStreamType;

            /// <summary>
            ///   Accept-Encoding header value
            /// </summary>
            public string SupportedContentEncodings;
        }

        #endregion
    }
}