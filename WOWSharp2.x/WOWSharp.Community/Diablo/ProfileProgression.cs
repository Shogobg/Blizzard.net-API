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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// Diablo profile progression
    /// </summary>
    [DataContract]
    public class ProfileProgression
    {
        /// <summary>
        /// Whether the player completed act1
        /// </summary>
        [DataMember(Name = "act1", IsRequired = true)]
        public bool Act1
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act2
        /// </summary>
        [DataMember(Name = "act2", IsRequired = true)]
        public bool Act2
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act3
        /// </summary>
        [DataMember(Name = "act3", IsRequired = true)]
        public bool Act3
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act4
        /// </summary>
        [DataMember(Name = "act4", IsRequired = true)]
        public bool Act4
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act5
        /// </summary>
        [DataMember(Name = "act5", IsRequired = true)]
        public bool Act5
        {
            get;
            set;
        }
    }
}
