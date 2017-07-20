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
    [DataContract]
    public class ItemAffix
    {
        /// <summary>
        /// Affix text description
        /// </summary>
        [DataMember(Name = "text")]
        public string Text
        {
            get;
            set;
        }


        /// <summary>
        /// Affix type
        /// </summary>
        [DataMember(Name = "affixType")]
        public ItemAffixType Type
        {
            get;
            internal set;
        }

        /// <summary>
        /// Text color
        /// </summary>
        [DataMember(Name = "color")]
        public ItemAffixColor TextColor
        {
            get;
            internal set;
        }

        /// <summary>
        /// If the affix is a random affix that can roll one of several affix choices
        /// </summary>
        [DataMember(Name = "oneOf")]
        public IList<RandomAffixAttributes> OneOf
        {
            get;
            internal set;
        }

        
        /// <summary>
        /// String value for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
