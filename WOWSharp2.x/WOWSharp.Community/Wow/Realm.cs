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
        [DataMember(Name = "battlegroup")]
        public string BattleGroupName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realm's locale
        /// </summary>
        [DataMember(Name = "locale")]
        public string Locale
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the realm name
        /// </summary>
        [DataMember(IsRequired = true, Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realm's population
        /// </summary>
        [DataMember(Name = "population", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public RealmPopulation Population
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the realm is currently experiencing queues
        /// </summary>
        [DataMember(IsRequired = false, Name = "queue")]
        public bool Queue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realm id used in urls and query strings
        /// </summary>
        [DataMember(IsRequired = true, Name = "slug")]
        public string Slug
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets whether the realm is up
        /// </summary>
        [DataMember(IsRequired = false, Name = "status")]
        public bool Status
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realms timezone
        /// </summary>
        [DataMember(IsRequired = false, Name = "timezone")]
        public string TimeZone
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realm type
        /// </summary>
        [DataMember(IsRequired = false, Name = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RealmTypes RealmType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the status of the PVP Zone Tol Barad
        /// </summary>
        [DataMember(Name = "tol-barad")]
        public PvpZone TolBarad
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the status of the PVP zone wintergrasp
        /// </summary>
        [DataMember(Name = "wintergrasp")]
        public PvpZone WinterGrasp
        {
            get;
            internal set;
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