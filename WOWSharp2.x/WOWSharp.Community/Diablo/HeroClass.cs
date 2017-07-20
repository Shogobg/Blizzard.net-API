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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// A diablo hero class
    /// </summary>
    [DataContract]
    public enum HeroClass
    {
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Barbarian
        /// </summary>
        [EnumMember(Value = "barbarian")]
        Barbarian = 1,

        /// <summary>
        /// Demon hunter
        /// </summary>
        [EnumMember(Value = "demon-hunter")]
        DemonHunter = 2,

        /// <summary>
        /// Monk
        /// </summary>
        [EnumMember(Value = "monk")]
        Monk = 3,

        /// <summary>
        /// Witch Doctor
        /// </summary>
        [EnumMember(Value = "witch-doctor")]
        Witchdoctor = 4,
        
        /// <summary>
        /// Wizard
        /// </summary>
        [EnumMember(Value = "wizard")]
        Wizard = 5,

        /// <summary>
        /// Crusader
        /// </summary>
        [EnumMember(Value = "crusader")]
        Crusader = 6
    }
}
