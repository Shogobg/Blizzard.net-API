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
    /// Represents information about item's gems, enchants and reforging
    /// </summary>
    [DataContract]
    [Serializable]
    public class EquippedItemParameters : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the id of the enchant
        /// </summary>
        [DataMember(Name="enchant", IsRequired = false)]
        public int? Enchant
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the first gem
        /// </summary>
        [DataMember(Name = "gem0", IsRequired = false)]
        public int? Gem0
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the second gem
        /// </summary>
        [DataMember(Name = "gem1", IsRequired = false)]
        public int? Gem1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the third gem
        /// </summary>
        [DataMember(Name = "gem2", IsRequired = false)]
        public int? Gem2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the fourth gem
        /// </summary>
        [DataMember(Name = "gem3", IsRequired = false)]
        public int? Gem3
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the items equipped from the same set
        /// </summary>
        [DataMember(Name = "set", IsRequired = false)]
        public int[] SetItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the id of the tinker
        /// </summary>
        [DataMember(Name = "tinker", IsRequired = false)]
        public int? Tinker
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the id of reforge
        /// </summary>
        [DataMember(Name = "reforge", IsRequired = false)]
        public int? Reforge
        {
            get;
            set;
        }

        [DataMember(Name = "transmodItem", IsRequired = false)]
        public int? TransmogyItemId
        {
            get;
            set;
        }
    }
}
