using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Artisan training
	/// </summary>
	[DataContract]
    public class ArtisanTraining
    {
        /// <summary>
        /// Training tiers
        /// </summary>
        [DataMember(Name = "tiers")]
        public IList<ArtisanTier> Tiers
        {
            get;
            internal set;
        }
    }
}
