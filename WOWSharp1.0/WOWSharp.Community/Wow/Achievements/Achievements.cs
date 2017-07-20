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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents character's or guild's achievement
    /// </summary>
    [DataContract]
    public class Achievements
    {
        /// <summary>
        ///   timestamps of achievements completed (as milliseconds since 1/1/1970 UTC)
        /// </summary>
        private IList<long> _achiementsCompletedTimestamps;

        /// <summary>
        ///   AchievementsCompleted field
        /// </summary>
        private IList<int> _achievementsCompleted;

        /// <summary>
        ///   Criteria field
        /// </summary>
        private IList<int> _criteria;

        /// <summary>
        ///   the timestamps at the criteria was last updates
        /// </summary>
        private IList<long> _criteriaCreatedTimestamps;

        /// <summary>
        ///   Criteria Quantity field
        /// </summary>
        private IList<long> _criteriaQuantity;

        /// <summary>
        ///   the timestamps at the criteria was last updates
        /// </summary>
        private IList<long> _criteriaTimestamps;

        /// <summary>
        ///   Gets or sets the Ids of all achievements completed
        /// </summary>
        [DataMember(Name = "achievementsCompleted", IsRequired = true)]
        public IList<int> AchievementsCompleted
        {
            get
            {
                return _achievementsCompleted;
            }
            internal set
            {
                _achievementsCompleted = value;
            }
        }


        /// <summary>
        ///   Gets or sets timestamps of achievements completed (as milliseconds since 1/1/1970 UTC)
        /// </summary>
        [DataMember(Name = "achievementsCompletedTimestamp", IsRequired = true)]
        public IList<long> AchievementsCompletedTimestamps
        {
            get
            {
                if (_achiementsCompletedTimestamps == null)
                {
                    _achiementsCompletedTimestamps = new List<long>();
                }
                return _achiementsCompletedTimestamps;
            }
        }

        /// <summary>
        ///   Gets the dates in UTC at which the achievements where completed
        /// </summary>
        public IEnumerable<DateTime> AchievementsCompletedDatesUtc
        {
            get
            {
                return _achievementsCompleted == null
                           ? null
                           : _achievementsCompleted.Select(o =>
                                                           ApiClient.GetUtcDateFromUnixTime(o));
            }
        }

        /// <summary>
        ///   Gets or sets the ids of achievements criteria completed
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = true)]
        public IList<int> Criteria
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
        ///   Gets or sets the quantity of criteria that are still in progress
        /// </summary>
        [DataMember(Name = "criteriaQuantity", IsRequired = true)]
        public IList<long> CriteriaQuantity
        {
            get
            {
                return _criteriaQuantity;
            }
            internal set
            {
                _criteriaQuantity = value;
            }
        }

        /// <summary>
        ///   Gets or sets the timestamps at the criteria was last updates
        /// </summary>
        [DataMember(Name = "criteriaTimestamp", IsRequired = true)]
        public IList<long> CriteriaTimestamps
        {
            get
            {
                return _criteriaTimestamps;
            }
            internal set
            {
                _criteriaTimestamps = value;
            }
        }

        /// <summary>
        ///   gets the dates (in UTC) at the criteria was last updates
        /// </summary>
        public IEnumerable<DateTime> CriteriaDatesUtc
        {
            get
            {
                return _criteriaTimestamps == null
                           ? null
                           : _criteriaTimestamps.Select(o => ApiClient.GetUtcDateFromUnixTime(o));
            }
        }

        /// <summary>
        ///   gets the timestamps at which the criteria were started
        /// </summary>
        [DataMember(Name = "criteriaCreated", IsRequired = true)]
        public IList<long> CriteriaCreatedTimestamps
        {
            get
            {
                return _criteriaCreatedTimestamps;
            }
            internal set
            {
                _criteriaCreatedTimestamps = value;
            }
        }

        /// <summary>
        ///   Gets the dates (in UTC) at which the criteria were created
        /// </summary>
        public IEnumerable<DateTime> CriteriaCreatedDatesUtc
        {
            get
            {
                return _criteriaCreatedTimestamps == null
                           ? null
                           : _criteriaCreatedTimestamps.Select(o => ApiClient.GetUtcDateFromUnixTime(o));
            }
        }
    }
}