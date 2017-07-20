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
        [DataMember(Name = "area")]
        public int AreaId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Controlling faction
        /// </summary>
        [DataMember(Name = "controlling-faction")]
        public Faction ControllingFaction
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the time for the next battle
        /// </summary>
        [DataMember(Name = "next")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime NextBattleTimeUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current status or the zone
        /// </summary>
        [DataMember(Name = "status")]
        public PvpZoneStatus Status
        {
            get;
            internal set;
        }
    }
}