
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Gets information about character's boss kills
    /// </summary>
    [DataContract]
    public class CharacterBossKills
    {
        /// <summary>
        ///   Gets or sets the name of the boss
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the creature id
        ///   Boss ID is equal to zero in council type fights (For example Four Horsemen, Assembly of Iron, Val'kyr Twins, etc)
        ///   Or fights where there is no boss (Gunship Battle)
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined
        ///   It can also mean that the character killed the boss in heroic mode only and never in normal mode.).
        /// </summary>
        [DataMember(Name = "normalKills", IsRequired = false)]
        public int NormalKills
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined)
        /// </summary>
        [DataMember(Name = "heroicKills", IsRequired = false)]
        public int? HeroicKills
        {
            get;
            internal set;
        }

        /// <summary>
        ///  Gets or sets the number of kills in flexible raid mode
        /// </summary>
        [DataMember(Name = "flexKills", IsRequired = false)]
        public int? FlexKills
        {
            get;
            internal set;
        }

        /// <summary>
        ///  Gets or sets the number of Kills in looking for raid mode.
        /// </summary>
        [DataMember(Name = "lfrKills", IsRequired = false)]
        public int? LfrKills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the date and time of the heroic first kill in Utc
        /// A value of null means either the boss doesn't have heroic mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [DataMember(Name = "heroicTimestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? HeroicFirstKillUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the date and time of the flex first kill in Utc
        /// A value of null means either the boss doesn't have flex mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [DataMember(Name = "flexTimestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? FlexFirstKillUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the date and time of the LFR first kill in Utc
        /// A value of null means either the boss doesn't have LFR mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [DataMember(Name = "lfrTimestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? LfrFirstKillUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the date and time of the normal first kill in Utc
        /// A value of null means the boss was never killed in that mode.
        /// </summary>
        [DataMember(Name = "normalTimestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? NormalFirstKillUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for getting purposed)
        /// </summary>
        /// <returns> Gets string representation (for getting purposed) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} Normal:{1} Heroic:{2}", Name, NormalKills, HeroicKills);
        }
    }
}