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

using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a realm
    /// </summary>
    [DataContract]
    public class Realm
    {
        /// <summary>
        ///   Gets or sets the realm's battle group name
        /// </summary>
        private string _battleGroupName;

        /// <summary>
        ///   Gets or sets the realm's locale
        /// </summary>
        private string _locale;

        /// <summary>
        ///   gets or sets the realm name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the realm's population
        /// </summary>
        private RealmPopulation _population;

        /// <summary>
        ///   Gets or sets whether the realm is currently experiencing queues
        /// </summary>
        private bool _queue;

        /// <summary>
        ///   Gets or sets the realm type
        /// </summary>
        private RealmTypes _realmType;

        /// <summary>
        ///   Gets or sets the realm id used in urls and query strings
        /// </summary>
        private string _slug;

        /// <summary>
        ///   Gets or sets whether the realm is up
        /// </summary>
        private bool _status;

        /// <summary>
        ///   Gets or sets the realms timezone
        /// </summary>
        private string _timeZone;

        /// <summary>
        ///   Gets or sets the status of the PVP Zone Tol Barad
        /// </summary>
        private PvpZone _tolBarad;

        /// <summary>
        ///   Gets or sets the status of the PVP zone wintergrasp
        /// </summary>
        private PvpZone _winterGrasp;

        /// <summary>
        ///   Gets or sets the realm's battle group name
        /// </summary>
        [DataMember(Name = "battlegroup")]
        public string BattleGroupName
        {
            get
            {
                return _battleGroupName;
            }
            internal set
            {
                _battleGroupName = value;
            }
        }

        /// <summary>
        ///   Gets or sets the realm's locale
        /// </summary>
        [DataMember(Name = "locale")]
        public string Locale
        {
            get
            {
                return _locale;
            }
            internal set
            {
                _locale = value;
            }
        }

        /// <summary>
        ///   gets or sets the realm name
        /// </summary>
        [DataMember(IsRequired = true, Name = "name")]
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
        ///   Gets or sets the realm's population
        /// </summary>
        [DataMember(Name = "population", IsRequired = false)]
        public string PopulationName
        {
            get
            {
                return Population.ToString();
            }
            internal set
            {
                Population = EnumHelper<RealmPopulation>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   Gets or sets the realm's population
        /// </summary>
        public RealmPopulation Population
        {
            get
            {
                return _population;
            }
            internal set
            {
                _population = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the realm is currently experiencing queues
        /// </summary>
        [DataMember(IsRequired = false, Name = "queue")]
        public bool Queue
        {
            get
            {
                return _queue;
            }
            internal set
            {
                _queue = value;
            }
        }

        /// <summary>
        ///   Gets or sets the realm id used in urls and query strings
        /// </summary>
        [DataMember(IsRequired = true, Name = "slug")]
        public string Slug
        {
            get
            {
                return _slug;
            }
            internal set
            {
                _slug = value;
            }
        }


        /// <summary>
        ///   Gets or sets whether the realm is up
        /// </summary>
        [DataMember(IsRequired = false, Name = "status")]
        public bool Status
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

        /// <summary>
        ///   Gets or sets the realms timezone
        /// </summary>
        [DataMember(IsRequired = false, Name = "timezone")]
        public string TimeZone
        {
            get
            {
                return _timeZone;
            }
            internal set
            {
                _timeZone = value;
            }
        }


        /// <summary>
        ///   Gets or sets the realm type name
        /// </summary>
        [DataMember(IsRequired = false, Name = "type")]
        public string TypeName
        {
            get
            {
                return EnumHelper<RealmTypes>.EnumToString(RealmType);
            }
            internal set
            {
                RealmType = EnumHelper<RealmTypes>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   Gets or sets the realm type
        /// </summary>
        public RealmTypes RealmType
        {
            get
            {
                return _realmType;
            }
            internal set
            {
                _realmType = value;
            }
        }

        /// <summary>
        ///   Gets or sets the status of the PVP Zone Tol Barad
        /// </summary>
        [DataMember(Name = "tol-barad")]
        public PvpZone TolBarad
        {
            get
            {
                return _tolBarad;
            }
            internal set
            {
                _tolBarad = value;
            }
        }

        /// <summary>
        ///   Gets or sets the status of the PVP zone wintergrasp
        /// </summary>
        [DataMember(Name = "wintergrasp")]
        public PvpZone WinterGrasp
        {
            get
            {
                return _winterGrasp;
            }
            internal set
            {
                _winterGrasp = value;
            }
        }

        /// <summary>
        ///   Gets whether the realm is PVP enabled
        /// </summary>
        public bool IsPvp
        {
            get
            {
                return (RealmType & RealmTypes.Pvp) != 0;
            }
        }

        /// <summary>
        ///   Gets whether the realm has Role Play rule
        /// </summary>
        public bool IsRP
        {
            get
            {
                return (RealmType & RealmTypes.RP) != 0;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Realm = {0}, Type= {1}, Status = {2}", Name,
                                 RealmType, Status);
        }
    }
}