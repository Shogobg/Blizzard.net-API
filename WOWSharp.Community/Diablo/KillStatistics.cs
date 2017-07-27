using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Hero or profile kill statistics
	/// </summary>
	[DataContract]
    public class KillStatistics
    {
        /// <summary>
        /// Elite kills
        /// </summary>
        [DataMember(Name = "elites", IsRequired = false)]
        public long EliteKills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Hardcore kills
        /// </summary>
        [DataMember(Name = "hardcoreMonsters", IsRequired = false)]
        public long HardcoreKills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Monsters
        /// </summary>
        [DataMember(Name = "monsters", IsRequired = false)]
        public long Monsters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get string representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EliteKills.ToString(CultureInfo.InvariantCulture) + " elite kills";
        }
    }
}
