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
using System.IO;
using System.Net;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;
using System.Threading;
using WOWSharp.Community.ObjectModel;

#if !SILVERLIGHT
using System.IO.Compression;
#endif

namespace WOWSharp.Community
{
    /// <summary>
    /// A Blizzard's WOW community API client
    /// </summary>
    public partial class ApiClient
    {
        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <remarks>
        /// The default constructor will use the default region and locale determined by the current thread's culture.
        /// </remarks>
        public ApiClient()
            : this((Region)null, null, null)
        {

        }

        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        public ApiClient(Region region)
            : this(region, null, null)
        {

        }

        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        /// <param name="locale">the locale to use for retrieving data</param>
        public ApiClient(Region region, string locale)
            : this(region, locale, null)
        {

        }

        /// <summary>
        /// Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region">Regional WOW Community website to which the ApiClient should connect to perform request.</param>
        /// <param name="locale">the locale to use for retrieving data</param>
        /// <param name="cacheManager">Cache manager to cache data</param>
        public ApiClient(Region region, string locale, ICacheManager cacheManager)
        {
            if (region == null)
                region = Region.Default;
            this.Region = region;
            this.Locale = Region.GetSupportedLocale(locale);
            this._cacheManager = cacheManager;
        }


        /// <summary>
        /// Gets the region to which this ApiClient connects
        /// </summary>
        public Region Region
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the locale which is used to get item names
        /// </summary>
        public string Locale
        {
            get;
            private set;
        }

        private ICacheManager _cacheManager;


        //        /// <summary>
        //        /// Gets response stream from a response
        //        /// </summary>
        //        /// <param name="response">HttpResponse object</param>
        //        /// <returns>Response stream</returns>
        //        /// <remarks>If the request is compressed using either gzip or deflate, a gzip or deflate stream is returned</remarks>
        //        private static Stream GetResponseStream(HttpWebResponse response)
        //        {
        //            Stream stream = response.GetResponseStream();
        //#if !SILVERLIGHT
        //            if (string.Equals(response.ContentEncoding, "gzip", StringComparison.OrdinalIgnoreCase))
        //                stream = new GZipStream(stream, CompressionMode.Decompress);
        //            else if (string.Equals(response.ContentEncoding, "deflate", StringComparison.OrdinalIgnoreCase))
        //                stream = new DeflateStream(stream, CompressionMode.Decompress);
        //#endif
        //            return stream;
        //        }

