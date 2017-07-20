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
    /// Represents an in game item
    /// </summary>
    [DataContract]
    [Serializable]
    public class Item : ApiResponse
    {
        /// <summary>
        /// Gets or sets the item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the enchanting skill rank required to disenchant the item. If the value is -1 or null, it means the item cannot be disenchanted.
        /// </summary>
        [DataMember(Name = "disenchantingSkillRank", IsRequired = false)]
        public int? DisenchantingSkillRank
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max stack size for this item in inventory.
        /// </summary>
        [DataMember(Name = "stackable", IsRequired = true)]
        public int MaxStackSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ids of the classes allowed to use/equip this item. A null value means all classes can use the item
        /// </summary>
        [DataMember(Name = "allowableClasses", IsRequired = false)]
        public Class[] AllowableClasses
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item bind type
        /// </summary>
        [DataMember(Name = "itemBind", IsRequired = true)]
        public ItemBindType BindType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's bonus stats
        /// </summary>
        [DataMember(Name = "bonusStats", IsRequired = false)]
        public ItemStat[] BonusStats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's spells (procs and use effects)
        /// </summary>
        [DataMember(Name = "itemSpells", IsRequired = false)]
        public ItemSpell[] ItemSpells
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item buy from vendor price (the price a character would pay to buy the item from an NPC vendor)
        /// </summary>
        [DataMember(Name = "buyPrice", IsRequired = true)]
        public long BuyPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item category
        /// </summary>
        [DataMember(Name = "itemClass", IsRequired = true)]
        public ItemCategory Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item sub category
        /// </summary>
        [DataMember(Name = "itemSubClass", IsRequired = true)]
        public int SubCategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item sub category
        /// </summary>
        public ItemSubCategory SubCategory
        {
            get
            {
                unchecked
                {
                    return (ItemSubCategory)(((int)this.Category << 16) | this.SubCategoryId);
                }
            }
            set
            {
                unchecked
                {
                    this.SubCategoryId = (int)value & 0xffff;
                    this.Category = (ItemCategory)(((int)value & 0xffff) >> 16);
                }
            }
        }

        /// <summary>
        /// Gets or sets the container item slots (the value is zero if the item is not a container)
        /// </summary>
        [DataMember(Name = "containerSlots", IsRequired = false)]
        public int ContainerSlots
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the gem's information (this is null if the item is not a gem)
        /// </summary>
        [DataMember(Name = "gemInfo", IsRequired = false)]
        public GemInfo GemInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        [DataMember(Name = "weaponInfo", IsRequired = false)]
        public WeaponInfo WeaponInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's inventory type
        /// </summary>
        [DataMember(Name = "inventoryType", IsRequired = false)]
        public ItemInventoryType? InventoryType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item can be equipped
        /// </summary>
        [DataMember(Name = "equippable", IsRequired = true)]
        public bool Equippable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's level (ilvl)
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = false)]
        public int ItemLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's set id (if the item belongs to a set)
        /// </summary>
        [DataMember(Name = "itemSet", IsRequired = false)]
        public string ItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max quantity of the item that can be carried by a character. If the value is zero, then max amount is unlimited.
        /// </summary>
        [DataMember(Name = "maxCount", IsRequired = true)]
        public int MaxCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum durability of the item. A value of zero means the item is indestructible.
        /// </summary>
        [DataMember(Name = "maxDurability", IsRequired = true)]
        public int MaximumDurability
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the faction required to obtain this item. If the value is zero, the item doesn't require a faction
        /// </summary>
        [DataMember(Name = "minFactionId", IsRequired = true)]
        public int MinimumFactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum standing required with the faction to acquire the item
        /// </summary>
        [DataMember(Name = "minReputation", IsRequired = true)]
        public int MinimumFactionStanding
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality ItemQuality
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item sell to vendor price (the price an NPC vendor would offer to buy the item)
        /// </summary>
        [DataMember(Name = "sellPrice", IsRequired = true)]
        public long SellPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets minimum character level required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = true)]
        public int RequiredLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the profession required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkill", IsRequired = true)]
        public Skill RequiredProfession
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minumum skill rank required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredProfessionRank
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's socket information
        /// </summary>
        [DataMember(Name = "socketInfo", IsRequired = false)]
        public SocketInfo SocketInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item source
        /// </summary>
        [DataMember(Name = "itemSource", IsRequired = false)]
        public ItemSource Source
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "baseArmor", IsRequired = true)]
        public int BaseArmor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the item has sockets
        /// </summary>
        [DataMember(Name = "hasSockets", IsRequired = true)]
        public bool HasSockets
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the item can be sold in the auction house.
        /// </summary>
        [DataMember(Name = "isAuctionable", IsRequired = true)]
        public bool IsAuctionable
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
