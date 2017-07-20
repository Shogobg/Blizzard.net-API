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
    /// Represents information about character's equipped items
    /// </summary>
    [DataContract]
    [Serializable]
    public class CharacterItems : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the average item level of the best equiment of the character
        /// </summary>
        [DataMember(Name="averageItemLevel", IsRequired=true, Order=0)]
        public int AverageItemLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the average item level of the items currently equipped by the character
        /// </summary>
        [DataMember(Name = "averageItemLevelEquipped", IsRequired = true)]
        public int AverageItemLevelEquipped
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the back slot by the character
        /// </summary>
        [DataMember(Name = "back", IsRequired = false)]
        public EquippedItem Back
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the chest slot by the character
        /// </summary>
        [DataMember(Name = "chest", IsRequired = false)]
        public EquippedItem Chest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the feet slot by the character
        /// </summary>
        [DataMember(Name = "feet", IsRequired = false)]
        public EquippedItem Feet
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the finger 1 slot by the character
        /// </summary>
        [DataMember(Name = "finger1", IsRequired = false)]
        public EquippedItem Finger1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the finger 2 slot by the character
        /// </summary>
        [DataMember(Name = "finger2", IsRequired = false)]
        public EquippedItem Finger2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the hands slot by the character
        /// </summary>
        [DataMember(Name = "hands", IsRequired = false)]
        public EquippedItem Hands
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the head slot by the character
        /// </summary>
        [DataMember(Name = "head", IsRequired = false)]
        public EquippedItem Head
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the legs slot by the character
        /// </summary>
        [DataMember(Name = "legs", IsRequired = false)]
        public EquippedItem Legs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the main hand slot by the character
        /// </summary>
        [DataMember(Name = "mainHand", IsRequired = false)]
        public EquippedItem MainHand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the off hand slot by the character
        /// </summary>
        [DataMember(Name = "offHand", IsRequired = false)]
        public EquippedItem OffHand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the neck slot by the character
        /// </summary>
        [DataMember(Name = "neck", IsRequired = false)]
        public EquippedItem Neck
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the ranged slot by the character
        /// </summary>
        [DataMember(Name = "ranged", IsRequired = false)]
        public EquippedItem Ranged
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the shirt slot by the character
        /// </summary>
        [DataMember(Name = "shirt", IsRequired = false)]
        public EquippedItem Shirt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the shoulder slot by the character
        /// </summary>
        [DataMember(Name = "shoulder", IsRequired = false)]
        public EquippedItem Shoulder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the tabard slot by the character
        /// </summary>
        [DataMember(Name = "tabard", IsRequired = false)]
        public EquippedItem Tabard
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the trinket 1 slot by the character
        /// </summary>
        [DataMember(Name = "trinket1", IsRequired = false)]
        public EquippedItem Trinket1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the trinket 2 slot by the character
        /// </summary>
        [DataMember(Name = "trinket2", IsRequired = false)]
        public EquippedItem Trinket2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the waist slot by the character
        /// </summary>
        [DataMember(Name = "waist", IsRequired = false)]
        public EquippedItem Waist
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item equipped in the wrist slot by the character
        /// </summary>
        [DataMember(Name = "wrist", IsRequired = false)]
        public EquippedItem Wrist
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the item equipped in the specified slot
        /// </summary>
        /// <param name="slotName">name of the equipment slot</param>
        /// <returns>The item equipped by the character in the specified slot</returns>
        public EquippedItem this[EquipmentSlot slotName]
        {
            get
            {
                switch (slotName)
                {
                    case EquipmentSlot.Head:
                        return this.Head;
                    case EquipmentSlot.Neck:
                        return this.Neck;
                    case EquipmentSlot.Shoulder:
                        return this.Shoulder;
                    case EquipmentSlot.Chest:
                        return this.Chest;
                    case EquipmentSlot.Back:
                        return this.Back;
                    case EquipmentSlot.Shirt:
                        return this.Shirt;
                    case EquipmentSlot.Wrist:
                        return this.Wrist;
                    case EquipmentSlot.Hands:
                        return this.Hands;
                    case EquipmentSlot.Waist:
                        return this.Waist;
                    case EquipmentSlot.Legs:
                        return this.Legs;
                    case EquipmentSlot.Feet:
                        return this.Feet;
                    case EquipmentSlot.Finger1:
                        return this.Finger1;
                    case EquipmentSlot.Finger2:
                        return this.Finger2;
                    case EquipmentSlot.Trinket1:
                        return this.Trinket1;
                    case EquipmentSlot.Trinket2:
                        return this.Trinket2;
                    case EquipmentSlot.MainHand:
                        return this.MainHand;
                    case EquipmentSlot.OffHand:
                        return this.OffHand;
                    case EquipmentSlot.Ranged:
                        return this.Ranged;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets all items equipped by the character
        /// </summary>
        public IEnumerable<EquippedItem> AllItems
        {
            get
            {
                return EnumHelper<EquipmentSlot>.GetValues()
                    .Select(slot => this[slot])
                    .Where(equippedItem => equippedItem != null);
            }
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("Average ilvl {0}, Equipped {1}", this.AverageItemLevel, this.AverageItemLevelEquipped);
        }
    }
}
