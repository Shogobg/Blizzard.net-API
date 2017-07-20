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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about a character's equipped item
    /// </summary>
    [DataContract]
    public class EquippedItem
    {
        /// <summary>
        ///   Gets or sets the item's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's level 
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = true)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about gems, enchants, reforging and tinkers
        /// </summary>
        [DataMember(Name = "tooltipParams", IsRequired = false)]
        public EquippedItemParameters Parameters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the equipped item stats
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public IList<ItemStat> Stats
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        [DataMember(Name = "weaponInfo", IsRequired = false)]
        public WeaponInfo WeaponInfo
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = false)]
        public int Armor
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