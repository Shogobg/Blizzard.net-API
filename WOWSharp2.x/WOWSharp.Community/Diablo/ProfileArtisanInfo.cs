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
    /// A character's artisan information
    /// </summary>
    [DataContract]
    public class ProfileArtisanInfo
    {
        /// <summary>
        /// Gets or sets Artisan's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets artisan's type
        /// </summary>
        [DataMember(Name = "slug", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ArtisanType ArtisanType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the current step in the progress to the next level
        /// </summary>
        [DataMember(Name = "stepCurrent", IsRequired = true)]
        public int CurrentStep
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the maximum step (i.e. the total number of steps) required to reach the next level
        /// </summary>
        [DataMember(Name = "stepMax", IsRequired = true)]
        public int MaximumStep
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
            return string.Format(CultureInfo.InvariantCulture, "{0} Level {1}", ArtisanType, Level);
        }
    }
}
