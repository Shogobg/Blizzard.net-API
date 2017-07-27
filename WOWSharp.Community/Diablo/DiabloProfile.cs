
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A battle.net account diablo profile
	/// </summary>
	[DataContract]
    public class DiabloProfile : ApiResponse
    {
        /// <summary>
        /// The profiles battle tag. Will have the format of Name#0000, 
        /// where Name is the battle tag and 0000 is the unique number used to differentiate profiles with same name
        /// </summary>
        [DataMember(Name = "battleTag", IsRequired = true)]
        public string BattleTag
        {
            get;
            internal set;
        }

		/// <summary>
		/// Profiles normal mode paragon level
		/// </summary>
		[DataMember(Name = "paragonLevel", IsRequired = true)]
		public int ParagonLevel
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profiles hardcore mode paragon level
		/// </summary>
		[DataMember(Name = "paragonLevelHardcore", IsRequired = true)]
		public int ParagonLevelHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profiles normal mode paragon level - this season
		/// </summary>
		[DataMember(Name = "paragonLevelSeason", IsRequired = true)]
		public int ParagonLevelSeason
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profiles hardcore mode paragon level - this season
		/// </summary>
		[DataMember(Name = "paragonLevelSeasonHardcore", IsRequired = true)]
		public int ParagonLevelSeasonHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// Guild name
		/// </summary>
		[DataMember(Name = "guildName", IsRequired = true)]
		public string GuildName
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profile's Heroes
		/// </summary>
		[DataMember(Name = "heroes", IsRequired = false)]
		public IList<Hero> Heroes
		{
			get;
			internal set;
		}

		/// <summary>
		/// Id of the last hero played
		/// </summary>
		[DataMember(Name = "lastHeroPlayed", IsRequired = false)]
		public long LastHeroPlayedId
		{
			get;
			internal set;
		}

		/// <summary>
		/// Last updated date in UTC
		/// </summary>
		[DataMember(Name = "lastUpdated", IsRequired = false)]
		[JsonConverter(typeof(DateTimeSecondsConverter))]
		public DateTime LastUpdatedUtc
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profile kill statistics
		/// </summary>
		[DataMember(Name = "kills", IsRequired = false)]
		public KillStatistics Kills
		{
			get;
			internal set;
		}

		/// <summary>
		/// Highest level achieved in hardcore mode
		/// </summary>
		[DataMember(Name = "highestHardcoreLevel", IsRequired = false)]
		public int HighestHardcoreLevel
		{
			get;
			internal set;
		}

		/// <summary>
		/// Time played statistics
		/// </summary>
		[DataMember(Name = "timePlayed", IsRequired = false)]
		public TimePlayedStatistics TimePlayed
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profiles progression
		/// </summary>
		[DataMember(Name = "progression", IsRequired = false)]
        public ProfileProgression Progression
        {
            get;
            internal set;
        }

        /// <summary>
        /// Profile's fallen hardcore Heroes
        /// </summary>
        [DataMember(Name = "fallenHeroes", IsRequired = false)]
        public IList<Hero> FallenHeroes
        {
            get;
            internal set;
        }



		// Artisans
		/// <summary>
		/// Blacksmith artisan stats
		/// </summary>
		[DataMember(Name = "blacksmith", IsRequired = false)]
		public ProfileArtisanInfo Blacksmith
		{
			get;
			internal set;
		}

		/// <summary>
		/// Jeweler artisan stats
		/// </summary>
		[DataMember(Name = "jeweler", IsRequired = false)]
		public ProfileArtisanInfo Jeweler
		{
			get;
			internal set;
		}

		/// <summary>
		/// Mystic artisan stats
		/// </summary>
		[DataMember(Name = "mystic", IsRequired = false)]
		public ProfileArtisanInfo Mystic
		{
			get;
			internal set;
		}

		/// <summary>
		/// BlacksmithHardcore artisan stats
		/// </summary>
		[DataMember(Name = "blacksmithHardcore", IsRequired = false)]
		public ProfileArtisanInfo BlacksmithHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// JewelerHardcore artisan stats
		/// </summary>
		[DataMember(Name = "jewelerHardcore", IsRequired = false)]
		public ProfileArtisanInfo JewelerHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// MysticHardcore artisan stats
		/// </summary>
		[DataMember(Name = "mysticHardcore", IsRequired = false)]
		public ProfileArtisanInfo MysticHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// BlacksmithSeason artisan stats
		/// </summary>
		[DataMember(Name = "blacksmithSeason", IsRequired = false)]
		public ProfileArtisanInfo BlacksmithSeason
		{
			get;
			internal set;
		}

		/// <summary>
		/// JewelerSeason artisan stats
		/// </summary>
		[DataMember(Name = "jewelerSeason", IsRequired = false)]
		public ProfileArtisanInfo JewelerSeason
		{
			get;
			internal set;
		}

		/// <summary>
		/// MysticSeason artisan stats
		/// </summary>
		[DataMember(Name = "mysticSeason", IsRequired = false)]
		public ProfileArtisanInfo MysticSeason
		{
			get;
			internal set;
		}

		/// <summary>
		/// BlacksmithSeasonHardcore artisan stats
		/// </summary>
		[DataMember(Name = "blacksmithSeasonHardcore", IsRequired = false)]
		public ProfileArtisanInfo BlacksmithSeasonHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// JewelerSeasonHardcore artisan stats
		/// </summary>
		[DataMember(Name = "jewelerSeasonHardcore", IsRequired = false)]
		public ProfileArtisanInfo JewelerSeasonHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// MysticSeasonHardcore artisan stats
		/// </summary>
		[DataMember(Name = "mysticSeasonHardcore", IsRequired = false)]
		public ProfileArtisanInfo MysticSeasonHardcore
		{
			get;
			internal set;
		}
		
		/// <summary>
		/// Seasonal profiles
		/// </summary>
		[DataMember(Name = "seasonalProfiles", IsRequired = false)]
		public IDictionary<string, DiabloSeason> SeasonalProfiles
		{
			get;
			internal set;
		}

		/// <summary>
		/// Handle deserialization
		/// </summary>
		/// <param name="context"></param>
		/// <remarks>
		/// This method is marked as internal and CA warning surpressed,
		/// because setting the method as private as CA advises would cause JSON.NET
		/// To fail to call the method, but being internal and internals being visible to 
		/// JSON.NET causes serialization to succeed.
		/// We can run in partial trust environment where JSON.NET cannot have access
		/// to private members.
		/// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2238:ImplementSerializationMethodsCorrectly")]
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            OnHeroCollectionDeserialized(Heroes);
            OnHeroCollectionDeserialized(FallenHeroes);
        }

        /// <summary>
        /// Handle deserialization of hero collection
        /// </summary>
        /// <param name="heroCollection">hero collection</param>
        private void OnHeroCollectionDeserialized(IList<Hero> heroCollection)
        {
            if (heroCollection != null)
            {
                foreach (var hero in heroCollection)
                {
                    if (hero != null)
                    {
                        hero.Path = "/d3/profile/" + BattleTag.Replace('#', '-') + "/hero/" + hero.Id;
                    }
                }
            }
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns>String representation for debugging purposes</returns>
        public override string ToString()
        {
            return BattleTag;
        }
    }
}
