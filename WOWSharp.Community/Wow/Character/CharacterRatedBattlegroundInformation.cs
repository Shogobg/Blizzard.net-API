using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about a characters rated battleground performance
	/// </summary>
	[DataContract]
    public class CharacterRatedBattlegroundInformation
    {
        /// <summary>
        ///   Gets or sets the character's rated battleground personal rating
        /// </summary>
        [DataMember(Name = "personalRating", IsRequired = false)]
        public int PersonalRating
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets the character's battle ground stats
        /// </summary>
        [DataMember(Name = "battlegrounds", IsRequired = false)]
        public IList<BattlegroundStats> Battlegrounds
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
            return string.Format(CultureInfo.CurrentCulture, "Rated BG Personal Rating: {0}", PersonalRating);
        }
    }
}