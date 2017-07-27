
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents character battleground statistics
    /// </summary>
    [DataContract]
    public class BattlegroundStats
    {
        /// <summary>
        ///   Gets or sets the battleground name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;

        }

        /// <summary>
        ///   Gets or sets the number of games played in that battleground
        /// </summary>
        [DataMember(Name = "played", IsRequired = true)]
        public int GamesPlayed
        {
            get;
            internal set;

        }

        /// <summary>
        ///   Gets or sets the number of games won in that battleground
        /// </summary>
        [DataMember(Name = "won", IsRequired = true)]
        public int GamesWon
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
            return string.Format(CultureInfo.CurrentCulture, "Name: {0}, Played: {1}, Won: {2}", Name, GamesPlayed,
                                 GamesWon);
        }
    }
}