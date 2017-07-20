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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   response for talents API call
    /// </summary>
    [DataContract]
    public class TalentsResponse : ApiResponse
    {
        /// <summary>
        ///   gets or sets warrior talents
        /// </summary>
        [DataMember(Name = "1", IsRequired = false)]
        public ClassTalentInfo Warrior
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets paladin talents
        /// </summary>
        [DataMember(Name = "2", IsRequired = false)]
        public ClassTalentInfo Paladin
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets hunter talents
        /// </summary>
        [DataMember(Name = "3", IsRequired = false)]
        public ClassTalentInfo Hunter
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets rogue talents
        /// </summary>
        [DataMember(Name = "4", IsRequired = false)]
        public ClassTalentInfo Rogue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets priest talents
        /// </summary>
        [DataMember(Name = "5", IsRequired = false)]
        public ClassTalentInfo Priest
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets death knight talents
        /// </summary>
        [DataMember(Name = "6", IsRequired = false)]
        public ClassTalentInfo DeathKnight
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets shaman talents
        /// </summary>
        [DataMember(Name = "7", IsRequired = false)]
        public ClassTalentInfo Shaman
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets mage talents
        /// </summary>
        [DataMember(Name = "8", IsRequired = false)]
        public ClassTalentInfo Mage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets warlock talents
        /// </summary>
        [DataMember(Name = "9", IsRequired = false)]
        public ClassTalentInfo Warlock
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets monk talents
        /// </summary>
        [DataMember(Name = "10", IsRequired = false)]
        public ClassTalentInfo Monk
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets druid talents
        /// </summary>
        [DataMember(Name = "11", IsRequired = false)]
        public ClassTalentInfo Druid
        {
            get;
            internal set;
        }
    }
}