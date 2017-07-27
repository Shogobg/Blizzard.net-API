using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents character profile information
	/// </summary>
	[DataContract]
    public class Character : CharacterBase
    {
        /// <summary>
        ///   Gets or sets the realm name to which the character belongs
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's battlegroup name
        /// </summary>
        [DataMember(Name = "battlegroup", IsRequired = true)]
        public string BattleGroupName
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets the character name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the thumbnail image for the character
        /// </summary>
        [DataMember(Name = "thumbnail", IsRequired = true)]
        public string Thumbnail
        {
            get;
            internal set;
        }

		/// <summary>
		///   Gets or sets the total achievevement points for the character
		/// </summary>
		[DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's gender
        /// </summary>
        [DataMember(Name = "gender", IsRequired = true)]
        public CharacterGender Gender
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the class id of the character
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        public ClassKey Class
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the class id of the character in the Blizzard's talent calculator
        /// </summary>
        [DataMember(Name = "calcClass", IsRequired = false)]
        public string CalculatorClass
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [DataMember(Name = "guild", IsRequired = false)]
        public CharacterGuild Guild
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the items currently equipped by the character. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current character's stats. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public CharacterStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about the character specialization and talent. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "talents", IsRequired = false)]
        public IList<CharacterTalents> Talents
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Get or sets information about character's reputation is all factions the character interacted with. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "reputation", IsRequired = false)]
        public IList<CharacterReputation> Reputations
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a collection or character's titles. %s is replaced by character's name when displaying the title. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "titles", IsRequired = false)]
        public IList<CharacterTitle> Titles
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about character's current professions and skil level. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "professions", IsRequired = false)]
        public CharacterProfessions Professions
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about character's appearance. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "appearance", IsRequired = false)]
        public CharacterAppearance Appearance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a collection of character's mounts.  This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "mounts", IsRequired = false)]
        public CharacterMounts Mounts
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a collection of character's pets. This can be null if the field is not requested while requesting the character profile data or if the character is a class not having pets.
        /// </summary>
        [DataMember(Name = "pets", IsRequired = false)]
        public CharacterPets Pets
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current character's achievments. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current character's progression. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public CharacterProgression Progression
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the ids of the quests the character has completed
        /// </summary>
        [DataMember(Name = "quests", IsRequired = false)]
        public IList<int> CompletedQuestIds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character Pvp stats
        /// </summary>
        [DataMember(Name = "pvp", IsRequired = false)]
        public CharacterPvpInformation Pvp
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets feeds
        /// </summary>
        [DataMember(Name = "feed", IsRequired = false)]
        public IList<FeedItem> Feed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets hunter pets
        /// </summary>
        [DataMember(Name = "hunterPets", IsRequired = false)]
        public IList<HunterPet> HunterPets
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet slots
        /// </summary>
        [DataMember(Name = "petSlots", IsRequired = false)]
        public IList<CharacterPetSlot> PetSlots
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character total honorable kills
        /// </summary>
        [DataMember(Name = "totalHonorableKills", IsRequired = false)]
        public int TotalHonorableKills
        {
            get;
            internal set;
        }

        /// <summary>
        ///  Gets or sets the character career statistics. This will be null, 
        ///  unless Statistics enum flag is set when retreiving character data
        /// </summary>
        [DataMember(Name = "statistics")]
        public CharacterStatisticsCategory Statistics
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}@{1} Level {2} {3} {4} {5}",
                                 Name, Realm, Level, Gender, Race, Class);
        }
    }
}