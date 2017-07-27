using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Artisan level information
	/// </summary>
	[DataContract]
    public class ArtisanLevel
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
        /// level within the tier
        /// </summary>
        [DataMember(Name = "tierLevel")]
        public int TierLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// progress percent towards the next tier
        /// </summary>
        [DataMember(Name = "percent")]
        public double ProgressPercent
        {
            get;
            internal set;
        }

        /// <summary>
        /// recipes that are trained by upgrading the artisan
        /// </summary>
        [DataMember(Name = "trainedRecipes")]
        public IList<Recipe> TrainedRecipes
        {
            get;
            internal set;
        }

        /// <summary>
        /// recipes that are taught to the artisan by finding recipes/designs and teaching them to the the artisan
        /// </summary>
        [DataMember(Name = "taughtRecipes")]
        public IList<Recipe> TaughtRecipes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Upgrade cost in gold. 
        /// This seems to always return zero even though the  API documentation
        /// example has values for it
        /// </summary>
        [DataMember(Name = "upgradeCost")]
        public long UpdateCost
        {
            get;
            internal set;
        }

        /// <summary>
        /// items required to upgrade. 
        /// This seems to always return zero even though the  API documentation
        /// example has values for it
        /// </summary>
        [DataMember(Name = "upgradeItems")]
        public IList<RecipeReagent> UpgradeItems
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
            return "Level " + this.TierLevel.ToString(CultureInfo.InvariantCulture);
        }
    }
}
