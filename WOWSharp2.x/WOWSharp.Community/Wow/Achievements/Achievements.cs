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
        ///   Gets or sets the Ids of all achievements completed
        /// </summary>
        [DataMember(Name = "achievementsCompleted", IsRequired = true)]
        public IList<int> AchievementsCompleted
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets the dates in UTC at which the achievements where completed
        /// </summary>
        [DataMember(Name = "achievementsCompletedTimestamp", IsRequired = true)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTime> AchievementsCompletedDatesUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the ids of achievements criteria completed
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = true)]
        public IList<int> Criteria
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the quantity of criteria that are still in progress
        /// </summary>
        [DataMember(Name = "criteriaQuantity", IsRequired = true)]
        public IList<long> CriteriaQuantity
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets the dates (in UTC) at the criteria was last updates
        /// </summary>
        [DataMember(Name = "criteriaTimestamp", IsRequired = true)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTime> CriteriaDatesUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets the dates (in UTC) at which the criteria were created
        /// </summary>
        [DataMember(Name = "criteriaCreated", IsRequired = true)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTime> CriteriaCreatedDatesUtc
        {
            get;
            internal set;
        }
    }
}