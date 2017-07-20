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
    /// Follower infromation
    /// </summary>
    [DataContract]
    public class Follower : ApiResponse
    {
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
        /// Follower name (in client's locale)
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower real name (d3.follower.templar.realName)
        /// </summary>
        [DataMember(Name = "realName")]
        public string RealName
        {
            get;
            internal set;
        }

        /// <summary>
        /// follower portrait
        /// To get the image use the following format string
        /// {0} is size (Available sizes that I know of are 42 and 64)
        /// {1} is the property value returned by this property
        /// http://media.blizzard.com/d3/icons/portraits/{0}/{1}.png
        /// </summary>
        [DataMember(Name = "portrait")]
        public string Portrait
        {
            get;
            internal set;
        }

        /// <summary>
        /// The skills that the follower can learn skills
        /// </summary>
        [DataMember(Name = "skills")]
        public FollowerSkills Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FollowerType.ToString();
        }
    }
}
