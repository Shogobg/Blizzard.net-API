
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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