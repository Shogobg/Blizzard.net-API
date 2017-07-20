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

using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about an item use spell or an item's proc
    /// </summary>
    [DataContract]
    public class ItemSpell
    {
        /// <summary>
        ///   Gets or sets the item is consumed when the spell is used
        /// </summary>
        private bool _consumable;

        /// <summary>
        ///   Gets or sets the item's spell cooldown category (used to determine which items share CD with that item)
        /// </summary>
        private int _coolDownCategoryId;

        /// <summary>
        ///   Gets or sets the number of times the spell can be used (0 means unlimited)
        /// </summary>
        private int _numberOfCharges;

        /// <summary>
        ///   Gets or sets the item spell information
        /// </summary>
        private Spell _spell;

        /// <summary>
        ///   Gets or sets the spell id
        /// </summary>
        private int _spellId;

        /// <summary>
        ///   Gets or sets how the item spell is triggered
        /// </summary>
        private ItemSpellTriggers _trigger;

        /// <summary>
        ///   Gets or sets the spell id
        /// </summary>
        [DataMember(Name = "spellId", IsRequired = true)]
        public int SpellId
        {
            get
            {
                return _spellId;
            }
            internal set
            {
                _spellId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item spell information
        /// </summary>
        [DataMember(Name = "spell", IsRequired = false)]
        public Spell Spell
        {
            get
            {
                return _spell;
            }
            internal set
            {
                _spell = value;
            }
        }

        /// <summary>
        ///   Gets or sets the number of times the spell can be used (0 means unlimited)
        /// </summary>
        [DataMember(Name = "nCharges", IsRequired = true)]
        public int NumberOfCharges
        {
            get
            {
                return _numberOfCharges;
            }
            internal set
            {
                _numberOfCharges = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item is consumed when the spell is used
        /// </summary>
        [DataMember(Name = "consumable", IsRequired = true)]
        public bool Consumable
        {
            get
            {
                return _consumable;
            }
            internal set
            {
                _consumable = value;
            }
        }

        /// <summary>
        ///   Gets or sets how the item spell is triggered
        /// </summary>
        public ItemSpellTriggers Trigger
        {
            get
            {
                return _trigger;
            }
            internal set
            {
                _trigger = value;
            }
        }

        /// <summary>
        ///   Gets or sets how the item spell is triggered
        /// </summary>
        [DataMember(Name = "trigger", IsRequired = true)]
        public string TriggerName
        {
            get
            {
                return EnumHelper<ItemSpellTriggers>.EnumToString(Trigger);
            }
            internal set
            {
                Trigger = EnumHelper<ItemSpellTriggers>.ParseEnum(value);
            }
        }


        /// <summary>
        ///   Gets or sets the item's spell cooldown category (used to determine which items share CD with that item)
        /// </summary>
        [DataMember(Name = "categoryId", IsRequired = true)]
        public int CoolDownCategoryId
        {
            get
            {
                return _coolDownCategoryId;
            }
            internal set
            {
                _coolDownCategoryId = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Spell == null ? "" : Spell.ToString();
        }
    }
}