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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   ApiClient for World of WarCraft APIs
    /// </summary>
    public class WowClient : ApiClient
    {
        #region Constructors

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <remarks>
        ///   The default constructor will use the default region and locale determined by the current thread's culture.
        /// </remarks>
        public WowClient()
            : this((Region) null, null, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        public WowClient(Region region)
            : this(region, null, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        public WowClient(Region region, string locale)
            : this(region, locale, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        /// <param name="cacheManager"> Cache manager to cache data </param>
        public WowClient(Region region, string locale, ICacheManager cacheManager)
            : base(region, locale, cacheManager)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        public WowClient(ApiKeyPair apiKey)
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
        public WowClient(string region, ApiKeyPair apiKey, string locale)
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
        public WowClient(string region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager)
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
        public WowClient(Region region, ApiKeyPair apiKey, string locale, ICacheManager cacheManager)
            : base(region, apiKey, locale, cacheManager)
        {
        }

        #endregion Constructors

        #region Realms

        /// <summary>
        ///   const used to replace accented characters with non-accented ones
        /// </summary>
        private const string AccentedCharacters = "ÂâÄäÃãÁáÀàÊêËëÉéÈèÎîÏïÍíÌìÔôÖöÕõÓóÒòÛûÜüÚúÙùÑñÇç";

        /// <summary>
        ///   const used to replace accented characters with non-accented ones
        /// </summary>
        private const string ReplacedCharacters = "aaaaaaaaaaeeeeeeeeiiiiiiiioooooooooouuuuuuuunncc";

        /// <summary>
        ///   Get a realm or battleground slug
        /// </summary>
        /// <param name="identifier"> string </param>
        /// <returns> slug </returns>
        private static string GetSlug(string identifier)
        {
            var builder = new StringBuilder();
            bool dash = false;
            foreach (char ch in identifier)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    dash = false;
                    // String.Normalise is not available in Portable Libraries
                    int index = AccentedCharacters.IndexOf(ch);
                    builder.Append(index >= 0 ? ReplacedCharacters[index] : char.ToLowerInvariant(ch));
                }
                else if (ch == ' ' && !dash)
                {
                    dash = true;
                    builder.Append('-');
                }
            }
            return builder.ToString();
        }

        /// <summary>
        ///   Get the realm string to use in the Url for guild and character requests
        /// </summary>
        /// <param name="realmName"> Realm name </param>
        /// <returns> realm string to use in Url for guild and character requests </returns>
        public static string GetRealmSlug(string realmName)
        {
            return GetSlug(realmName);
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="callback"> call back method </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The status of the async operation </returns>
        public IAsyncResult BeginGetRealmStatus(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<RealmStatusResponse>("/api/wow/realm/status", null, callback, asyncState);
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="realms"> Realms to query </param>
        /// <param name="callback"> call back method </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The status of the async operation </returns>
        public IAsyncResult BeginGetRealmStatus(string[] realms, AsyncCallback callback, object asyncState)
        {
            if (realms == null || realms.Length == 0)
                return BeginGetRealmStatus(callback, asyncState);
            string queryString = "?realms=" + string.Join(",",
                                                          realms.Where(r => !string.IsNullOrEmpty(r)).Select(
                                                              GetRealmSlug).ToArray());
            return BeginRequest<RealmStatusResponse>("/api/wow/realm/status" + queryString, null, callback, asyncState);
        }

        /// <summary>
        ///   Waits the realm status operation to complete returns the results
        /// </summary>
        /// <param name="result"> The async result for operation </param>
        /// <returns> The result of the realm status operation </returns>
        public RealmStatusResponse EndGetRealmStatus(IAsyncResult result)
        {
            return EndRequest<RealmStatusResponse>(result);
        }

        /// <summary>
        ///   Get the realm status for specified realms in the region
        /// </summary>
        /// <param name="realms"> Realms to query </param>
        /// <returns> the realm status for all the realms in the region </returns>
        /// <remarks>
        ///   If invalid realms passed are not returned in the response but no error is thrown.
        /// </remarks>
        public RealmStatusResponse GetRealmStatus(params string[] realms)
        {
            IAsyncResult result = BeginGetRealmStatus(realms, null, null);
            return EndGetRealmStatus(result);
        }

        #endregion

        #region BattleGroups

        /// <summary>
        ///   Get the battle string to use in the Url for guild and character requests
        /// </summary>
        /// <param name="battleGroupName"> Battle Groups </param>
        /// <returns> battle string to use in Url for arena ladder </returns>
        public static string GetBattleGroupSlug(string battleGroupName)
        {
            return GetSlug(battleGroupName);
        }

        /// <summary>
        ///   Get the battlegroups for the region
        /// </summary>
        /// <param name="callback"> call back method </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The status of the async operation </returns>
        public IAsyncResult BeginGetBattleGroups(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<BattleGroupsResponse>("/api/wow/data/battlegroups/index", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits the battle groups operation to complete returns the results
        /// </summary>
        /// <param name="result"> The async result for operation </param>
        /// <returns> The result of the battlegroups status operation </returns>
        public BattleGroupsResponse EndGetBattleGroups(IAsyncResult result)
        {
            return EndRequest<BattleGroupsResponse>(result);
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region
        /// </summary>
        /// <returns> the realm status for all the realms in the region </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public BattleGroupsResponse GetBattleGroups()
        {
            IAsyncResult result = BeginGetBattleGroups(null, null);
            return EndGetBattleGroups(result);
        }

        #endregion

        #region Character

        /// <summary>
        ///   Get character profile information asynchronously
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="characterName"> character name </param>
        /// <param name="fieldsToRetrieve"> the profile fields to retrieve </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> The status of the async operation </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public IAsyncResult BeginGetCharacter(string realm, string characterName, CharacterFields fieldsToRetrieve,
                                              AsyncCallback callback, object asyncState)
        {
            string[] fields =
                EnumHelper<CharacterFields>.GetNames().Where(
                    name =>
                    name != "All" &&
                    (fieldsToRetrieve & (CharacterFields) Enum.Parse(typeof (CharacterFields), name, true)) != 0).Select
                    (name => char.ToLowerInvariant(name[0]) + name.Substring(1)).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return
                BeginRequest<Character>(
                    "/api/wow/character/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(characterName) + queryString,
                    null, callback, asyncState);
        }

        /// <summary>
        ///   Watis for the asynchronous and gets the character's profile
        /// </summary>
        /// <param name="result"> The async result for the operation </param>
        /// <returns> The character profile information </returns>
        public Character EndGetCharacter(IAsyncResult result)
        {
            return EndRequest<Character>(result);
        }

        /// <summary>
        ///   Get character profile information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="characterName"> character name </param>
        /// <returns> character profile information </returns>
        /// <remarks>
        ///   Only basic character information is returned
        /// </remarks>
        public Character GetCharacter(string realm, string characterName)
        {
            return GetCharacter(realm, characterName, CharacterFields.None);
        }

        /// <summary>
        ///   Get character profile information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="characterName"> character name </param>
        /// <param name="getAllFields"> If true all character information is returned, otherwise only basic information is returned </param>
        /// <returns> character profile information </returns>
        /// <remarks>
        ///   Only basic character information is returned
        /// </remarks>
        public Character GetCharacter(string realm, string characterName, bool getAllFields)
        {
            return GetCharacter(realm, characterName, getAllFields ? CharacterFields.All : CharacterFields.None);
        }

        /// <summary>
        ///   Get character profile information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="characterName"> character name </param>
        /// <param name="fieldsToRetrieve"> The profile fields to retrieve </param>
        /// <returns> character profile information </returns>
        public Character GetCharacter(string realm, string characterName, CharacterFields fieldsToRetrieve)
        {
            IAsyncResult result = BeginGetCharacter(realm, characterName, fieldsToRetrieve, null, null);
            return EndGetCharacter(result);
        }

        #endregion Character

        #region Guild

        /// <summary>
        ///   Gets guild information asynchronously
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="guildName"> guild name </param>
        /// <param name="fieldsToRetrieve"> the guild fields to retrieve </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> the status of the async operation </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public IAsyncResult BeginGetGuild(string realm, string guildName, GuildFields fieldsToRetrieve,
                                          AsyncCallback callback, object asyncState)
        {
            string[] fields =
                EnumHelper<GuildFields>.GetNames().Where(
                    name =>
                    name != "All" &&
                    (fieldsToRetrieve & (GuildFields) Enum.Parse(typeof (GuildFields), name, true)) != 0).Select(
                        name => name.ToLowerInvariant()).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return
                BeginRequest<Guild>(
                    "/api/wow/guild/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(guildName) + queryString, null,
                    callback, asyncState);
        }

        /// <summary>
        ///   Waits for the operation to complete and gets the result
        /// </summary>
        /// <param name="result"> The async operation status </param>
        /// <returns> The guild's profile </returns>
        public Guild EndGetGuild(IAsyncResult result)
        {
            return EndRequest<Guild>(result);
        }

        /// <summary>
        ///   Gets guild information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="guildName"> guild name </param>
        /// <returns> guild information </returns>
        /// <remarks>
        ///   Only basic guild information is returned
        /// </remarks>
        public Guild GetGuild(string realm, string guildName)
        {
            return GetGuild(realm, guildName, GuildFields.None);
        }

        /// <summary>
        ///   Gets guild information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="guildName"> guild name </param>
        /// <param name="getAllFields"> if true, all fields are returned, otherwise only basic information is returned </param>
        /// <returns> guild information </returns>
        /// <remarks>
        ///   returns guild information
        /// </remarks>
        public Guild GetGuild(string realm, string guildName, bool getAllFields)
        {
            return GetGuild(realm, guildName, getAllFields ? GuildFields.All : GuildFields.None);
        }

        /// <summary>
        ///   Gets guild information
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="guildName"> guild name </param>
        /// <param name="fieldsToRetrieve"> the guild fields to retrieve </param>
        /// <returns> guild information </returns>
        public Guild GetGuild(string realm, string guildName, GuildFields fieldsToRetrieve)
        {
            IAsyncResult result = BeginGetGuild(realm, guildName, fieldsToRetrieve, null, null);
            return EndGetGuild(result);
        }

        #endregion Guild

        #region AuctionHouse

        /// <summary>
        ///   Call back for the first step of the auction 2-step async request
        /// </summary>
        /// <param name="result"> Async result of the get files operation </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void AuctionsFilesCallback(IAsyncResult result)
        {
            var state = (object[]) result.AsyncState;
            var auctionsResult = (ApiAsyncResult<AuctionDump>) state[0];
            var ifModifiedSince = (DateTime) state[1];
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
            if (files == null || files.Files == null || files.Files.Count == 0
                || string.IsNullOrEmpty(files.Files[files.Files.Count - 1].Url)
                || files.Files[0].LastModifiedUtc <= ifModifiedSince)
            {
                auctionsResult.SetComplete((AuctionDump) null, result.CompletedSynchronously);
                return;
            }
            try
            {
                var uri = new Uri(files.Files[files.Files.Count - 1].Url);
                BeginRequest<AuctionDump>(uri.AbsolutePath, null, AuctionsDumpCallback,
                                          new object[] {auctionsResult, files.Files[0].LastModifiedUtc});
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, result.CompletedSynchronously);
            }
        }

        /// <summary>
        ///   Call back for the second step of the auction 2-step async request
        /// </summary>
        /// <param name="result"> Async result of the get dump operation </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void AuctionsDumpCallback(IAsyncResult result)
        {
            var state = (object[]) result.AsyncState;
            var auctionsResult = (ApiAsyncResult<AuctionDump>) state[0];
            var lastModified = (DateTime) state[1];

            try
            {
                // Since the result is usually very large amount of data, 
                // we execute the endrequest asynchronously in a threadpool thread because the deserialization can take sometime
                EndAuctionRequestDelegate endAuctionRequest = EndRequest<AuctionDump>;
                endAuctionRequest.BeginInvoke(result, DeserializeAuctionsCallback, new object[]
                                                                                       {
                                                                                           endAuctionRequest,
                                                                                           auctionsResult, lastModified
                                                                                       });
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, true);
            }
        }

        /// <summary>
        ///   Call back for the final step (deserialization of the result)
        /// </summary>
        /// <param name="result"> Async result of the get dump operation </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void DeserializeAuctionsCallback(IAsyncResult result)
        {
            var state = (object[]) result.AsyncState;
            var endAuctionRequest = (EndAuctionRequestDelegate) state[0];
            var auctionsResult = (ApiAsyncResult<AuctionDump>) state[1];
            var lastModified = (DateTime) state[2];
            try
            {
                var dump = endAuctionRequest.EndInvoke(result);
                dump.LastModifiedUtc = lastModified;
                auctionsResult.SetComplete(dump, false);
            }
            catch (Exception ex)
            {
                auctionsResult.SetComplete(ex, false);
            }
        }

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> Realm name </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> the status of the async operation </returns>
        public IAsyncResult BeginGetAuctionDump(string realm, AsyncCallback callback, object asyncState)
        {
            return BeginGetAuctionDump(realm, DateTime.MinValue, callback, asyncState);
        }

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> Realm name </param>
        /// <param name="ifModifiedSince"> The datetime of the lastModified header of the last auction dump. </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> the status of the async operation </returns>
        public IAsyncResult BeginGetAuctionDump(string realm, DateTime ifModifiedSince, AsyncCallback callback,
                                                object asyncState)
        {
            var auctionsResult = new ApiAsyncResult<AuctionDump>(callback, asyncState, this);
            BeginRequest<AuctionFilesResponse>("/api/wow/auction/data/" + GetRealmSlug(realm), null,
                                               AuctionsFilesCallback,
                                               new object[] {auctionsResult, ifModifiedSince});
            return auctionsResult;
        }

        /// <summary>
        ///   Waits for the get auctions async operation to complete and returns the result
        /// </summary>
        /// <param name="result"> Async result that holds the status of the async operation </param>
        /// <returns> The result of the operation or null if there are no new results </returns>
        public AuctionDump EndGetAuctionDump(IAsyncResult result)
        {
            var auctionsResult = (ApiAsyncResult<AuctionDump>) result;
            return auctionsResult.EndProcessing(this);
        }

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> realm to get auction house data for </param>
        /// <returns> The auction house dump for the specified realm </returns>
        public AuctionDump GetAuctionDump(string realm)
        {
            IAsyncResult result = BeginGetAuctionDump(realm, null, null);
            return EndGetAuctionDump(result);
        }

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> realm to get auction house data for </param>
        /// <param name="ifModifiedSince"> The datetime of the lastModified header of the last auction dump. </param>
        /// <returns> The auction house dump for the specified realm </returns>
        public AuctionDump GetAuctionDump(string realm, DateTime ifModifiedSince)
        {
            IAsyncResult result = BeginGetAuctionDump(realm, ifModifiedSince, null, null);
            return EndGetAuctionDump(result);
        }

        /// <summary>
        ///   Delegate to execute the deserialization process asynchorounously
        /// </summary>
        /// <param name="result"> The asnyc result </param>
        /// <returns> The delegate will return the auction dump </returns>
        private delegate AuctionDump EndAuctionRequestDelegate(IAsyncResult result);

        #endregion AuctionHouse

        #region Item Information

        #region Item

        /// <summary>
        ///   Begins an async operation to get an item information
        /// </summary>
        /// <param name="itemId"> item id </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> the status of the async operation </returns>
        public IAsyncResult BeginGetItem(int itemId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<Item>("/api/wow/item/" + itemId.ToString(CultureInfo.InvariantCulture), null, callback,
                                      asyncState);
        }

        /// <summary>
        ///   Waits for the get item operation to complete and returns the result
        /// </summary>
        /// <param name="result"> Async result that holds the status of the async operation </param>
        /// <returns> The result of the operation </returns>
        public Item EndGetItem(IAsyncResult result)
        {
            return EndRequest<Item>(result);
        }

        /// <summary>
        ///   Gets an item's information
        /// </summary>
        /// <param name="itemId"> the id of the item to fetch data for </param>
        /// <returns> The item information request </returns>
        public Item GetItem(int itemId)
        {
            IAsyncResult result = BeginGetItem(itemId, null, null);
            return EndGetItem(result);
        }

        #endregion Item

        #region ItemCategories

        /// <summary>
        ///   Begins an asynchronous operation to item category names (item classes)
        /// </summary>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetItemCategoryNames(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<ItemCategoryNamesResponse>("/api/wow/data/item/classes", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get item category names operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> All item category names </returns>
        public ItemCategoryNamesResponse EndGetItemCategoryNames(IAsyncResult result)
        {
            return EndRequest<ItemCategoryNamesResponse>(result);
        }

        /// <summary>
        ///   gets all item category names
        /// </summary>
        /// <returns> All item category names </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public ItemCategoryNamesResponse GetItemCategoryNames()
        {
            IAsyncResult result = BeginGetItemCategoryNames(null, null);
            return EndGetItemCategoryNames(result);
        }

        #endregion ItemCategories

        #region ItemSet

        /// <summary>
        ///   Begins an async operation to get an item set's information
        /// </summary>
        /// <param name="itemSetId"> the id of the item set </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> the status of the async operation </returns>
        public IAsyncResult BeginGetItemSet(int itemSetId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<ItemSet>("/api/wow/item/set/" + itemSetId.ToString(CultureInfo.InvariantCulture), null,
                                         callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get item set's operation to complete and returns the result
        /// </summary>
        /// <param name="result"> Async result that holds the status of the async operation </param>
        /// <returns> The result of the operation </returns>
        public ItemSet EndGetItemSet(IAsyncResult result)
        {
            return EndRequest<ItemSet>(result);
        }

        /// <summary>
        ///   Gets an item set's information
        /// </summary>
        /// <param name="itemSetId"> the id of the itemset to fetch data for </param>
        /// <returns> The item information request </returns>
        public ItemSet GetItemSet(int itemSetId)
        {
            IAsyncResult result = BeginGetItemSet(itemSetId, null, null);
            return EndGetItemSet(result);
        }

        #endregion ItemSet

        #endregion ItemInformation

        #region Class/Race Data

        /// <summary>
        ///   Character classes cache
        /// </summary>
        private static readonly MemoryCache<string, ReadOnlyCollection<CharacterClass>> _classes =
            new MemoryCache<string, ReadOnlyCollection<CharacterClass>>();

        /// <summary>
        ///   Character Racees cache
        /// </summary>
        private static readonly MemoryCache<string, ReadOnlyCollection<CharacterRace>> _races =
            new MemoryCache<string, ReadOnlyCollection<CharacterRace>>();

        /// <summary>
        ///   Begins getting class information asynchronously
        /// </summary>
        /// <param name="callback"> async call back method </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The status of the async operation </returns>
        public IAsyncResult BeginGetClasses(AsyncCallback callback, object asyncState)
        {
            var cacheResult = new ApiAsyncResult<ReadOnlyCollection<CharacterClass>>(callback, asyncState, this);
            var classes = _classes.LookupValue(Locale);
            if (classes != null)
            {
                cacheResult.SetComplete(classes, true);
                return cacheResult;
            }
            return BeginRequest<ClassesResponse>("/api/wow/data/character/classes", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the Get Classes operation to complete and returns the result
        /// </summary>
        /// <param name="result"> The async operation state </param>
        /// <returns> The result of the GetClasses operation </returns>
        public IList<CharacterClass> EndGetClasses(IAsyncResult result)
        {
            var cacheResult = result as ApiAsyncResult<ReadOnlyCollection<CharacterClass>>;
            if (cacheResult != null)
            {
                return cacheResult.EndProcessing(this);
            }
            var res = new ReadOnlyCollection<CharacterClass>(EndRequest<ClassesResponse>(result).Classes);
            _classes.AddValue(Locale, res);
            return res;
        }

        /// <summary>
        ///   Begins getting Race information asynchronously
        /// </summary>
        /// <param name="callback"> async call back method </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The status of the async operation </returns>
        public IAsyncResult BeginGetRaces(AsyncCallback callback, object asyncState)
        {
            var races = _races.LookupValue(Locale);
            if (races != null)
            {
                var result = new ApiAsyncResult<ReadOnlyCollection<CharacterRace>>(callback, asyncState, this);
                result.SetComplete(races, true);
                return result;
            }
            return BeginRequest<RacesResponse>("/api/wow/data/character/races", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the Get Racees operation to complete and returns the result
        /// </summary>
        /// <param name="result"> The async operation state </param>
        /// <returns> The result of the GetRacees operation </returns>
        public IList<CharacterRace> EndGetRaces(IAsyncResult result)
        {
            var cacheResult = result as ApiAsyncResult<ReadOnlyCollection<CharacterRace>>;
            if (cacheResult != null)
            {
                return cacheResult.EndProcessing(this);
            }
            var res = new ReadOnlyCollection<CharacterRace>(EndRequest<RacesResponse>(result).Races);
            _races.AddValue(Locale, res);
            return res;
        }

        /// <summary>
        ///   Gets information about character classes
        /// </summary>
        /// <returns> information about character classes </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IList<CharacterClass> GetClasses()
        {
            IAsyncResult result = BeginGetClasses(null, null);
            return EndGetClasses(result);
        }

        /// <summary>
        ///   Gets information about character races
        /// </summary>
        /// <returns> information about character classes </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IList<CharacterRace> GetRaces()
        {
            IAsyncResult result = BeginGetRaces(null, null);
            return EndGetRaces(result);
        }

        #endregion Class/Race Data

        #region PVP

        /// <summary>
        ///   Begins an async operation that gets the top ranked rated PVP players
        /// </summary>
        /// <param name="type">The PVP bracket to fetch</param>
        /// <param name="callback"> Callback to execute when operation is completed </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The state of the request </returns>
        public IAsyncResult BeginGetPvpLeaderboard(PvpBracket type, AsyncCallback callback, object asyncState)
        {
            string strType = EnumHelper<PvpBracket>.EnumToString(type);

            return BeginRequest<PvpLeaderboardResponse>("/api/wow/leaderboard/" + strType, null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for get PVP leader board to complete and returns the result
        /// </summary>
        /// <param name="result"> The status of the async request </param>
        /// <returns> the PVP leader board result </returns>
        public PvpLeaderboardResponse EndGetPvpLeaderboard(IAsyncResult result)
        {
            return EndRequest<PvpLeaderboardResponse>(result);
        }

        /// <summary>
        ///   Gets the top ranked PVP players
        /// </summary>
        /// <param name="type">the PVP bracket to fetch</param>
        /// <param name="numberOfRecordsToGet"> Number of records to get </param>
        /// <param name="page"> Page number to get (Starts at 1) </param>
        /// <param name="ascending"> Whether to sort result in asc order </param>
        /// <returns> the rated battleground ladder result </returns>
        public PvpLeaderboardResponse GetPvpLeaderboard(PvpBracket type)
        {
            var result = BeginGetPvpLeaderboard(type, null, null);
            return EndGetPvpLeaderboard(result);
        }

        
        
        #endregion PVP

        #region Guild Perks/Rewards

        /// <summary>
        ///   Begins an asynchronous operation to retrieve guild rewards
        /// </summary>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetGuildRewards(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<GuildRewardsResponse>("/api/wow/data/guild/rewards", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get guild rewards operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> All guild rewards </returns>
        public GuildRewardsResponse EndGetGuildRewards(IAsyncResult result)
        {
            return EndRequest<GuildRewardsResponse>(result);
        }

        /// <summary>
        ///   Begins an asynchronous operation to retrieve guild perks
        /// </summary>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetGuildPerks(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<GuildPerksResponse>("/api/wow/data/guild/perks", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get guild rewards operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> All guild perks </returns>
        public GuildPerksResponse EndGetGuildPerks(IAsyncResult result)
        {
            return EndRequest<GuildPerksResponse>(result);
        }

        /// <summary>
        ///   gets all guild rewards
        /// </summary>
        /// <returns> All guild rewards </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public GuildRewardsResponse GetGuildRewards()
        {
            IAsyncResult result = BeginGetGuildRewards(null, null);
            return EndGetGuildRewards(result);
        }

        /// <summary>
        ///   gets all guild perks
        /// </summary>
        /// <returns> All guild perks </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public GuildPerksResponse GetGuildPerks()
        {
            IAsyncResult result = BeginGetGuildPerks(null, null);
            return EndGetGuildPerks(result);
        }

        #endregion Guild Perks/Rewards

        #region Achievements

        /// <summary>
        ///   Begins an asynchronous operation to get information about an achievement
        /// </summary>
        /// <param name="achievementId"> achievement id </param>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetAchievement(int achievementId, AsyncCallback callback, object asyncState)
        {
            return
                BeginRequest<Achievement>(
                    "/api/wow/achievement/" + achievementId.ToString(CultureInfo.InvariantCulture), null, callback,
                    asyncState);
        }

        /// <summary>
        ///   Waits for the get achievement operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> the requested achievement </returns>
        public Achievement EndGetAchievement(IAsyncResult result)
        {
            return EndRequest<Achievement>(result);
        }

        /// <summary>
        ///   gets information about an achievement
        /// </summary>
        /// <param name="achievementId"> achievement id </param>
        public Achievement GetAchievement(int achievementId)
        {
            IAsyncResult result = BeginGetAchievement(achievementId, null, null);
            return EndGetAchievement(result);
        }

        /// <summary>
        ///   Begins an asynchronous operation to character achievements
        /// </summary>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetCharacterAchievements(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<AchievementsResponse>("/api/wow/data/character/achievements", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get character achievements operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> All character achievements </returns>
        public AchievementsResponse EndGetCharacterAchievements(IAsyncResult result)
        {
            return EndRequest<AchievementsResponse>(result);
        }

        /// <summary>
        ///   Begins an asynchronous operation to guild achievements
        /// </summary>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetGuildAchievements(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<AchievementsResponse>("/api/wow/data/guild/achievements", null, callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get guild achievements operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> All guild achievements </returns>
        public AchievementsResponse EndGetGuildAchievements(IAsyncResult result)
        {
            return EndRequest<AchievementsResponse>(result);
        }

        /// <summary>
        ///   gets all character achievements
        /// </summary>
        /// <returns> All character achievements </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public AchievementsResponse GetCharacterAchievements()
        {
            IAsyncResult result = BeginGetCharacterAchievements(null, null);
            return EndGetCharacterAchievements(result);
        }

        /// <summary>
        ///   gets all guild achievements
        /// </summary>
        /// <returns> All guild achievements </returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public AchievementsResponse GetGuildAchievements()
        {
            IAsyncResult result = BeginGetGuildAchievements(null, null);
            return EndGetGuildAchievements(result);
        }

        #endregion Achievements

        #region Quest

        /// <summary>
        ///   Begins an asynchronous operation to quest information
        /// </summary>
        /// <param name="questId"> the quest id </param>
        /// <param name="callback"> Async callback method </param>
        /// <param name="asyncState"> User defined state </param>
        /// <returns> The state of the async operation </returns>
        public IAsyncResult BeginGetQuest(int questId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<Quest>("/api/wow/quest/" + questId.ToString(CultureInfo.InvariantCulture), null,
                                       callback, asyncState);
        }

        /// <summary>
        ///   Waits for the get quest operation to complete and returns the quest information
        /// </summary>
        /// <param name="result"> the state of the async operation </param>
        /// <returns> The quest information </returns>
        public Quest EndGetQuest(IAsyncResult result)
        {
            return EndRequest<Quest>(result);
        }

        /// <summary>
        ///   gets a quest's information
        /// </summary>
        /// <param name="questId"> the quest id </param>
        /// <returns> The quest information </returns>
        public Quest GetQuest(int questId)
        {
            IAsyncResult result = BeginGetQuest(questId, null, null);
            return EndGetQuest(result);
        }

        #endregion Quest

        #region Recipe

        /// <summary>
        ///   Begins an async operation that Gets a recipe information
        /// </summary>
        /// <param name="recipeId"> the id for the recipe to fetch </param>
        /// <param name="callback"> Callback to execute when operation is completed </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The state of the request </returns>
        public IAsyncResult BeginGetRecipe(int recipeId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<RecipeInfo>("/api/wow/recipe/" + recipeId.ToString(CultureInfo.InvariantCulture), null,
                                            callback, asyncState);
        }

        /// <summary>
        ///   Waits for get recipe information request to complete and returns the result
        /// </summary>
        /// <param name="result"> The status of the async request </param>
        /// <returns> Recipe information object </returns>
        public RecipeInfo EndGetRecipe(IAsyncResult result)
        {
            return EndRequest<RecipeInfo>(result);
        }


        /// <summary>
        ///   Get Recipe information
        /// </summary>
        /// <param name="recipeId"> the id of the recipe to get </param>
        /// <returns> Recipe information </returns>
        public RecipeInfo GetRecipe(int recipeId)
        {
            IAsyncResult result = BeginGetRecipe(recipeId, null, null);
            return EndGetRecipe(result);
        }

        #endregion Recipe

        #region Challenges

        /// <summary>
        ///   begins an async operation to get the leaders for realm.
        /// </summary>
        /// <param name="realmName"> realm name to get leaders for. If realm is null or empty string, the leaders for the reason are returned. </param>
        /// <param name="callback"> call back to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> Async operation status </returns>
        public IAsyncResult BeginGetChallengeLeaders(string realmName, AsyncCallback callback, object asyncState)
        {
            if (string.IsNullOrEmpty(realmName))
            {
                realmName = "region";
            }
            return BeginRequest<ChallengesResponse>("/api/wow/challenge/" + GetRealmSlug(realmName), null, callback,
                                                    asyncState);
        }

        /// <summary>
        ///   waits for the get challenge leaders operation to complete and returns the result
        /// </summary>
        /// <param name="result"> the status of the async operation </param>
        /// <returns> the result of the operation </returns>
        public ChallengesResponse EndGetChallengeLeaders(IAsyncResult result)
        {
            return EndRequest<ChallengesResponse>(result);
        }

        /// <summary>
        ///   get challenge leaders
        /// </summary>
        /// <param name="realmName"> realm name to get leaders for. If realm is null or empty string, the leaders for the reason are returned. </param>
        /// <returns> the result of the operation </returns>
        public ChallengesResponse GetChallengeLeaders(string realmName)
        {
            IAsyncResult result = BeginGetChallengeLeaders(realmName, null, null);
            return EndGetChallengeLeaders(result);
        }

        #endregion Challenges

        #region BattlePets

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet abilities
        /// </summary>
        /// <param name="abilityId"> id of ability to retrieve </param>
        /// <param name="callback"> call back to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> Async operation status </returns>
        public IAsyncResult BeginGetBattlePetAbility(int abilityId, AsyncCallback callback, object asyncState)
        {
            return
                BeginRequest<BattlePetAbility>(
                    "/api/wow/battlePet/ability/" + abilityId.ToString(CultureInfo.InvariantCulture), null, callback,
                    asyncState);
        }

        /// <summary>
        ///   Waits for the BeginGetBattlePetAbility to complete and returns the result of the operation
        /// </summary>
        /// <param name="result"> async operation status </param>
        /// <returns> Information about the ability </returns>
        public BattlePetAbility EndGetBattlePetAbility(IAsyncResult result)
        {
            return EndRequest<BattlePetAbility>(result);
        }

        /// <summary>
        ///   Gets information about a battle pet ability
        /// </summary>
        /// <param name="abilityId"> id of ability to retrieve </param>
        /// <returns> Information about the ability </returns>
        public BattlePetAbility GetBattlePetAbility(int abilityId)
        {
            IAsyncResult result = BeginGetBattlePetAbility(abilityId, null, null);
            return EndGetBattlePetAbility(result);
        }

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet species
        /// </summary>
        /// <param name="speciesId"> id of species to retrieve </param>
        /// <param name="callback"> call back to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> Async operation status </returns>
        public IAsyncResult BeginGetBattlePetSpecies(int speciesId, AsyncCallback callback, object asyncState)
        {
            return
                BeginRequest<BattlePetSpecies>(
                    "/api/wow/battlePet/species/" + speciesId.ToString(CultureInfo.InvariantCulture), null, callback,
                    asyncState);
        }

        /// <summary>
        ///   Waits for the BeginGetBattlePetSpecies to complete and returns the result of the operation
        /// </summary>
        /// <param name="result"> async species status </param>
        /// <returns> Information about the ability </returns>
        public BattlePetSpecies EndGetBattlePetSpecies(IAsyncResult result)
        {
            return EndRequest<BattlePetSpecies>(result);
        }

        /// <summary>
        ///   Gets information about a battle pet species
        /// </summary>
        /// <param name="speciesId"> id of ability to retrieve </param>
        /// <returns> Information about the species </returns>
        public BattlePetSpecies GetBattlePetSpecies(int speciesId)
        {
            IAsyncResult result = BeginGetBattlePetSpecies(speciesId, null, null);
            return EndGetBattlePetSpecies(result);
        }

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet types
        /// </summary>
        /// <param name="callback"> call back to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> Async operation status </returns>
        public IAsyncResult BeginGetBattlePetTypes(AsyncCallback callback, object asyncState)
        {
            return
                BeginRequest<BattlePetTypesResponse>(
                    "/api/wow/data/pet/types", null, callback,
                    asyncState);
        }

        /// <summary>
        ///   Waits for the BeginGetBattlePetTypes to complete and returns the result of the operation
        /// </summary>
        /// <param name="result"> async species status </param>
        /// <returns> Information about the pet types </returns>
        public BattlePetTypesResponse EndGetBattlePetTypes(IAsyncResult result)
        {
            return EndRequest<BattlePetTypesResponse>(result);
        }

        /// <summary>
        ///   Gets information about a battle pet types
        /// </summary>
        /// <returns> Information about the pet types </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public BattlePetTypesResponse GetBattlePetTypes()
        {
            IAsyncResult result = BeginGetBattlePetTypes(null, null);
            return EndGetBattlePetTypes(result);
        }

        #endregion

        #region Spells and Talents

        /// <summary>
        ///   begins an async operation to retrieve information about a spell
        /// </summary>
        /// <param name="spellId"> spell id </param>
        /// <param name="callback"> method to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> async operation result </returns>
        public IAsyncResult BeginGetSpell(int spellId, AsyncCallback callback, object asyncState)
        {
            return BeginRequest<Spell>("/api/wow/spell/" + spellId.ToString(CultureInfo.InvariantCulture), null,
                                       callback,
                                       asyncState);
        }

        /// <summary>
        ///   waits for the get spell async operation to complete the return the result
        /// </summary>
        /// <param name="result"> async operation result returned by BeginGetSpell </param>
        /// <returns> spell information </returns>
        public Spell EndGetSpell(IAsyncResult result)
        {
            return EndRequest<Spell>(result);
        }

        /// <summary>
        ///   gets information about a spell
        /// </summary>
        /// <param name="spellId"> spell id </param>
        /// <returns> spell information </returns>
        public Spell GetSpell(int spellId)
        {
            IAsyncResult result = BeginGetSpell(spellId, null, null);
            return EndGetSpell(result);
        }

        /// <summary>
        ///   begins an async operation to retrieve information about class talents
        /// </summary>
        /// <param name="callback"> method to call when operation is complete </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> async operation result </returns>
        public IAsyncResult BeginGetTalents(AsyncCallback callback, object asyncState)
        {
            return BeginRequest<TalentsResponse>("/api/wow/data/talents", null, callback,
                                                 asyncState);
        }

        /// <summary>
        ///   waits for the get spell async operation to complete the return the result
        /// </summary>
        /// <param name="result"> async operation result returned by BeginGetSpell </param>
        /// <returns> talents information </returns>
        public TalentsResponse EndGetTalents(IAsyncResult result)
        {
            return EndRequest<TalentsResponse>(result);
        }

        /// <summary>
        ///   gets information about all class talents
        /// </summary>
        /// <returns> talents information </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public TalentsResponse GetTalents()
        {
            IAsyncResult result = BeginGetTalents(null, null);
            return EndGetTalents(result);
        }

        #endregion Spells and Talents
    }
}