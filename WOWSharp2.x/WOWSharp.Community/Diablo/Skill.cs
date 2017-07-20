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
    /// a class skill
    /// </summary>
    [DataContract]
    public class Skill
    {
        /// <summary>
        /// Slug (locale independent identifier)
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug
        {
            get;
            internal set;
        }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Icon. Use the following format string to download the image.
        /// Where {0} is the Icon property returned by this property
        /// And {1} is the size (Available sizes that I know of are 21, 42 and 64)
        /// http://media.blizzard.com/d3/icons/skills/{1}/{0}.png
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        /// The level at which the skill is unlocked
        /// </summary>
        [DataMember(Name = "level")]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// Category slug
        /// </summary>
        [DataMember(Name = "categorySlug")]
        public string CategorySlug
        {
            get;
            internal set;
        }

        /// <summary>
        /// Tool tip url.
        /// To retrieve the tooltip use the following format string
        /// Where 
        /// {0} is lang (en, es, pt, it, etc)
        /// {1} is the tooltip returned from this property
        /// {2} is the host (eu.battle.net, etc)
        /// {3} is protocol (http or https)
        /// {4}://{2}/d3/{0}/tooltip/{1} 
        /// </summary>
        [DataMember(Name = "tooltipUrl")]
        public string TooltipPath
        {
            get;
            internal set;
        }

        /// <summary>
        /// Skill description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        /// Simple skill description
        /// </summary>
        [DataMember(Name = "simpleDescription")]
        public string SimpleDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// Skill's id in Blizzard's skill calculator
        /// </summary>
        [DataMember(Name = "skillCalcId")]
        public string SkillCalculatorId
        {
            get;
            set;
        }

        /// <summary>
        /// passive skill's flavour text
        /// </summary>
        [DataMember(Name = "flavor")]
        public string Flavor
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
