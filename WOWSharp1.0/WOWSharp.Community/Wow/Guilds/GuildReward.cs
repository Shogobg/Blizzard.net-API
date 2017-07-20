// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
        ///   Gets or sets the achievement required to unlock the reward
        /// </summary>
        private Achievement _achievement;

        /// <summary>
        ///   Gets or sets the reward's minimum guild level required
        /// </summary>
        private int _minimumGuildLevel;

        /// <summary>
        ///   Gets or sets the reward's minumum guild reputation
        /// </summary>
        private Standing _minimumGuildReputationLevel;

        /// <summary>
        ///   Races list
        /// </summary>
        private IList<Race> _races;

        /// <summary>
        ///   Gets or sets the reward item
        /// </summary>
        private RewardItem _rewardItem;

        /// <summary>
        ///   Gets or sets the reward's minimum guild level required
        /// </summary>
        [DataMember(Name = "minGuildLevel", IsRequired = true)]
        public int MinimumGuildLevel
        {
            get
            {
                return _minimumGuildLevel;
            }
            internal set
            {
                _minimumGuildLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the reward's minumum guild reputation
        /// </summary>
        [DataMember(Name = "minGuildRepLevel", IsRequired = true)]
        public Standing MinimumGuildReputationLevel
        {
            get
            {
                return _minimumGuildReputationLevel;
            }
            internal set
            {
                _minimumGuildReputationLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the races for which the reward is available
        /// </summary>
        [DataMember(Name = "races", IsRequired = false)]
        public IList<Race> Races
        {
            get
            {
                return _races;
            }
            internal set
            {
                _races = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement required to unlock the reward
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get
            {
                return _achievement;
            }
            internal set
            {
                _achievement = value;
            }
        }

        /// <summary>
        ///   Gets or sets the reward item
        /// </summary>
        [DataMember(Name = "item", IsRequired = false)]
        public RewardItem RewardItem
        {
            get
            {
                return _rewardItem;
            }
            internal set
            {
                _rewardItem = value;
            }
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