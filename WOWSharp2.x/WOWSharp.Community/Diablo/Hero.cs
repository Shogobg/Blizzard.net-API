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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// A diablo hero (character) information
    /// </summary>
    [DataContract]
    public class Hero : ApiResponse
    {
        /// <summary>
        /// Hero id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public long Id
        {
            get;
            internal set;
        }

        
        /// <summary>
        /// Hero's class
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public HeroClass HeroClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// Whether the hero is dead (for hardcore characters)
        /// </summary>
        [DataMember(Name = "dead", IsRequired = false)]
        public bool IsDead
        {
            get;
            internal set;
        }

        /// <summary>
        /// Hero's gender
        /// </summary>
        [DataMember(Name = "gender", IsRequired = true)]
        public HeroGender Gender
        {
            get;
            internal set;
        }

        /// <summary>
        /// whether the hero is hardcore
        /// </summary>
        [DataMember(Name = "hardcore", IsRequired = true)]
        public bool IsHardcore
        {
            get;
            internal set;
        }

        /// <summary>
        /// character's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// character's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Paragon level
        /// </summary>
        [DataMember(Name = "paragonLevel", IsRequired = false)]
        public int ParagonLevel
        {
            get;
            set;
        }

        /// <summary>
        /// The time the hero was last updated in UTC
        /// </summary>
        [DataMember(Name = "last-updated", IsRequired = false)]
        [JsonConverter(typeof(DateTimeSecondsConverter))]
        public DateTime LastUpdatedUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Character's skills
        /// </summary>
        [DataMember(Name = "skills")]
        public CharacterSkills Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Kill statistics
        /// </summary>
        [DataMember(Name = "kills")]
        public KillStatistics Kills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Hero mode progression
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public Progression Progression
        {
            get;
            internal set;
        }

        /// <summary>
        /// Followers
        /// </summary>
        [DataMember(Name = "followers", IsRequired = false)]
        public HeroFollowers Followers
        {
            get;
            internal set;
        }

        /// <summary>
        /// Items
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            internal set;
        }


        /// <summary>
        /// Hero's stats
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public CharacterStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get the string representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}: Level {1}({2}) {3}",
                Name, Level, ParagonLevel, HeroClass);
        }
    }
}
