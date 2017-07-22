using System;
using System.Globalization;
using System.Threading.Tasks;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Diablo 3 Web API client
	/// </summary>
	public class DiabloClient : ApiClient
    {
        #region Constructors

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <remarks>
        ///   The default constructor will use the default region and locale determined by the current thread's culture.
        /// </remarks>
        public DiabloClient()
            : this(null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        public DiabloClient(Region region)
            : this(region, null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        public DiabloClient(Region region, string locale)
            : this(region, locale, (ICacheManager) null)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of the ApiClient class
        /// </summary>
        /// <param name="region"> Regional battle.net Community website to which the ApiClient should connect to perform request. </param>
        /// <param name="locale"> the locale to use for retrieving data </param>
        /// <param name="cacheManager"> Cache manager to cache data </param>
        public DiabloClient(Region region, string locale, ICacheManager cacheManager)
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
        public DiabloClient(string region, string locale, string apiKey)
            : this(Region.GetRegion(region), locale, apiKey, null)
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
		public DiabloClient(Region region, string locale, string apiKey)
			: this(region, locale, apiKey, null)
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
		public DiabloClient(string region, string locale, string apiKey, ICacheManager cacheManager)
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
        public DiabloClient(Region region, string locale, string apiKey, ICacheManager cacheManager)
            : base(region, locale, apiKey, cacheManager)
        {
        }

        #endregion Constructors

        /// <summary>
        /// Parses battle tag and returns battleTagName and battleTagCode
        /// </summary>
        /// <param name="battleTag">battle tag</param>
        /// <param name="battleTagName">battle tag name</param>
        /// <param name="battleTagCode">battle tag code</param>
        private static void ParseBattleTag(string battleTag, out string battleTagName, out int battleTagCode)
        {
			int hashIndex = battleTag.IndexOf('#');

			if (string.IsNullOrWhiteSpace(battleTag) || hashIndex <= 0 || hashIndex == (battleTag.Length - 1))
			{
				throw new ArgumentException(ErrorMessages.InvalidBattleTag, "battleTag");
			}

            battleTagName = battleTag.Substring(0, hashIndex);
            string battleTagCodeStr = battleTag.Substring(hashIndex + 1);

            if (!int.TryParse(battleTagCodeStr, NumberStyles.None, CultureInfo.InvariantCulture, out battleTagCode))
            {
                throw new ArgumentException(ErrorMessages.InvalidBattleTag, "battleTag");
            }
        }

        /// <summary>
        /// Starts an asynchronous operation to return the diablo career profile for a battle-tag
        /// </summary>
        /// <param name="battleTag">battleTag in the form of battleTagName#battleTagCode</param>
        /// <returns>status of async operation</returns>
        public Task<DiabloProfile> GetProfileAsync(string battleTag)
        {
            string battleTagName;
            int battleTagCode;
            ParseBattleTag(battleTag, out battleTagName, out battleTagCode);
            return GetProfileAsync(battleTagName, battleTagCode);
        }

        /// <summary>
        /// Starts an asynchronous operation to return the diablo career profile for a battle-tag
        /// </summary>
        /// <param name="battleTagName">battle tag name</param>
        /// <param name="battleTagCode">battle tag code</param>
        /// <returns>status of async operation</returns>
        public Task<DiabloProfile> GetProfileAsync(string battleTagName, int battleTagCode)
        {
            string path = "/d3/profile/" + battleTagName + "-" + battleTagCode.ToString(CultureInfo.InvariantCulture) + "/";
            return GetAsync<DiabloProfile>(path, null);
        }

        /// <summary>
        /// Starts an asynchronous operation to return the diablo career profile for a battle-tag
        /// </summary>
        /// <param name="battleTag">battleTag in the form of battleTagName#battleTagCode</param>
        /// <param name="heroId">hero id</param>
        /// <returns>status of async operation</returns>
        public Task<Hero> GetHeroAsync(string battleTag, long heroId)
        {
            string battleTagName;
            int battleTagCode;
            ParseBattleTag(battleTag, out battleTagName, out battleTagCode);
            return GetHeroAsync(battleTagName, battleTagCode, heroId);
        }

        /// <summary>
        /// Starts an asynchronous operation to return the diablo hero profile for a battle-tag and hero id
        /// </summary>
        /// <param name="battleTagName">battle tag name</param>
        /// <param name="battleTagCode">battle tag code</param>
        /// <param name="heroId">hero id</param>
        /// <returns>status of async operation</returns>
        public Task<Hero> GetHeroAsync(string battleTagName, int battleTagCode, long heroId)
        {
            string path = "/d3/profile/" + battleTagName + "-" + battleTagCode.ToString(CultureInfo.InvariantCulture) + "/hero/" + heroId.ToString(CultureInfo.InvariantCulture);
            return GetAsync<Hero>(path, null);
        }

        /// <summary>
        /// Starts an asyncronous operation to get item data
        /// </summary>
        /// <param name="itemData">Item data as returned by tooltip parameters in item collection of GetHero api</param>
        /// <returns>Status of async operation</returns>
        public Task<Item> GetItemAsync(string itemData)
        {
            string path = "/d3/data/" + itemData;
            return GetAsync<Item>(path, null);
        }

        /// <summary>
        /// Starts an asynchronous operation to get artisan data
        /// </summary>
        /// <param name="artisanType">artisan type</param>
        /// <returns>Status of async operation</returns>
        public Task<ArtisanInfo> GetArtisanInfoAsync(ArtisanType artisanType)
        {
            string path = "/d3/data/artisan/" + EnumHelper<ArtisanType>.EnumToString(artisanType);
            return GetAsync<ArtisanInfo>(path, null);
        }

        /// <summary>
        /// Starts an asynchronous operation to get follower data
        /// </summary>
        /// <param name="followerType">follower type</param>
        /// <returns>Status of async operation</returns>
        public Task<Follower> GetFollowerInfoAsync(FollowerType followerType)
        {
            string path = "/d3/data/follower/" + EnumHelper<FollowerType>.EnumToString(followerType);
            return GetAsync<Follower>(path, null);
        }
    }
}
