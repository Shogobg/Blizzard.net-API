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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about character's equipped items
    /// </summary>
    [DataContract]
    public class CharacterItems
    {
        /// <summary>
        ///   Gets or sets the average item level of the best equiment of the character
        /// </summary>
        private int _averageItemLevel;

        /// <summary>
        ///   Gets or sets the average item level of the items currently equipped by the character
        /// </summary>
        private int _averageItemLevelEquipped;

        /// <summary>
        ///   Gets or sets the item equipped in the back slot by the character
        /// </summary>
        private EquippedItem _back;

        /// <summary>
        ///   Gets or sets the item equipped in the chest slot by the character
        /// </summary>
        private EquippedItem _chest;

        /// <summary>
        ///   Gets or sets the item equipped in the feet slot by the character
        /// </summary>
        private EquippedItem _feet;

        /// <summary>
        ///   Gets or sets the item equipped in the finger 1 slot by the character
        /// </summary>
        private EquippedItem _finger1;

        /// <summary>
        ///   Gets or sets the item equipped in the finger 2 slot by the character
        /// </summary>
        private EquippedItem _finger2;

        /// <summary>
        ///   Gets or sets the item equipped in the hands slot by the character
        /// </summary>
        private EquippedItem _hands;

        /// <summary>
        ///   Gets or sets the item equipped in the head slot by the character
        /// </summary>
        private EquippedItem _head;

        /// <summary>
        ///   Gets or sets the item equipped in the legs slot by the character
        /// </summary>
        private EquippedItem _legs;

        /// <summary>
        ///   Gets or sets the item equipped in the main hand slot by the character
        /// </summary>
        private EquippedItem _mainHand;

        /// <summary>
        ///   Gets or sets the item equipped in the neck slot by the character
        /// </summary>
        private EquippedItem _neck;

        /// <summary>
        ///   Gets or sets the item equipped in the off hand slot by the character
        /// </summary>
        private EquippedItem _offhand;

        /// <summary>
        ///   Gets or sets the item equipped in the shirt slot by the character
        /// </summary>
        private EquippedItem _shirt;

        /// <summary>
        ///   Gets or sets the item equipped in the shoulder slot by the character
        /// </summary>
        private EquippedItem _shoulder;

        /// <summary>
        ///   Gets or sets the item equipped in the tabard slot by the character
        /// </summary>
        private EquippedItem _tabard;

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 1 slot by the character
        /// </summary>
        private EquippedItem _trinket1;

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 2 slot by the character
        /// </summary>
        private EquippedItem _trinket2;

        /// <summary>
        ///   Gets or sets the item equipped in the waist slot by the character
        /// </summary>
        private EquippedItem _waist;

        /// <summary>
        ///   Gets or sets the item equipped in the wrist slot by the character
        /// </summary>
        private EquippedItem _wrist;

        /// <summary>
        ///   Gets or sets the average item level of the best equiment of the character
        /// </summary>
        [DataMember(Name = "averageItemLevel", IsRequired = true, Order = 0)]
        public int AverageItemLevel
        {
            get
            {
                return _averageItemLevel;
            }
            internal set
            {
                _averageItemLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the average item level of the items currently equipped by the character
        /// </summary>
        [DataMember(Name = "averageItemLevelEquipped", IsRequired = true)]
        public int AverageItemLevelEquipped
        {
            get
            {
                return _averageItemLevelEquipped;
            }
            internal set
            {
                _averageItemLevelEquipped = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the back slot by the character
        /// </summary>
        [DataMember(Name = "back", IsRequired = false)]
        public EquippedItem Back
        {
            get
            {
                return _back;
            }
            internal set
            {
                _back = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the chest slot by the character
        /// </summary>
        [DataMember(Name = "chest", IsRequired = false)]
        public EquippedItem Chest
        {
            get
            {
                return _chest;
            }
            internal set
            {
                _chest = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the feet slot by the character
        /// </summary>
        [DataMember(Name = "feet", IsRequired = false)]
        public EquippedItem Feet
        {
            get
            {
                return _feet;
            }
            internal set
            {
                _feet = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 1 slot by the character
        /// </summary>
        [DataMember(Name = "finger1", IsRequired = false)]
        public EquippedItem Finger1
        {
            get
            {
                return _finger1;
            }
            internal set
            {
                _finger1 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 2 slot by the character
        /// </summary>
        [DataMember(Name = "finger2", IsRequired = false)]
        public EquippedItem Finger2
        {
            get
            {
                return _finger2;
            }
            internal set
            {
                _finger2 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the hands slot by the character
        /// </summary>
        [DataMember(Name = "hands", IsRequired = false)]
        public EquippedItem Hands
        {
            get
            {
                return _hands;
            }
            internal set
            {
                _hands = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the head slot by the character
        /// </summary>
        [DataMember(Name = "head", IsRequired = false)]
        public EquippedItem Head
        {
            get
            {
                return _head;
            }
            internal set
            {
                _head = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the legs slot by the character
        /// </summary>
        [DataMember(Name = "legs", IsRequired = false)]
        public EquippedItem Legs
        {
            get
            {
                return _legs;
            }
            internal set
            {
                _legs = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the main hand slot by the character
        /// </summary>
        [DataMember(Name = "mainHand", IsRequired = false)]
        public EquippedItem MainHand
        {
            get
            {
                return _mainHand;
            }
            internal set
            {
                _mainHand = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the off hand slot by the character
        /// </summary>
        [DataMember(Name = "offHand", IsRequired = false)]
        public EquippedItem Offhand
        {
            get
            {
                return _offhand;
            }
            internal set
            {
                _offhand = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the neck slot by the character
        /// </summary>
        [DataMember(Name = "neck", IsRequired = false)]
        public EquippedItem Neck
        {
            get
            {
                return _neck;
            }
            internal set
            {
                _neck = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shirt slot by the character
        /// </summary>
        [DataMember(Name = "shirt", IsRequired = false)]
        public EquippedItem Shirt
        {
            get
            {
                return _shirt;
            }
            internal set
            {
                _shirt = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shoulder slot by the character
        /// </summary>
        [DataMember(Name = "shoulder", IsRequired = false)]
        public EquippedItem Shoulder
        {
            get
            {
                return _shoulder;
            }
            internal set
            {
                _shoulder = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the tabard slot by the character
        /// </summary>
        [DataMember(Name = "tabard", IsRequired = false)]
        public EquippedItem Tabard
        {
            get
            {
                return _tabard;
            }
            internal set
            {
                _tabard = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 1 slot by the character
        /// </summary>
        [DataMember(Name = "trinket1", IsRequired = false)]
        public EquippedItem Trinket1
        {
            get
            {
                return _trinket1;
            }
            internal set
            {
                _trinket1 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 2 slot by the character
        /// </summary>
        [DataMember(Name = "trinket2", IsRequired = false)]
        public EquippedItem Trinket2
        {
            get
            {
                return _trinket2;
            }
            internal set
            {
                _trinket2 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the waist slot by the character
        /// </summary>
        [DataMember(Name = "waist", IsRequired = false)]
        public EquippedItem Waist
        {
            get
            {
                return _waist;
            }
            internal set
            {
                _waist = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item equipped in the wrist slot by the character
        /// </summary>
        [DataMember(Name = "wrist", IsRequired = false)]
        public EquippedItem Wrist
        {
            get
            {
                return _wrist;
            }
            internal set
            {
                _wrist = value;
            }
        }

        /// <summary>
        ///   Gets the item equipped in the specified slot
        /// </summary>
        /// <param name="slotName"> name of the equipment slot </param>
        /// <returns> The item equipped by the character in the specified slot </returns>
        public EquippedItem this[EquipmentSlot slotName]
        {
            get
            {
                switch (slotName)
                {
                    case EquipmentSlot.Head:
                        return Head;
                    case EquipmentSlot.Neck:
                        return Neck;
                    case EquipmentSlot.Shoulder:
                        return Shoulder;
                    case EquipmentSlot.Chest:
                        return Chest;
                    case EquipmentSlot.Back:
                        return Back;
                    case EquipmentSlot.Shirt:
                        return Shirt;
                    case EquipmentSlot.Wrist:
                        return Wrist;
                    case EquipmentSlot.Hands:
                        return Hands;
                    case EquipmentSlot.Waist:
                        return Waist;
                    case EquipmentSlot.Legs:
                        return Legs;
                    case EquipmentSlot.Feet:
                        return Feet;
                    case EquipmentSlot.Finger1:
                        return Finger1;
                    case EquipmentSlot.Finger2:
                        return Finger2;
                    case EquipmentSlot.Trinket1:
                        return Trinket1;
                    case EquipmentSlot.Trinket2:
                        return Trinket2;
                    case EquipmentSlot.MainHand:
                        return MainHand;
                    case EquipmentSlot.Offhand:
                        return Offhand;
                    case EquipmentSlot.Tabard:
                        return Tabard;
                }
                return null;
            }
        }

        /// <summary>
        ///   Gets all items equipped by the character
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
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Average ilvl {0}, Equipped {1}", AverageItemLevel,
                                 AverageItemLevelEquipped);
        }
    }
}