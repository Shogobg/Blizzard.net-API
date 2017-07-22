using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a guild reward
	/// </summary>
	[DataContract]
    public class GuildReward
    {
        /// <summary>
        ///   Gets or sets the reward's minimum guild level required
        /// </summary>
        [DataMember(Name = "minGuildLevel", IsRequired = true)]
        public int MinimumGuildLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the reward's minumum guild reputation
        /// </summary>
        [DataMember(Name = "minGuildRepLevel", IsRequired = true)]
        public Standing MinimumGuildReputationLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the races for which the reward is available
        /// </summary>
        [DataMember(Name = "races", IsRequired = false)]
        public IList<Race> Races
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement required to unlock the reward
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the reward item
        /// </summary>
        [DataMember(Name = "item", IsRequired = false)]
        public RewardItem RewardItem
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
            return RewardItem == null ? "" : RewardItem.ToString();
        }
    }
}