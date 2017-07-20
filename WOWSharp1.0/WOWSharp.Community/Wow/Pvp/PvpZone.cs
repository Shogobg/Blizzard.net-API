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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class PvpZone
    {
        /// <summary>
        ///   Gets or sets the pvp area Id
        /// </summary>
        private int _areaId;

        /// <summary>
        ///   Controlling faction
        /// </summary>
        private Faction _controllingFaction;

        /// <summary>
        ///   Gets or sets the time for the next battle
        /// </summary>
        private DateTime _nextBattleTimeUtc;

        /// <summary>
        ///   Gets or sets the current status or the zone
        /// </summary>
        private PvpZoneStatus _status;

        /// <summary>
        ///   Gets or sets the pvp area Id
        /// </summary>
        [DataMember(Name = "area")]
        public int AreaId
        {
            get
            {
                return _areaId;
            }
            internal set
            {
                _areaId = value;
            }
        }

        /// <summary>
        ///   Controlling faction
        /// </summary>
        [DataMember(Name = "controlling-faction")]
        public Faction ControllingFaction
        {
            get
            {
                return _controllingFaction;
            }
            internal set
            {
                _controllingFaction = value;
            }
        }

        /// <summary>
        ///   Gets or sets the timestamp for the next battle
        /// </summary>
        [DataMember(Name = "next")]
        public long NextBattleTimestamp
        {
            get
            {
                return ApiClient.GetUnixTimeFromDate(NextBattleTimeUtc);
            }
            internal set
            {
                NextBattleTimeUtc = ApiClient.GetUtcDateFromUnixTime(value);
            }
        }

        /// <summary>
        ///   Gets or sets the time for the next battle
        /// </summary>
        public DateTime NextBattleTimeUtc
        {
            get
            {
                return _nextBattleTimeUtc;
            }
            internal set
            {
                _nextBattleTimeUtc = value;
            }
        }

        /// <summary>
        ///   Gets or sets the current status or the zone
        /// </summary>
        [DataMember(Name = "status")]
        public PvpZoneStatus Status
        {
            get
            {
                return _status;
            }
            internal set
            {
                _status = value;
            }
        }
    }
}