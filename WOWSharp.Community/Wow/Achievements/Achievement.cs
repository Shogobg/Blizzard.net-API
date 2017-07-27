using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents an achievement
	/// </summary>
	[DataContract]
    public class Achievement : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        [DataMember(Name = "title", IsRequired = true)]
        public string Title
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement points
        /// </summary>
        [DataMember(Name = "points", IsRequired = false)]
        public int Points
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement's reward
        /// </summary>
        [DataMember(Name = "reward", IsRequired = false)]
        public string Reward
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement's reward item
        /// </summary>
        [DataMember(Name = "rewardItems", IsRequired = false)]
        public IList<RewardItem> RewardItems
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets Criteria for the achievement
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = false)]
        public IList<AchievementCriterion> Criteria
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the achievement is account wide
        /// </summary>
        [DataMember(Name = "accountWide", IsRequired = false)]
        public bool AccountWide
        {
            get;
            internal set;
        }

        /// <summary>
        ///  Achievement's faction
        /// </summary>
        [DataMember(Name = "factionId", IsRequired = true)]
        public Faction Faction
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
            return Title;
        }
    }
}