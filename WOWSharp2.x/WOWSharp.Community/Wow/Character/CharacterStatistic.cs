
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// A character career statistic
	/// </summary>
	[DataContract]
    public class CharacterStatistic
    {
        /// <summary>
        /// Get or sets statistic id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the statistic name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets whether the statistic is character wealth statistic. 
        /// This will always be false because Blizzard doesn't make wealth statistic public
        /// </summary>
        [DataMember(Name = "money", IsRequired = false)]
        public bool IsMoney
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the time where the statistic was last update in UTC
        /// </summary>
        [DataMember(Name = "lastUpdated", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime LastUpdatedTimeUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// The quantity of the statistic
        /// </summary>
        /// <remarks>
        /// I haven't seen any statistic that has non-integer values, a long may be sufficient.
        /// However, I am using double just in case for future changes.
        /// </remarks>
        [DataMember(Name = "quantity", IsRequired = false)]
        public double Quantity
        {
            get;
            internal set;
        }
        
        /// <summary>
        /// Gets or sets the place/item/etc under which the highest value of the statistic was achieved.
        /// For example: Continent with the most Honorable Kills, Highest can be Northrend
        /// 
        /// </summary>
        [DataMember(Name = "highest", IsRequired = false)]
        public string Highest
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " = " + Quantity.ToString(CultureInfo.InvariantCulture);
        }
    }
}
