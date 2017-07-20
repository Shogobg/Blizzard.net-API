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
    /// Represents character's or guild's achievement
    /// </summary>
    [Serializable]
    [DataContract]
    public class Achievements : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the Ids of all achievements completed
        /// </summary>
        [DataMember(Name = "achievementsCompleted", IsRequired = true)]
        public int[] AchievementsCompleted
        {
            get;
            set;
        }


        /// <summary>
        /// timestamps of achievements completed (as milliseconds since 1/1/1970 UTC)
        /// </summary>
        private long[] _achiementsCompletedTimestamps;
        /// <summary>
        /// Gets or sets timestamps of achievements completed (as milliseconds since 1/1/1970 UTC)
        /// </summary>
        [DataMember(Name = "achievementsCompletedTimestamp", IsRequired = true)]
        public long[] AchievementsCompletedTimestamps
        {
            get
            {
                return this._achiementsCompletedTimestamps;
            }
            set
            {
                _achiementsCompletedTimestamps = value;
                if (value == null)
                    this.AchievmentsCompletedDatesUtc = null;
                else
                    this.AchievmentsCompletedDatesUtc = value.Select(val => ApiClient.GetUtcDateFromUnixTime(val)).ToArray();
            }
        }

        /// <summary>
        /// Gets the dates in UTC at which the achievements where completed
        /// </summary>
        public DateTime[] AchievmentsCompletedDatesUtc
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the ids of achievements criteria completed
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = true)]
        public int[] Criteria
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the quantity of criteria that are still in progress
        /// </summary>
        [DataMember(Name = "criteriaQuantity", IsRequired = true)]
        public long[] CriteriaQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// the timestamps at the criteria was last updates
        /// </summary>
        private long[] _criteriaTimestamps;
        /// <summary>
        /// Gets or sets the timestamps at the criteria was last updates
        /// </summary>
        [DataMember(Name = "criteriaTimestamp", IsRequired = true)]
        public long[] CriteriaTimestamps
        {
            get
            {
                return _criteriaTimestamps;
            }
            set
            {
                _criteriaTimestamps = value;
                if (_criteriaTimestamps == null)
                {
                    this.CriteriaDatesUtc = null;
                }
                else
                {
                    this.CriteriaDatesUtc = value.Select(val => ApiClient.GetUtcDateFromUnixTime(val)).ToArray();
                }
            }
        }

        /// <summary>
        /// gets the dates (in UTC) at the criteria was last updates
        /// </summary>
        public DateTime[] CriteriaDatesUtc
        {
            get;
            private set;
        }

        /// <summary>
        /// the timestamps at the criteria was last updates
        /// </summary>
        private long[] _criteriaCreatedTimestamps;
        
        /// <summary>
        /// gets the timestamps at which the criteria were started
        /// </summary>
        [DataMember(Name = "criteriaCreated", IsRequired = true)]
        public long[] CriteriaCreatedTimestamps
        {
            get
            {
                return _criteriaCreatedTimestamps;
            }
            set
            {
                this._criteriaCreatedTimestamps = value;
                if (value == null)
                    this.CriteriaCreatedDatesUtc = null;
                else
                    this.CriteriaCreatedDatesUtc = value.Select(val => ApiClient.GetUtcDateFromUnixTime(val)).ToArray();
            }
        }

        /// <summary>
        /// Gets the dates (in UTC) at which the criteria were created
        /// </summary>
        public DateTime[] CriteriaCreatedDatesUtc
        {
            get;
            private set;
        }
    }
}
