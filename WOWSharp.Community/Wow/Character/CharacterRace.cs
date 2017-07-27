
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents character's race
    /// </summary>
    [DataContract]
    public class CharacterRace
    {
        /// <summary>
        ///   gets or sets race id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Race Race
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets race mask (used to determine which items, quests are available for that race)
        /// </summary>
        [DataMember(Name = "mask", IsRequired = true)]
        public int Mask
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the faction to which the race belongs
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the race name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
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
            return Name;
        }
    }
}