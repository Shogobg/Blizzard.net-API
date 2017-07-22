using System.Runtime.Serialization;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Represents information about a character's PVP performance
	/// </summary>
	[DataContract]
    public class CharacterPvpBracketInformation
    {
        /// <summary>
        /// Gets or sets the player's character rating
        /// </summary>
        [DataMember(Name = "rating", IsRequired = true)]
        public int Rating
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonLost", IsRequired = true)]
        public int SeasonLosses
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonWon", IsRequired = true)]
        public int SeasonWins
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games played by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonPlayed", IsRequired = true)]
        public int SeasonPlayed
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyLost", IsRequired = true)]
        public int WeeklyLosses
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyWon", IsRequired = true)]
        public int WeeklyWins
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets number of games played by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyPlayed", IsRequired = true)]
        public int WeeklyPlayed
        {
            get;
            internal set;

        }

        /// <summary>
        /// Gets or sets the PvP bracket type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "slug", IsRequired = true)]
        public PvpBracket PvpBracket
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
            return string.Format(CultureInfo.CurrentCulture, "{0} rating: {1}", PvpBracket, Rating);
        }
    }
}
