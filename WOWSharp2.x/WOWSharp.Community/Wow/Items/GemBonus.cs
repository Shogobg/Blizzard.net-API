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
    ///   Represents gem's bonus
    /// </summary>
    [DataContract]
    public class GemBonus
    {
        /// <summary>
        ///   The socket bonus description (e.g. "+20 Agility and +20 Hit Rating")
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets source item id. This is the same as item id for the gem
        /// </summary>
        [DataMember(Name = "srcItemId", IsRequired = true)]
        public int SourceItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets The required skill
        /// </summary>
        [DataMember(Name = "requiredSkillId", IsRequired = true)]
        public Skill RequiredSkillId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required skill rank
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredSkillRank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required gem's item level
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = true)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required level for the gem
        /// </summary>
        [DataMember(Name = "minLevel", IsRequired = false)]
        public int MinimumLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}