using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="apiKey"> Application key used to authenticate requests sent by the ApiClient </param>
        /// <param name="locale"> The locale to use to perform request (item names, class names, etc are retrieved in the locale specified) </param>
        /// <remarks>
        ///   Only Locales supported by the regional website that the ApiClient is connecting to are supported. If a wrong local is passed, default language is used.
        /// </remarks>
        public WowClient(string region, string locale, string apiKey)
            : this(Region.GetRegion(region), locale, apiKey, null)
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
        public WowClient(string region, string locale, string apiKey, ICacheManager cacheManager)
            : this(Region.GetRegion(region), locale, apiKey, cacheManager)
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
        public WowClient(Region region, string locale, string apiKey, ICacheManager cacheManager)
            : base(region, locale, apiKey, cacheManager)
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
        /// <returns> The status of the async operation </returns>
        public Task<RealmStatusResponse> GetRealmStatusAsync()
        {
            return GetAsync<RealmStatusResponse>("/wow/realm/status", null);
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="realms"> Realms to query </param>
        /// <returns> The status of the async operation </returns>
        public Task<RealmStatusResponse> GetRealmStatusAsync(string[] realms)
        {
			if (realms == null || realms.Length == 0)
			{
				return GetRealmStatusAsync();
			}

            string queryString = "?realms=" +
				string.Join(",", realms.Where(r => !string.IsNullOrEmpty(r)).Select(GetRealmSlug).ToArray());

            return GetAsync<RealmStatusResponse>("/wow/realm/status" + queryString, null);
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
        /// <returns> The status of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<BattleGroupsResponse> GetBattleGroupsAsync()
        {
            return GetAsync<BattleGroupsResponse>("/wow/data/battlegroups/index", null);
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
        public Task<Character> GetCharacterAsync(string realm, string characterName, CharacterFields fieldsToRetrieve)
        {
            string[] fields = EnumHelper<CharacterFields>.GetNames().Where(
                    name => name != "All" &&
                    (fieldsToRetrieve & (CharacterFields) Enum.Parse(typeof (CharacterFields), name, true)) != 0).Select
                    (name => char.ToLowerInvariant(name[0]) + name.Substring(1)).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return GetAsync<Character>(
                    "/wow/character/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(characterName) + queryString,
                    null);
        }

        #endregion Character

        #region Guild

        /// <summary>
        ///   Gets guild information asynchronously
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="guildName"> guild name </param>
        /// <param name="fieldsToRetrieve"> the guild fields to retrieve </param>
        /// <returns> the status of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public Task<Guild> GetGuildAsync(string realm, string guildName, GuildFields fieldsToRetrieve)
        {
            string[] fields =
                EnumHelper<GuildFields>.GetNames().Where(
                    name =>
                    name != "All" &&
                    (fieldsToRetrieve & (GuildFields) Enum.Parse(typeof (GuildFields), name, true)) != 0).Select(
                        name => name.ToLowerInvariant()).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return GetAsync<Guild>(
                    "/wow/guild/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(guildName) + queryString, null);
        }

        #endregion Guild

        #region AuctionHouse

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> Realm name </param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns> the async task </returns>
        public Task<AuctionDump> GetAuctionDumpAsync(string realm)
        {
            return GetAuctionDumpAsync(realm, DateTime.MinValue);
        }

        /// <summary>
        ///   Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm"> Realm name </param>
        /// <param name="ifModifiedSince"> The datetime of the lastModified header of the last auction dump. </param>
        /// <returns> the async task</returns>
        public async Task<AuctionDump> GetAuctionDumpAsync(string realm, DateTime ifModifiedSince)
        {
            var files = await GetAsync<AuctionFilesResponse>("/wow/auction/data/" + GetRealmSlug(realm), null);
            if (files == null || files.Files == null || files.Files.Count == 0
                || string.IsNullOrEmpty(files.Files[files.Files.Count - 1].DownloadPath)
                || files.Files[0].LastModifiedUtc <= ifModifiedSince)
            {
                return null;
            }
            var dump = await GetAsync<AuctionDump>(new Uri(files.Files[0].DownloadPath).AbsolutePath, null);
            return dump;
        }

        #endregion AuctionHouse

        #region Item Information

        #region Item

        /// <summary>
        ///   Begins an async operation to get an item information
        /// </summary>
        /// <param name="itemId"> item id </param>
        /// <returns> the status of the async operation </returns>
        public Task<Item> GetItemAsync(int itemId)
        {
            return GetAsync<Item>("/wow/item/" + itemId.ToString(CultureInfo.InvariantCulture), null);
        }

        #endregion Item

        #region ItemCategories

        /// <summary>
        ///   Begins an asynchronous operation to item category names (item classes)
        /// </summary>
        /// <returns> The state of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<ItemCategoryNamesResponse> GetItemCategoryNamesAsync()
        {
            return GetAsync<ItemCategoryNamesResponse>("/wow/data/item/classes", null);
        }

        #endregion ItemCategories

        #region ItemSet

        /// <summary>
        ///   Begins an async operation to get an item set's information
        /// </summary>
        /// <param name="itemSetId"> the id of the item set </param>
        /// <returns> the status of the async operation </returns>
        public Task<ItemSet> GetItemSetAsync(int itemSetId)
        {
            return GetAsync<ItemSet>("/wow/item/set/" + itemSetId.ToString(CultureInfo.InvariantCulture), null);
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
        ///   getting class information asynchronously
        /// </summary>
        /// <returns> The status of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public async Task<IList<CharacterClass>> GetClassesAsync()
        {
            var classes = _classes.LookupValue(Locale);
            if (classes != null)
            {
                return classes;
            }
            var classesResponse = await GetAsync<ClassesResponse>("/wow/data/character/classes", null);
            classes = new ReadOnlyCollection<CharacterClass>(classesResponse.Classes);
            _classes.AddValue(Locale, classes);
            return classes;
        }

        /// <summary>
        ///   getting Race information asynchronously
        /// </summary>
        /// <returns> The status of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public async Task<IList<CharacterRace>> GetRacesAsync()
        {
            var races = _races.LookupValue(Locale);
            if (races != null)
            {
                return races;
            }
            var racesResponse = await GetAsync<RacesResponse>("/wow/data/character/races", null);
            races = new ReadOnlyCollection<CharacterRace>(racesResponse.Races);
            _races.AddValue(Locale, races);
            return races;
        }

        #endregion Class/Race Data

        #region PVP

        /// <summary>
        ///   Begins an async operation that gets the top ranked rated PVP players
        /// </summary>
        /// <param name="type">The PVP bracket to fetch</param>
        /// <returns> The state of the request </returns>
        public Task<PvpLeaderboardResponse> GetPvpLeaderboardAsync(PvpBracket type)
        {
            string strType = EnumHelper<PvpBracket>.EnumToString(type);
            return GetAsync<PvpLeaderboardResponse>("/wow/leaderboard/" + strType, null);
        }

        #endregion PVP

        #region Guild Perks/Rewards

        /// <summary>
        ///   Begins an asynchronous operation to retrieve guild rewards
        /// </summary>
        /// <returns> The state of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<GuildRewardsResponse> GetGuildRewardsAsync()
        {
            return GetAsync<GuildRewardsResponse>("/wow/data/guild/rewards", null);
        }

        /// <summary>
        ///   Begins an asynchronous operation to retrieve guild perks
        /// </summary>
        /// <returns> The state of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<GuildPerksResponse> GetGuildPerksAsync()
        {
            return GetAsync<GuildPerksResponse>("/wow/data/guild/perks", null);
        }

        #endregion Guild Perks/Rewards

        #region Achievements

        /// <summary>
        ///   Begins an asynchronous operation to get information about an achievement
        /// </summary>
        /// <param name="achievementId"> achievement id </param>
        /// <returns> The state of the async operation </returns>
        public Task<Achievement> GetAchievementAsync(int achievementId)
        {
            return GetAsync<Achievement>("/wow/achievement/" + achievementId.ToString(CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        ///   Begins an asynchronous operation to character achievements
        /// </summary>
        /// <returns> The state of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<AchievementsResponse> GetCharacterAchievementsAsync()
        {
            return GetAsync<AchievementsResponse>("/wow/data/character/achievements", null);
        }

        
        /// <summary>
        ///   Begins an asynchronous operation to guild achievements
        /// </summary>
        /// <returns> The state of the async operation </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<AchievementsResponse> GetGuildAchievementsAsync()
        {
            return GetAsync<AchievementsResponse>("/wow/data/guild/achievements", null);
        }

        #endregion Achievements

        #region Quest

        /// <summary>
        ///   Begins an asynchronous operation to quest information
        /// </summary>
        /// <param name="questId"> the quest id </param>
        /// <returns> The state of the async operation </returns>
        public Task<Quest> GetQuestAsync(int questId)
        {
            return GetAsync<Quest>("/wow/quest/" + questId.ToString(CultureInfo.InvariantCulture), null);
        }

        #endregion Quest

        #region Recipe

        /// <summary>
        ///   Begins an async operation that Gets a recipe information
        /// </summary>
        /// <param name="recipeId"> the id for the recipe to fetch </param>
        /// <returns> The state of the request </returns>
        public Task<RecipeInfo> GetRecipeAsync(int recipeId)
        {
            return GetAsync<RecipeInfo>("/wow/recipe/" + recipeId.ToString(CultureInfo.InvariantCulture), null);
        }

        #endregion Recipe

        #region Challenges

        /// <summary>
        ///   begins an async operation to get the leaders for realm.
        /// </summary>
        /// <param name="realmName"> realm name to get leaders for. If realm is null or empty string, the leaders for the reason are returned. </param>
        /// <returns> Async operation status </returns>
        public Task<ChallengesResponse> GetChallengeLeadersAsync(string realmName)
        {
			string slug;

            if (string.IsNullOrEmpty(realmName))
            {
				slug = GetRealmSlug("region");
            }
			else
			{
				slug = GetRealmSlug(realmName);
			}

            return GetAsync<ChallengesResponse>("/wow/challenge/" + slug, null);
        }

        #endregion Challenges

        #region BattlePets

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet abilities
        /// </summary>
        /// <param name="abilityId"> id of ability to retrieve </param>
        /// <returns> Async operation status </returns>
        public Task<BattlePetAbility> GetBattlePetAbilityAsync(int abilityId)
        {
            return GetAsync<BattlePetAbility>("/wow/battlePet/ability/" + abilityId.ToString(CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet species
        /// </summary>
        /// <param name="speciesId"> id of species to retrieve </param>
        /// <returns> Async operation status </returns>
        public Task<BattlePetSpecies> GetBattlePetSpeciesAsync(int speciesId)
        {
            return GetAsync<BattlePetSpecies>("/wow/battlePet/species/" + speciesId.ToString(CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        ///   Begins an async operation to retrieve information about battle pet types
        /// </summary>
        /// <returns> Async operation status </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<BattlePetTypesResponse> GetBattlePetTypesAsync()
        {
            return GetAsync<BattlePetTypesResponse>("/wow/data/pet/types", null);
        }

        #endregion

        #region Spells and Talents

        /// <summary>
        ///   begins an async operation to retrieve information about a spell
        /// </summary>
        /// <param name="spellId"> spell id </param>
        /// <returns> async operation result </returns>
        public Task<Spell> GetSpellAsync(int spellId)
        {
            return GetAsync<Spell>("/wow/spell/" + spellId.ToString(CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        ///   begins an async operation to retrieve information about class talents
        /// </summary>
        /// <returns> async operation result </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Task<TalentsResponse> GetTalentsAsync()
        {
            return GetAsync<TalentsResponse>("/wow/data/talents", null);
        }

		#endregion Spells and Talents

		/// <summary>
		///   Refreshes object data from server
		/// </summary>
		public Task RefreshAsync()
		{
			return RefreshAsync(this, false);
		}
	}
}