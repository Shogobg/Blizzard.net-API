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
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about character's instance progression
    /// </summary>
    [DataContract]
    public class CharacterInstanceProgression
    {
        /// <summary>
        ///   Gets or sets the instance name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the instance
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's current progression status in the normal mode for the instance
        /// </summary>
        [DataMember(Name = "normal", IsRequired = false)]
        public CharacterInstanceStatus NormalProgress
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's current progression status in the heroic mode for the instance
        /// </summary>
        [DataMember(Name = "heroic", IsRequired = false)]
        public CharacterInstanceStatus HeroicProgress
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about character individual boss kills in the instance
        /// </summary>
        [DataMember(Name = "bosses", IsRequired = false)]
        public IList<CharacterBossKills> Bosses
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
            return string.Format(CultureInfo.CurrentCulture, "{0} Normal:{1} Heroic:{2}", Name, NormalProgress,
                                 HeroicProgress);
        }
    }
}