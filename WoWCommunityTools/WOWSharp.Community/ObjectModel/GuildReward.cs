/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents a guild reward
    /// </summary>
    [Serializable]
    [DataContract]
    public class GuildReward : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the reward's minimum guild level required
        /// </summary>
        [DataMember(Name = "minGuildLevel", IsRequired = true)]
        public int MinumumGuildLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reward's minumum guild reputation
        /// </summary>
        [DataMember(Name = "minGuildRepLevel", IsRequired = true)]
        public Standing MinimumGuildReputationLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the races for which the reward is available
        /// </summary>
        [DataMember(Name = "races", IsRequired = false)]
        public Race[] Races
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the achievement required to unlock the reward
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reward item
        /// </summary>
        [DataMember(Name = "item", IsRequired = false)]
        public RewardItem RewardItem
        {
            get;
            set;
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return this.RewardItem == null ? "" : this.RewardItem.ToString();
        }

    }
}
