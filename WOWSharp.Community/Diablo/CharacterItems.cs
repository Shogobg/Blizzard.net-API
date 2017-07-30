using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Items equipped by a hero or a follower
	/// </summary>
	[DataContract]
    public class CharacterItems
    {
        /// <summary>
        /// Bracers
        /// </summary>
        [DataMember(Name = "bracers", IsRequired = false)]
        public Item Bracers
        {
            get;
            internal set;
        }

        /// <summary>
        /// feet
        /// </summary>
        [DataMember(Name = "feet", IsRequired = false)]
        public Item Feet
        {
            get;
            internal set;
        }

        /// <summary>
        /// Hands
        /// </summary>
        [DataMember(Name = "hands", IsRequired = false)]
        public Item Hands
        {
            get;
            internal set;
        }

        /// <summary>
        /// left finger
        /// </summary>
        [DataMember(Name = "leftFinger", IsRequired = false)]
        public Item LeftFinger
        {
            get;
            internal set;
        }

        /// <summary>
        /// head
        /// </summary>
        [DataMember(Name = "head", IsRequired = false)]
        public Item Head
        {
            get;
            internal set;
        }

        /// <summary>
        /// Legs
        /// </summary>
        [DataMember(Name = "legs", IsRequired = false)]
        public Item Legs
        {
            get;
            internal set;
        }

        /// <summary>
        /// Main Hand
        /// </summary>
        [DataMember(Name = "mainHand", IsRequired = false)]
        public Item MainHand
        {
            get;
            internal set;
        }

        /// <summary>
        /// Neck
        /// </summary>
        [DataMember(Name = "neck", IsRequired = false)]
        public Item Neck
        {
            get;
            internal set;
        }

        /// <summary>
        /// off hand
        /// </summary>
        [DataMember(Name = "offHand", IsRequired = false)]
        public Item Offhand
        {
            get;
            internal set;
        }

        /// <summary>
        /// Right finger
        /// </summary>
        [DataMember(Name = "rightFinger", IsRequired = false)]
        public Item RightFinger
        {
            get;
            internal set;
        }

        /// <summary>
        /// Shoulders
        /// </summary>
        [DataMember(Name = "shoulders", IsRequired = false)]
        public Item Shoulders
        {
            get;
            internal set;
        }

        /// <summary>
        /// Torso
        /// </summary>
        [DataMember(Name = "torso", IsRequired = false)]
        public Item Torso
        {
            get;
            internal set;
        }

        /// <summary>
        /// Waist
        /// </summary>
        [DataMember(Name = "waist", IsRequired = false)]
        public Item Waist
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower's special
        /// </summary>
        [DataMember(Name = "special", IsRequired = false)]
        public Item FollowerSpecial
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets all items equipped by a character
        /// </summary>
        public IEnumerable<Item> AllItems
        {
            get
            {
                foreach (var slot in EnumHelper<EquipmentSlot>.GetValues())
                {
                    var item = getEquippedItem(slot);

					if (item != null)
					{
						yield return item;
					}
                }
            }
        }

        /// <summary>
        /// Gets the item equipped in the specified slot
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public Item getEquippedItem(EquipmentSlot slot)
        {
			switch(slot)
			{
			    case EquipmentSlot.Bracers:
			        return Bracers;
			    case EquipmentSlot.Feet:
			        return Feet;
			    case EquipmentSlot.FollowerSpecial: 
			        return FollowerSpecial;
			    case EquipmentSlot.Hands:
			        return Hands;
			    case EquipmentSlot.Head:
			        return Head;
			    case EquipmentSlot.LeftFinger:
			        return LeftFinger;
			    case EquipmentSlot.Legs:
			        return Legs;
			    case EquipmentSlot.MainHand:
			        return MainHand;
			    case EquipmentSlot.Neck:
			        return Neck;
			    case EquipmentSlot.Offhand:
			        return Offhand;
			    case EquipmentSlot.RightFinger:
			        return RightFinger;
			    case EquipmentSlot.Shoulders:
			        return Shoulders;
			    case EquipmentSlot.Torso:
			        return Torso;
			    case EquipmentSlot.Waist:
			        return Waist;
				default:
					return null;
			}
        }
    }
}
