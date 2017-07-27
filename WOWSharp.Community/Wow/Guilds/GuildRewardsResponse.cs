using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   represents the response of guild rewards request
	/// </summary>
	[DataContract]
    public class GuildRewardsResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the guild rewards list
        /// </summary>
        [DataMember(Name = "rewards", IsRequired = true)]
        public IList<GuildReward> Rewards
        {
            get;
            internal set;
        }
    }
}