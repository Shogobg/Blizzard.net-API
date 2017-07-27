using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Information about a character's performance in different PVP brackets
	/// </summary>
	[DataContract]
    public class CharacterPvpBrackets
    {
        /// <summary>
        /// Gets or sets characters PVP 2v2 bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_2v2", IsRequired = true)]
        public CharacterPvpBracketInformation Arena2v2
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets characters PVP 3v3 bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_3v3", IsRequired = true)]
        public CharacterPvpBracketInformation Arena3v3
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets characters PVP 5v5 bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_5v5", IsRequired = true)]
        public CharacterPvpBracketInformation Arena5v5
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets characters PVP Rated battle ground bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_RBG", IsRequired = true)]
        public CharacterPvpBracketInformation RatedBattleground
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
            return string.Format(CultureInfo.CurrentCulture, "{0}, {1}, {2}, {3}", Arena2v2, Arena3v3, Arena5v5, RatedBattleground);
        }
    }
}
