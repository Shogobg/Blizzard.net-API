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
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// The time played statistics for different classes
    /// </summary>
    [DataContract]
    public class TimePlayedStatistics
    {
        /// <summary>
        /// Time played with barbarian
        /// </summary>
        [DataMember(Name = "barbarian", IsRequired = false)]
        public double Barbarian
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with demon hunter
        /// </summary>
        [DataMember(Name = "demon-hunter", IsRequired = false)]
        public double DemonHunter
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with monk
        /// </summary>
        [DataMember(Name = "monk", IsRequired = false)]
        public double Monk
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with witch doctor
        /// </summary>
        [DataMember(Name = "witch-doctor", IsRequired = false)]
        public double Witchdoctor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with wizard
        /// </summary>
        [DataMember(Name = "wizard", IsRequired = false)]
        public double Wizard
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with crusader
        /// </summary>
        [DataMember(Name = "crusader", IsRequired = false)]
        public double Crusader
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets string representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Barbarian {0}, Demon Hunter {1}, Monk {2}, Witch Doctor {3}, Wizard {4}, Crusader {5}", Barbarian, DemonHunter, Monk, Wizard, Witchdoctor, Crusader);
        }
    }
}
