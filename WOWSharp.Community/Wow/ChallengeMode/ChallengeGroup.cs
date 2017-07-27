
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   information about a group that complete a challenge mode
    /// </summary>
    [DataContract]
    public class ChallengeGroup
    {
        /// <summary>
        ///   gets or sets completion date
        /// </summary>
        [DataMember(Name = "date", IsRequired = false)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DateUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of the faction of the group
        /// </summary>
        [DataMember(Name = "faction", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets isrecurring (no idea what that means)
        /// </summary>
        [DataMember(Name = "isRecurring", IsRequired = false)]
        public bool IsRecurring
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of medal
        /// </summary>
        [DataMember(Name = "medal", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChallengeMedalType Medal
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets group members
        /// </summary>
        [DataMember(Name = "members", IsRequired = false)]
        public IList<ChallengeGroupMember> Members
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets rank
        /// </summary>
        [DataMember(Name = "ranking", IsRequired = false)]
        public int Ranking
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets time
        /// </summary>
        [DataMember(Name = "time", IsRequired = false)]
        public ChallengeCompletionTime Time
        {
            get;
            internal set;
        }

        /// <summary>
        /// The challenge mode's group guild
        /// </summary>
        [DataMember(Name = "guild", IsRequired = false)]
        public CharacterGuild Guild
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                                 "{0}: {1} members, {2} - {3}", Ranking, Members == null ? 0 : Members.Count, Medal,
                                 Time);
        }
    }
}