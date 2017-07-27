

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A diablo hero (character) information
	/// </summary>
	[DataContract]
    public class Hero : ApiResponse
    {
        /// <summary>
        /// Hero id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public long Id
        {
            get;
            internal set;
        }

		/// <summary>
		/// character's name
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string Name
		{
			get;
			internal set;
		}

		/// <summary>
		/// Hero's class
		/// </summary>
		[DataMember(Name = "class", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public HeroClass HeroClass
        {
            get;
            internal set;
        }

		/// <summary>
		/// Hero's gender
		/// </summary>
		[DataMember(Name = "gender", IsRequired = true)]
		public HeroGender Gender
		{
			get;
			internal set;
		}

		/// <summary>
		/// character's level
		/// </summary>
		[DataMember(Name = "level", IsRequired = true)]
		public int Level
		{
			get;
			internal set;
		}

		/// <summary>
		/// Whether the hero is dead (for hardcore characters)
		/// </summary>
		[DataMember(Name = "dead", IsRequired = false)]
        public bool IsDead
        {
            get;
            internal set;
        }

        /// <summary>
        /// whether the hero is hardcore
        /// </summary>
        [DataMember(Name = "hardcore", IsRequired = true)]
        public bool IsHardcore
        {
            get;
            internal set;
        }

		/// <summary>
		/// whether the hero is seasonal
		/// </summary>
		[DataMember(Name = "seasonal", IsRequired = true)]
		public bool IsSeasonal
		{
			get;
			internal set;
		}

		/// <summary>
		/// whether the hero is seasonal
		/// </summary>
		[DataMember(Name = "seasonCreated", IsRequired = false)]
		public int SeasonCreated
		{
			get;
			internal set;
		}

		/// <summary>
		/// Paragon level
		/// </summary>
		[DataMember(Name = "paragonLevel", IsRequired = false)]
        public int ParagonLevel
        {
            get;
            set;
        }

        /// <summary>
        /// The time the hero was last updated in UTC
        /// </summary>
        [DataMember(Name = "last-updated", IsRequired = false)]
        [JsonConverter(typeof(DateTimeSecondsConverter))]
        public DateTime LastUpdatedUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Character's skills
        /// </summary>
        [DataMember(Name = "skills")]
        public CharacterSkills Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Kill statistics
        /// </summary>
        [DataMember(Name = "kills")]
        public KillStatistics Kills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Hero mode progression
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public Progression Progression
        {
            get;
            internal set;
        }

        /// <summary>
        /// Followers
        /// </summary>
        [DataMember(Name = "followers", IsRequired = false)]
        public HeroFollowers Followers
        {
            get;
            internal set;
        }

        /// <summary>
        /// Items
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            internal set;
        }

		/// <summary>
		/// Hero's stats
		/// </summary>
		[DataMember(Name = "legendaryPowers", IsRequired = false)]
		public IList<string> LegendaryPowers
		{
			get;
			internal set;
		}

		/// <summary>
		/// Hero's stats
		/// </summary>
		[DataMember(Name = "stats", IsRequired = false)]
        public CharacterStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get the string representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}: Level {1}({2}) {3}",
                Name, Level, ParagonLevel, HeroClass);
        }
    }
}
