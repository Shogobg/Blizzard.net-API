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