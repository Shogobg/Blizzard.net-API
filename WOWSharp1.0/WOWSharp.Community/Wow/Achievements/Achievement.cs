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
    ///   Represents an achievement
    /// </summary>
    [DataContract]
    public class Achievement : ApiResponse
    {
        /// <summary>
        ///   Gets or sets whether the achievement is account wide
        /// </summary>
        private bool _accountWide;

        /// <summary>
        ///   Achievement criteria
        /// </summary>
        private IList<AchievementCriterion> _criteria;

        /// <summary>
        ///   Gets or sets the achievement description
        /// </summary>
        private string _description;

        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the achievement points
        /// </summary>
        private int _points;

        /// <summary>
        ///   Gets or sets the achievement's reward
        /// </summary>
        private string _reward;

        /// <summary>
        ///   Reward Items field
        /// </summary>
        private IList<RewardItem> _rewardItems;

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        private string _title;

        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        [DataMember(Name = "title", IsRequired = true)]
        public string Title
        {
            get
            {
                return _title;
            }
            internal set
            {
                _title = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement points
        /// </summary>
        [DataMember(Name = "points", IsRequired = false)]
        public int Points
        {
            get
            {
                return _points;
            }
            internal set
            {
                _points = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get
            {
                return _description;
            }
            internal set
            {
                _description = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement's reward
        /// </summary>
        [DataMember(Name = "reward", IsRequired = false)]
        public string Reward
        {
            get
            {
                return _reward;
            }
            internal set
            {
                _reward = value;
            }
        }

        /// <summary>
        ///   Gets or sets the achievement's reward item
        /// </summary>
        [DataMember(Name = "rewardItems", IsRequired = false)]
        public IList<RewardItem> RewardItems
        {
            get
            {
                return _rewardItems;
            }
            internal set
            {
                _rewardItems = value;
            }
        }

        /// <summary>
        ///   gets or sets Criteria for the achievement
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = false)]
        public IList<AchievementCriterion> Criteria
        {
            get
            {
                return _criteria;
            }
            internal set
            {
                _criteria = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the achievement is account wide
        /// </summary>
        [DataMember(Name = "accountWide", IsRequired = false)]
        public bool AccountWide
        {
            get
            {
                return _accountWide;
            }
            internal set
            {
                _accountWide = value;
            }
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