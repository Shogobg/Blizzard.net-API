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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// A hero's follower
    /// </summary>
    [DataContract]
    public class HeroFollower
    {
        /// <summary>
        /// Follower's equipped items
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower's level (recently this will always return 0, but now heroes always have same level as their followers)
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower's skills
        /// </summary>
        [DataMember(Name = "skills")]
        public IList<CharacterSkill> Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower type
        /// </summary>
        [DataMember(Name = "slug")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FollowerType FollowerType
        {
            get;
            internal set;
        }

        /// <summary>
        /// follower stat's (only adventure status are set which are bonus xp, MF and GF)
        /// </summary>
        [DataMember(Name = "stats")]
        public CharacterStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FollowerType.ToString();
        }
    }
}
