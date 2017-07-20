/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents information about a spell
    /// </summary>
    [Serializable]
    [DataContract]
    public class Spell : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the spell's id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's sub text (typically the spell rank)
        /// </summary>
        [DataMember(Name = "subtext", IsRequired = false)]
        public string SubText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's range
        /// </summary>
        [DataMember(Name = "range", IsRequired = false)]
        public string Range
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the spell's cast time
        /// </summary>
        [DataMember(Name = "castTime", IsRequired = false)]
        public string CastTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