        /// <summary>
        /// Performs a GET HTTP request to Blizzard's WOW Community API and deserializes the response.
        /// </summary>
        /// <typeparam name="T">The type to which the response is deseralized to</typeparam>
        /// <param name="path">The url of the request (only path and query string are included. Host name, port and protocol not included)</param>
        /// <param name="objectToRefresh">In case the object was in cache, the LastModifiedUtc is used to set the IfModofiedSince header</param>
        /// <param name="callback">The callback method to call then the operation is complete</param>
        /// <param name="asyncState">the user defined state</param>
        /// <returns>The async result object representing the asynchronous operation status.</returns>
        public virtual IAsyncResult BeginRequest<T>(string path, T objectToRefresh, AsyncCallback callback, object asyncState) where T : class
        {
            ApiAsyncResult<T> apiAsyncResult = new ApiAsyncResult<T>(callback, asyncState, this);
            // if we have a cache manager, try to use it.
            if (_cacheManager != null && objectToRefresh == null)
            {
                T cachedObject = null;
                try
                {
                    cachedObject = _cacheManager.LookupData(this.Region.Name
                    + "/" + this.Locale + "/" + path) as T;
                }
                catch
                {
                    // if cacheManager fail swallow and continue without caching
                }
                ApiResponse cachedApiResponse = cachedObject as ApiResponse;
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
            HttpWebRequest request = CreateGetRequest(path);
#if !SILVERLIGHT
            // support compression to save bandwidth
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            ApiResponse objectApiResponse = objectToRefresh as ApiResponse;
            // Set If-Modified-Since header
            if (objectApiResponse != null && path == objectApiResponse.Path)
                request.IfModifiedSince = objectApiResponse.LastModifiedUtc;
            //request.KeepAlive = false;
#endif
            request.BeginGetResponse(EndHttpRequest<T>, new object[] { apiAsyncResult, request, objectToRefresh, path });
            return apiAsyncResult;
        }

        /// <summary>
        /// Ends the HttpRequest
        /// </summary>
        /// <typeparam name="T">The type of object returned from the HTTP request</typeparam>
        /// <param name="webAsyncResult">The state of the HTTP web asynchronous request</param>
        private void EndHttpRequest<T>(IAsyncResult webAsyncResult) where T : class
        {
            // Get the request state
            object[] state = (object[])webAsyncResult.AsyncState;
            ApiAsyncResult<T> apiAsyncResult = (ApiAsyncResult<T>)state[0];
            HttpWebRequest request = (HttpWebRequest)state[1];
            T objectToRefresh = (T)state[2];
            string path = (string)state[3];

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.EndGetResponse(webAsyncResult);
                using (Stream responseStream = response.GetResponseStream())
                {
                    T obj = null;
                    if (typeof(ApiResponse).IsAssignableFrom(typeof(T)))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        ApiResponse apiResponseResult = (ApiResponse)serializer.ReadObject(responseStream);
                        if (apiResponseResult.LastModifiedUtc == DateTime.MinValue)
                        {
#if !SILVERLIGHT
                            // .NET will set the LastModified property to now if Last-Modified header is missing
                            apiResponseResult.LastModifiedUtc = response.LastModified;
#else
                            // Silverlight does not have LastModified property, and response.Headers will throw NotImplemented exception
                            apiResponseResult.LastModifiedUtc = DateTime.UtcNow;
#endif
                        }
                        apiResponseResult.Client = this;
                        apiResponseResult.Path = path;
                        obj = (T)(object)apiResponseResult;
                    }
                    else
                    {
                        byte[] buffer = new byte[response.ContentLength];
                        int l;
                        int offset = 0;
                        while ((l = responseStream.Read(buffer, offset, buffer.Length - offset)) > 0)
                        {
                            offset += l;
                        }
                        obj = (T)(object)buffer;
                    }
                    if (_cacheManager != null)
                    {
                        try
                        {
                            _cacheManager.AddData(this.Region.Name
                        + "/" + this.Locale + "/" + path, obj);
                        }
                        catch
                        {
                            // if we failed to add item to cache, swallow and return normally
                        }
                    }
                    apiAsyncResult.SetComplete(obj, webAsyncResult.CompletedSynchronously);
                    return;
                }
            }
#if !SILVERLIGHT
            // In Silverlight GetResponseStream returns null, so there is no way we can deserialize the error
            // So in case of silver light we simply let the exception bubble and rely on the caller to handle it
            catch (WebException webException)
            {
                if (webException.Status != WebExceptionStatus.ProtocolError)
                {
                    apiAsyncResult.SetComplete(webException, webAsyncResult.CompletedSynchronously);
                    return;
                }
                response = (HttpWebResponse)webException.Response;

                if (response.StatusCode == HttpStatusCode.NotModified)
                {
                    apiAsyncResult.SetComplete(objectToRefresh, webAsyncResult.CompletedSynchronously);
                    return;
                }

                // try to parse the error returned in the HTTP response
                using (Stream responseStream = response.GetResponseStream())
                {
                    ApiError error;
                    try
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ApiError));
                        error = (ApiError)serializer.ReadObject(responseStream);
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
                    // Wrapping the exception into an WoWApiException
                    WoWAPIException apiException = new WoWAPIException(error, response.StatusCode, webException);
                    apiAsyncResult.SetComplete(apiException, webAsyncResult.CompletedSynchronously);
                    return;
                }
            }
