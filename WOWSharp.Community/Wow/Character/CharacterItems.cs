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
        [DataMember(Name = "averageItemLevel", IsRequired = true, Order = 0)]
        public int AverageItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the average item level of the items currently equipped by the character
        /// </summary>
        [DataMember(Name = "averageItemLevelEquipped", IsRequired = true)]
        public int AverageItemLevelEquipped
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the back slot by the character
        /// </summary>
        [DataMember(Name = "back", IsRequired = false)]
        public EquippedItem Back
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the chest slot by the character
        /// </summary>
        [DataMember(Name = "chest", IsRequired = false)]
        public EquippedItem Chest
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the feet slot by the character
        /// </summary>
        [DataMember(Name = "feet", IsRequired = false)]
        public EquippedItem Feet
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 1 slot by the character
        /// </summary>
        [DataMember(Name = "finger1", IsRequired = false)]
        public EquippedItem Finger1
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 2 slot by the character
        /// </summary>
        [DataMember(Name = "finger2", IsRequired = false)]
        public EquippedItem Finger2
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the hands slot by the character
        /// </summary>
        [DataMember(Name = "hands", IsRequired = false)]
        public EquippedItem Hands
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the head slot by the character
        /// </summary>
        [DataMember(Name = "head", IsRequired = false)]
        public EquippedItem Head
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the legs slot by the character
        /// </summary>
        [DataMember(Name = "legs", IsRequired = false)]
        public EquippedItem Legs
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the main hand slot by the character
        /// </summary>
        [DataMember(Name = "mainHand", IsRequired = false)]
        public EquippedItem MainHand
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the off hand slot by the character
        /// </summary>
        [DataMember(Name = "offHand", IsRequired = false)]
        public EquippedItem Offhand
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the neck slot by the character
        /// </summary>
        [DataMember(Name = "neck", IsRequired = false)]
        public EquippedItem Neck
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shirt slot by the character
        /// </summary>
        [DataMember(Name = "shirt", IsRequired = false)]
        public EquippedItem Shirt
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shoulder slot by the character
        /// </summary>
        [DataMember(Name = "shoulder", IsRequired = false)]
        public EquippedItem Shoulder
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the tabard slot by the character
        /// </summary>
        [DataMember(Name = "tabard", IsRequired = false)]
        public EquippedItem Tabard
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 1 slot by the character
        /// </summary>
        [DataMember(Name = "trinket1", IsRequired = false)]
        public EquippedItem Trinket1
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 2 slot by the character
        /// </summary>
        [DataMember(Name = "trinket2", IsRequired = false)]
        public EquippedItem Trinket2
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the waist slot by the character
        /// </summary>
        [DataMember(Name = "waist", IsRequired = false)]
        public EquippedItem Waist
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the wrist slot by the character
        /// </summary>
        [DataMember(Name = "wrist", IsRequired = false)]
        public EquippedItem Wrist
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets the item equipped in the specified slot
        /// </summary>
        /// <param name="slotName"> name of the equipment slot </param>
        /// <returns> The item equipped by the character in the specified slot </returns>
        public EquippedItem getEquippedItem(EquipmentSlot slotName)
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
				default:
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
                    .Select(slot => getEquippedItem(slot))
                    .Where(equippedItem => equippedItem != null);
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(
				CultureInfo.CurrentCulture, "Average ilvl {0}, Equipped {1}",
				AverageItemLevel,
				AverageItemLevelEquipped
			);
        }
    }
}