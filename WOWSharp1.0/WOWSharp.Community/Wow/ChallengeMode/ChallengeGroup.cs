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
        ///   completion date
        /// </summary>
        private string _date;

        /// <summary>
        ///   the faction of the group
        /// </summary>
        private Faction _faction;

        /// <summary>
        ///   isrecurring (no idea what that means)
        /// </summary>
        private bool _isRecurring;

        /// <summary>
        ///   medal
        /// </summary>
        private ChallengeMedalType _medal;

        /// <summary>
        ///   group members
        /// </summary>
        private IList<ChallengeGroupMember> _members;

        /// <summary>
        ///   rank
        /// </summary>
        private int _ranking;

        /// <summary>
        ///   time
        /// </summary>
        private ChallengeCompletionTime _time;

        /// <summary>
        ///   gets or sets completion date
        /// </summary>
        [DataMember(Name = "date", IsRequired = false)]
        public string DateString
        {
            get
            {
                return _date;
            }
            internal set
            {
                _date = value;
            }
        }

        /// <summary>
        ///   The date and time of completion in UTC
        /// </summary>
        public DateTime? DateUtc
        {
            get
            {
                return _date == null ? default(DateTime?) : DateTime.Parse("r", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        ///   gets or sets name of the faction of the group
        /// </summary>
        [DataMember(Name = "faction", IsRequired = false)]
        public string FactionName
        {
            get
            {
                return EnumHelper<Faction>.EnumToString(_faction);
            }
            internal set
            {
                _faction = EnumHelper<Faction>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   gets or sets name of the faction of the group
        /// </summary>
        public Faction Faction
        {
            get
            {
                return _faction;
            }
        }

        /// <summary>
        ///   gets or sets isrecurring (no idea what that means)
        /// </summary>
        [DataMember(Name = "isRecurring", IsRequired = false)]
        public bool IsRecurring
        {
            get
            {
                return _isRecurring;
            }
            internal set
            {
                _isRecurring = value;
            }
        }

        /// <summary>
        ///   gets or sets name of medal
        /// </summary>
        [DataMember(Name = "medal", IsRequired = false)]
        public string MedalName
        {
            get
            {
                return EnumHelper<ChallengeMedalType>.EnumToString(_medal);
            }
            internal set
            {
                _medal = EnumHelper<ChallengeMedalType>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   gets or sets name of medal
        /// </summary>
        public ChallengeMedalType Medal
        {
            get
            {
                return _medal;
            }
        }

        /// <summary>
        ///   gets or sets group members
        /// </summary>
        [DataMember(Name = "members", IsRequired = false)]
        public IList<ChallengeGroupMember> Members
        {
            get
            {
                return _members;
            }
            internal set
            {
                _members = value;
            }
        }

        /// <summary>
        ///   gets or sets rank
        /// </summary>
        [DataMember(Name = "ranking", IsRequired = false)]
        public int Ranking
        {
            get
            {
                return _ranking;
            }
            internal set
            {
                _ranking = value;
            }
        }

        /// <summary>
        ///   gets or sets time
        /// </summary>
        [DataMember(Name = "time", IsRequired = false)]
        public ChallengeCompletionTime Time
        {
            get
            {
                return _time;
            }
            internal set
            {
                _time = value;
            }
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