#endif
            catch (Exception ex)
            {
                // the exception will be rethrown by the EndRequest method
                apiAsyncResult.SetComplete(ex, webAsyncResult.CompletedSynchronously);
                return;
            }

            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        /// <summary>
        /// Waits for the async operation to complete and returns the result
        /// </summary>
        /// <typeparam name="T">The type to which the response is deserialized</typeparam>
        /// <param name="result">The status of the result</param>
        /// <returns></returns>
        public T EndRequest<T>(IAsyncResult result) where T : class
        {
            if (result == null)
                throw new NullReferenceException("result");
            ApiAsyncResult<T> apiResult = result as ApiAsyncResult<T>;
            if (apiResult == null)
                throw new ArgumentException(ErrorMessages.InvalidAsyncResult, "result");
            return apiResult.EndProcessing(this);
        }

        /// <summary>
        /// Object to sync access to _realms field
        /// </summary>
        private object _realmsLock = new object();

        /// <summary>
        /// Caches realms for use of GetSlug method
        /// </summary>
        private Realm[] _realms;

        /// <summary>
        /// Gets a list of all realms (for GetSlug method)
        /// </summary>
        private Realm[] Realms
        {
            get
            {
                // Acquire lock
                lock (_realmsLock)
                {
                    // Realms is already cached
                    if (_realms != null)
                    {
                        return _realms;
                    }
                    // user async api so that it works in silver light
                    IAsyncResult result = this.BeginGetRealmStatus(null, null);
                    var response = this.EndGetRealmStatus(result);
                    // cache the result
                    this._realms = response.Realms;
                    return _realms;
                }
            }
        }


        /// <summary>
        /// Get the realm string to use in the Url for guild and character requests
        /// </summary>
        /// <param name="realmName">Realm name</param>
        /// <returns>realm string to use in Url for guild and character requests</returns>
        internal string GetRealmSlug(string realmName)
        {

            Realm realm = Realms.Where(rlm => string.Equals(realmName, rlm.Name, StringComparison.OrdinalIgnoreCase)
                || string.Equals(realmName, rlm.Slug, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return realm.Slug;
            // With the addition of new portuguese realm in EU, rules have changed, 
            // so better rely on values returned by B.NET instead of string manipulation
            //if (realm == null)
            // return Uri.EscapeUriString(realmName.Replace("'", "")).Replace("+", "-").Replace("%20", "-");
            
        }

        /// <summary>
        /// Reference date for Unix time
        /// </summary>
        private static readonly DateTime _unixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value">time value returned by API</param>
        /// <returns>Utc time object</returns>
        public static DateTime GetUtcDateFromUnixTime(long value)
        {
            return _unixStartDate.AddMilliseconds(value);
        }

        /// <summary>
        /// Gets the Unit time value from the Date time object 
        /// </summary>
        /// <param name="value">date time object</param>
        /// <returns>Unix time value</returns>
        public static long GetUnixTimeFromDate(DateTime date)
        {
            return (long)Math.Round((date - _unixStartDate).TotalMilliseconds, 0);
        }

        /// <summary>
        /// Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="callback">call back method</param>
        /// <param name="state">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetRealmStatus(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<RealmStatusResponse>("/api/wow/realm/status", null, callback, asyncState);
        }

        /// <summary>
        /// Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="realms">Realms to query</param>
        /// <param name="callback">call back method</param>
        /// <param name="state">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetRealmStatus(string[] realms, AsyncCallback callback, object asyncState)
        {
            if (realms == null || realms.Length == 0)
                return BeginGetRealmStatus(callback, asyncState);
            string queryString = "?realms=" + string.Join(",",
                realms.Where(r => !string.IsNullOrEmpty(r)).Select(r => GetRealmSlug(r)).ToArray());
            return BeginRequest<RealmStatusResponse>("/api/wow/realm/status" + queryString, null, callback, asyncState);
        }

        /// <summary>
        /// Waits the realm status operation to complete returns the results
        /// </summary>
        /// <param name="result">The async result for operation</param>
        /// <returns>The result of the realm status operation</returns>
        public RealmStatusResponse EndGetRealmStatus(IAsyncResult result)
        {
            return EndRequest<RealmStatusResponse>(result);
        }

        /// <summary>
        /// Get character profile information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <param name="fieldsToRetrieve">the profile fields to retrieve</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetCharacter(string realm, string characterName, CharacterField fieldsToRetrieve, AsyncCallback callback, object asyncState)
        {
            string[] fields = EnumHelper<CharacterField>.GetNames().Where(name => name != "All" && (fieldsToRetrieve & (CharacterField)Enum.Parse(typeof(CharacterField), name, true)) != 0).Select(name => name.ToLowerInvariant()).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return BeginRequest<Character>("/api/wow/character/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(characterName) + queryString, null, callback, asyncState);
        }

        /// <summary>
        /// Watis for the asynchronous and gets the character's profile
        /// </summary>
        /// <param name="result">The async result for the operation</param>
        /// <returns>The character profile information</returns>
        public Character EndGetCharacter(IAsyncResult result)
        {
            return EndRequest<Character>(result);
        }

        /// <summary>
        /// Gets guild information asynchronously
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <param name="fieldsToRetrieve">the guild fields to retrieve</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetGuild(string realm, string guildName, GuildField fieldsToRetrieve, AsyncCallback callback, object asyncState)
        {
            string[] fields = EnumHelper<GuildField>.GetNames().Where(name => name != "All" && (fieldsToRetrieve & (GuildField)Enum.Parse(typeof(GuildField), name, true)) != 0).Select(name => name.ToLowerInvariant()).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return BeginRequest<Guild>("/api/wow/guild/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(guildName) + queryString, null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the operation to complete and gets the result
        /// </summary>
        /// <param name="result">The async operation status</param>
        /// <returns>The guild's profile</returns>
        public Guild EndGetGuild(IAsyncResult result)
        {
            return EndRequest<Guild>(result);
        }

        /// <summary>
        /// Call back for the first step of the auction 2-step async request
        /// </summary>
        /// <param name="result">Async result of the get files operation</param>
        private void AuctionsFilesCallback(IAsyncResult result)
        {
            object[] state = (object[])result.AsyncState;
            ApiAsyncResult<AuctionDump> auctionsResult = (ApiAsyncResult<AuctionDump>)state[0];
            DateTime ifModifiedSince = (DateTime)state[1];
            AuctionFilesResponse files;
            try
            {
                files = EndRequest<AuctionFilesResponse>(result);
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, result.CompletedSynchronously);
                return;
            }
            if (files == null || files.Files == null || files.Files.Length == 0
                || string.IsNullOrEmpty(files.Files[files.Files.Length - 1].Url)
                || files.Files[0].LastModifiedUtc <= ifModifiedSince)
            {
                auctionsResult.SetComplete((AuctionDump)null, result.CompletedSynchronously);
                return;
            }
            try
            {
                Uri uri = new Uri(files.Files[files.Files.Length - 1].Url);
                BeginRequest<AuctionDump>(uri.AbsolutePath, null, this.AuctionsDumpCallback,
                    new object[] { auctionsResult, files.Files[0].LastModifiedUtc });
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, result.CompletedSynchronously);
                return;
            }
        }

        /// <summary>
        /// Delegate to execute the deserialization process asynchorounously
        /// </summary>
        /// <param name="result">The asnyc result</param>
        /// <returns>The delegate will return the auction dump</returns>
        private delegate AuctionDump EndAuctionRequestDelegate(IAsyncResult result);

        /// <summary>
        /// Call back for the second step of the auction 2-step async request
        /// </summary>
        /// <param name="result">Async result of the get dump operation</param>
        private void AuctionsDumpCallback(IAsyncResult result)
        {
            object[] state = (object[])result.AsyncState;
            ApiAsyncResult<AuctionDump> auctionsResult = (ApiAsyncResult<AuctionDump>)state[0];
            DateTime lastModified = (DateTime)state[1];

            try
            {
                // Since the result is usually very large amount of data, 
                // we execute the endrequest asynchronously in a threadpool thread because the deserialization can take sometime
                EndAuctionRequestDelegate endAuctionRequest = this.EndRequest<AuctionDump>;
                endAuctionRequest.BeginInvoke(result, DeserializeAuctionsCallback, new object[]
                    {
                        endAuctionRequest, auctionsResult, lastModified
                    });
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, true);
            }
        }

        /// <summary>
        /// Call back for the final step (deserialization of the result)
        /// </summary>
        /// <param name="result">Async result of the get dump operation</param>
        private void DeserializeAuctionsCallback(IAsyncResult result)
        {
            object[] state = (object[])result.AsyncState;
            EndAuctionRequestDelegate endAuctionRequest = (EndAuctionRequestDelegate)state[0];
            ApiAsyncResult<AuctionDump> auctionsResult = (ApiAsyncResult<AuctionDump>)state[1];
            DateTime lastModified = (DateTime)state[2];
            try
            {
                var dump = endAuctionRequest.EndInvoke(result);
#if SILVERLIGHT
                dump.LastModifiedUtc = lastModified;
#endif
                auctionsResult.SetComplete(dump, false);
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, false);
            }
        }

        /// <summary>
        /// Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm">Realm name</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetAuctionDump(string realm, AsyncCallback callback, object asyncState)
        {
            return BeginGetAuctionDump(realm, DateTime.MinValue, callback, asyncState);
        }

        /// <summary>
        /// Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm">Realm name</param>
        /// <param name="ifModifiedSince">The datetime of the lastModified header of the last auction dump.</param>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetAuctionDump(string realm, DateTime ifModifiedSince, AsyncCallback callback, object asyncState)
        {
            ApiAsyncResult<AuctionDump> auctionsResult = new ApiAsyncResult<AuctionDump>(callback, asyncState, this);
            BeginRequest<AuctionFilesResponse>("/api/wow/auction/data/" + GetRealmSlug(realm), null, this.AuctionsFilesCallback,
                new object[] { auctionsResult, ifModifiedSince });
            return auctionsResult;
        }

        /// <summary>
        /// Waits for the get auctions async operation to complete and returns the result
        /// </summary>
        /// <param name="result">Async result that holds the status of the async operation</param>
        /// <returns>The result of the operation or null if there are no new results</returns>
        public AuctionDump EndGetAuctionDump(IAsyncResult result)
        {
            ApiAsyncResult<AuctionDump> auctionsResult = (ApiAsyncResult<AuctionDump>)result;
            return auctionsResult.EndProcessing(this);
        }
        /// <summary>
        /// Begins an async operation to get an item information
        /// </summary>
        /// <param name="callback">Async callback</param>
        /// <param name="asyncState">The user defined state</param>
        /// <returns>the status of the async operation</returns>
        public IAsyncResult BeginGetItem(int itemId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<Item>("/api/wow/item/" + itemId.ToString(CultureInfo.InvariantCulture), null, null, null);
        }

        /// <summary>
        /// Waits for the get item operation to complete and returns the result
        /// </summary>
        /// <param name="result">Async result that holds the status of the async operation</param>
        /// <returns>The result of the operation</returns>
        public Item EndGetItem(IAsyncResult result)
        {
            return EndRequest<Item>(result);
        }

        /// <summary>
        /// Character classes cache
        /// </summary>
        private static readonly MemoryCache<string, ReadOnlyCollection<CharacterClass>> _classes = new MemoryCache<string, ReadOnlyCollection<CharacterClass>>();

        /// <summary>
        /// Begins getting class information asynchronously
        /// </summary>
        /// <param name="callback">async call back method</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetClasses(AsyncCallback callback, object asyncState)
        {
            ApiAsyncResult<ReadOnlyCollection<CharacterClass>> cacheResult = new ApiAsyncResult<ReadOnlyCollection<CharacterClass>>(callback, asyncState, this);
            var classes = _classes.LookupValue(this.Locale);
            if (classes != null)
            {
                cacheResult.SetComplete(classes, true);
                return cacheResult;
            }
            return BeginRequest<ClassesResponse>("/api/wow/data/character/classes", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the Get Classes operation to complete and returns the result
        /// </summary>
        /// <param name="result">The async operation state</param>
        /// <returns>The result of the GetClasses operation</returns>
        public IList<CharacterClass> EndGetClasses(IAsyncResult result)
        {
            ApiAsyncResult<ReadOnlyCollection<CharacterClass>> cacheResult = result as ApiAsyncResult<ReadOnlyCollection<CharacterClass>>;
            if (cacheResult != null)
            {
                return cacheResult.EndProcessing(this);
            }
            var res = this.EndRequest<ClassesResponse>(result).Classes.ToList().AsReadOnly();
            _classes.AddValue(this.Locale, res);
            return res;
        }

        /// <summary>
        /// Character Racees cache
        /// </summary>
        private static readonly MemoryCache<string, ReadOnlyCollection<CharacterRace>> _races = new MemoryCache<string, ReadOnlyCollection<CharacterRace>>();

        /// <summary>
        /// Begins getting Race information asynchronously
        /// </summary>
        /// <param name="callback">async call back method</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGetRaces(AsyncCallback callback, object asyncState)
        {
            var races = _races.LookupValue(this.Locale);
            if (races != null)
            {
                ApiAsyncResult<ReadOnlyCollection<CharacterRace>> result = new ApiAsyncResult<ReadOnlyCollection<CharacterRace>>(callback, asyncState, this);
                result.SetComplete(races, true);
                return result;
            }
            return BeginRequest<RacesResponse>("/api/wow/data/character/races", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the Get Racees operation to complete and returns the result
        /// </summary>
        /// <param name="result">The async operation state</param>
        /// <returns>The result of the GetRacees operation</returns>
        public IList<CharacterRace> EndGetRaces(IAsyncResult result)
        {
            ApiAsyncResult<ReadOnlyCollection<CharacterRace>> cacheResult = result as ApiAsyncResult<ReadOnlyCollection<CharacterRace>>;
            if (cacheResult != null)
            {
                return cacheResult.EndProcessing(this);
            }
            var res = this.EndRequest<RacesResponse>(result).Races.ToList().AsReadOnly();
            _races.AddValue(this.Locale, res);
            return res;
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve an arena team
        /// </summary>
        /// <param name="realm">Team's realm</param>
        /// <param name="name">Team name</param>
        /// <param name="teamSize">Team size</param>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetArenaTeam(string realm, string name, int teamSize, AsyncCallback callback, object asyncState)
        {
            string url = string.Format("/api/wow/arena/{0}/{2}v{2}/{1}",
                GetRealmSlug(realm), Uri.EscapeUriString(name), teamSize.ToString(CultureInfo.InvariantCulture));
            return BeginRequest<ArenaTeam>(url, null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get arena team operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>The arena team</returns>
        public ArenaTeam EndGetArenaTeam(IAsyncResult result)
        {
            return EndRequest<ArenaTeam>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve guild rewards
        /// </summary>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetGuildRewards(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<GuildRewardsResponse>("/api/wow/data/guild/rewards", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get guild rewards operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>All guild rewards</returns>
        public GuildRewardsResponse EndGetGuildRewards(IAsyncResult result)
        {
            return EndRequest<GuildRewardsResponse>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve guild perks
        /// </summary>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetGuildPerks(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<GuildPerksResponse>("/api/wow/data/guild/perks", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get guild rewards operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>All guild perks</returns>
        public GuildPerksResponse EndGetGuildPerks(IAsyncResult result)
        {
            return EndRequest<GuildPerksResponse>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to item category names (item classes)
        /// </summary>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetItemCategoryNames(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<ItemCategoryNamesResponse>("/api/wow/data/item/classes", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get item category names operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>All item category names</returns>
        public ItemCategoryNamesResponse EndGetItemCategoryNames(IAsyncResult result)
        {
            return EndRequest<ItemCategoryNamesResponse>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to character achievements
        /// </summary>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetCharacterAchievements(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<AchievementsResponse>("/api/wow/data/character/achievements", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get character achievements operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>All character achievements</returns>
        public AchievementsResponse EndGetCharacterAchievements(IAsyncResult result)
        {
            return EndRequest<AchievementsResponse>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to guild achievements
        /// </summary>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetGuildAchievements(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<AchievementsResponse>("/api/wow/data/guild/achievements", null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get guild achievements operation to complete and returns the result
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>All guild achievements</returns>
        public AchievementsResponse EndGetGuildAchievements(IAsyncResult result)
        {
            return EndRequest<AchievementsResponse>(result);
        }

        /// <summary>
        /// Begins an asynchronous operation to quest information
        /// </summary>
        /// <param name="questId">the quest id</param>
        /// <param name="callback">Async callback method</param>
        /// <param name="asyncState">User defined state</param>
        /// <returns>The state of the async operation</returns>
        public IAsyncResult BeginGetQuest(int questId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<Quest>("/api/wow/quest/" + questId.ToString(CultureInfo.InvariantCulture), null, callback, asyncState);
        }

        /// <summary>
        /// Waits for the get quest operation to complete and returns the quest information
        /// </summary>
        /// <param name="result">the state of the async operation</param>
        /// <returns>The quest information</returns>
        public Quest EndGetQuest(IAsyncResult result)
        {
            return EndRequest<Quest>(result);
        }

        /// <summary>
        /// Begins an async operation that Gets the top ranked arena teams from a battle group in a specified bracket
        /// </summary>
        /// <param name="battlegroupName">battlegroup name</param>
        /// <param name="teamSize">team size</param>
        /// <param name="numberOfTeamsToGet">Number of teams to get</param>
        /// <param name="callback">Callback to execute when operation is completed</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The state of the request</returns>
        public IAsyncResult BeginGetBattlegroupArenaTeams(string battlegroupName, int teamSize, int numberOfTeamsToGet, AsyncCallback callback, object asyncState)
        {
            string teamSizeS = teamSize.ToString(CultureInfo.InvariantCulture);
            return BeginRequest<ArenaTeamsResponse>("/api/wow/pvp/arena/" + GetRealmSlug(battlegroupName) +
                "/" + teamSizeS + "v" + teamSizeS + "?size=" +
                numberOfTeamsToGet.ToString(CultureInfo.InvariantCulture), null, callback, asyncState);
        }

        /// <summary>
        /// Waits for get arena teams request to complete and returns the result
        /// </summary>
        /// <param name="result">The status of the async request</param>
        /// <returns>the arena teams</returns>
        public ArenaTeamsResponse EndGetBattlegroupArenaTeams(IAsyncResult result)
        {
            return EndRequest<ArenaTeamsResponse>(result);
        }

        /// <summary>
        /// Begins an async operation that Gets a recipe information
        /// </summary>
        /// <param name="recipeId">the id for the recipe to fetch</param>
        /// <param name="callback">Callback to execute when operation is completed</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The state of the request</returns>
        public IAsyncResult BeginGetRecipe(int recipeId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<RecipeInfo>("/api/wow/recipe/" + recipeId.ToString(CultureInfo.InvariantCulture), null, callback, asyncState);
        }

        /// <summary>
        /// Waits for get recipe information request to complete and returns the result
        /// </summary>
        /// <param name="result">The status of the async request</param>
        /// <returns>Recipe information object</returns>
        public RecipeInfo EndGetRecipe(IAsyncResult result)
        {
            return EndRequest<RecipeInfo>(result);
        }
    }
}
