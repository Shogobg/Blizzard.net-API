using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Artisan's tier
	/// </summary>
	[DataContract]
    public class ArtisanTier
    {
        /// <summary>
        /// Artisan level
        /// </summary>
        [DataMember(Name = "tier")]
        public int Tier
        {
            get;
            internal set;
        }

        /// <summary>
        /// Levels within the tier
        /// </summary>
        [DataMember(Name = "levels")]
        public IList<ArtisanLevel> Levels
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Tier " + this.Tier.ToString(CultureInfo.InvariantCulture);
        }
    }
}
