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

using Newtonsoft.Json;
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