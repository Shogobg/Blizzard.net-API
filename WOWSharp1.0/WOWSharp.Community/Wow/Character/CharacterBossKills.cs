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
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Gets information about character's boss kills
    /// </summary>
    [DataContract]
    public class CharacterBossKills
    {
        

        /// <summary>
        ///   Gets or sets the creature id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the name of the boss
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined)
        ///   If the value is null, the boss doesn't have heroic mode.
        /// </summary>
        private int? _heroicKills;

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined
        ///   It can also mean that the character killed the boss in heroic mode only and never in normal mode.).
        /// </summary>
        private int _normalKills;

        /// <summary>
        /// The number of kills in flexible raid mode.
        /// If the value is null, the boss doesn't have flex mode.
        /// </summary>
        private int? _flexKills;

        /// <summary>
        /// The number of kills in looking for raid Mode.
        /// If the value is null, the boss doesn't have LFR mode.
        /// </summary>
        private int? _lfrKills;

        /// <summary>
        ///  The timestamp of the first time the boss was killed in heroic mode. Zero if never killed.
        ///  If the value is null, the boss doesn't have heroic mode.
        /// </summary>
        private long? _heroicTimestamp;

        /// <summary>
        ///  The timestamp of the first time the boss was killed in normal mode. Zero if never killed.
        /// </summary>
        private long _normalTimestamp;

        /// <summary>
        ///  The timestamp of the first time the boss was killed in looking for raid mode. Zero if never killed.
        ///  If the value is null, the boss doesn't have LFR mode.
        /// </summary>
        private long? _lfrTimestamp;

        /// <summary>
        ///  The timestamp of the first time the boss was killed in flexible raid mode. Zero if never killed.
        ///  If the value is null, the boss doesn't have flex mode.
        /// </summary>
        private long? _flexTimestamp;

        /// <summary>
        ///   Gets or sets the name of the boss
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   Gets or sets the creature id
        ///   Boss ID is equal to zero in council type fights (For example Four Horsemen, Assembly of Iron, Val'kyr Twins, etc)
        ///   Or fights where there is no boss (Gunship Battle)
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
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined
        ///   It can also mean that the character killed the boss in heroic mode only and never in normal mode.).
        /// </summary>
        [DataMember(Name = "normalKills", IsRequired = false)]
        public int NormalKills
        {
            get
            {
                return _normalKills;
            }
            internal set
            {
                _normalKills = value;
            }
        }

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined)
        /// </summary>
        [DataMember(Name = "heroicKills", IsRequired = false)]
        public int? HeroicKills
        {
            get
            {
                return _heroicKills;
            }
            internal set
            {
                _heroicKills = value;
            }
        }

        /// <summary>
        ///  Gets or sets the number of kills in flexible raid mode
        /// </summary>
        [DataMember(Name = "flexKills", IsRequired = false)]
        public int? FlexKills
        {
            get
            {
                return _flexKills;
            }
            internal set
            {
                _flexKills = value;
            }
        }

        /// <summary>
        ///  Gets or sets the number of Kills in looking for raid mode.
        /// </summary>
        [DataMember(Name = "lfrKills", IsRequired = false)]
        public int? LfrKills
        {
            get
            {
                return _lfrKills;
            }
            internal set
            {
                _lfrKills = value;
            }
        }

        /// <summary>
        ///  Gets or sets the time stamp of the first heroic kill.
        ///  A value of zero means never killed.
        ///  A value of null means boss doesn't have heroic mode
        /// </summary>
        [DataMember(Name = "heroicTimestamp", IsRequired = false)]
        public long? HeroicTimestamp
        {
            get
            {
                return _heroicTimestamp;
            }
            internal set
            {
                _heroicTimestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the heroic first kill in Utc
        /// A value of null means either the boss doesn't have heroic mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        public DateTime? HeroicFirstKillUtc
        {
            get
            {
                return _heroicTimestamp.GetValueOrDefault() > 0 ? ApiClient.GetUtcDateFromUnixTime(_heroicTimestamp.GetValueOrDefault()) : (DateTime?)null;
            }
            internal set
            {
                _heroicTimestamp = value.HasValue ? ApiClient.GetUnixTimeFromDate(value.GetValueOrDefault()) : (long?)null;
            }
        }

        /// <summary>
        ///  Gets or sets the time stamp of the first flexible raid kill.
        ///  A value of zero means never killed.
        ///  A value of null means boss doesn't have flex mode
        /// </summary>
        [DataMember(Name = "flexTimestamp", IsRequired = false)]
        public long? FlexTimestamp
        {
            get
            {
                return _flexTimestamp;
            }
            internal set
            {
                _flexTimestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the flex first kill in Utc
        /// A value of null means either the boss doesn't have flex mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        public DateTime? FlexFirstKillUtc
        {
            get
            {
                return _flexTimestamp.GetValueOrDefault() > 0 ? ApiClient.GetUtcDateFromUnixTime(_flexTimestamp.GetValueOrDefault()) : (DateTime?)null;
            }
            internal set
            {
                _flexTimestamp = value.HasValue ? ApiClient.GetUnixTimeFromDate(value.GetValueOrDefault()) : (long?)null;
            }
        }

        /// <summary>
        ///  Gets or sets the time stamp of the first LFR kill.
        ///  A value of zero means never killed.
        ///  A value of null means boss doesn't have LFR mode
        /// </summary>
        [DataMember(Name = "lfrTimestamp", IsRequired = false)]
        public long? LfrTimestamp
        {
            get
            {
                return _lfrTimestamp;
            }
            internal set
            {
                _lfrTimestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the LFR first kill in Utc
        /// A value of null means either the boss doesn't have LFR mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        public DateTime? LfrFirstKillUtc
        {
            get
            {
                return _lfrTimestamp.GetValueOrDefault() > 0 ? ApiClient.GetUtcDateFromUnixTime(_lfrTimestamp.GetValueOrDefault()) : (DateTime?)null;
            }
            internal set
            {
                _lfrTimestamp = value.HasValue ? ApiClient.GetUnixTimeFromDate(value.GetValueOrDefault()) : (long?)null;
            }
        }

        /// <summary>
        ///  Gets or sets the time stamp of the first normal kill.
        ///  A value of zero means never killed.
        /// </summary>
        [DataMember(Name = "normalTimestamp", IsRequired = false)]
        public long NormalTimestamp
        {
            get
            {
                return _normalTimestamp;
            }
            internal set
            {
                _normalTimestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the normal first kill in Utc
        /// A value of null means the boss was never killed in that mode.
        /// </summary>
        public DateTime? NormalFirstKillUtc
        {
            get
            {
                return _normalTimestamp > 0 ? ApiClient.GetUtcDateFromUnixTime(_normalTimestamp) : (DateTime?)null;
            }
            internal set
            {
                _normalTimestamp = value.HasValue ? ApiClient.GetUnixTimeFromDate(value.GetValueOrDefault()) : 0;
            }
        }

        /// <summary>
        ///   Gets string representation (for getting purposed)
        /// </summary>
        /// <returns> Gets string representation (for getting purposed) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} Normal:{1} Heroic:{2}", Name, NormalKills, HeroicKills);
        }
    }
}