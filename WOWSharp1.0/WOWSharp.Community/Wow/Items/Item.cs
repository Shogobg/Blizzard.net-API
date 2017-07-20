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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents an in game item
    /// </summary>
    [DataContract]
    public class Item : ApiResponse
    {
        /// <summary>
        ///   AllowableClasses
        /// </summary>
        private IList<ClassKey> _allowableClasses;

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        private int _baseArmor;

        /// <summary>
        ///   Gets or sets the item bind type
        /// </summary>
        private ItemBindType _bindType;

        /// <summary>
        ///   BonusStats field
        /// </summary>
        private IList<ItemStat> _bonusStats;

        /// <summary>
        ///   Gets or sets the item buy from vendor price (the price a character would pay to buy the item from an NPC vendor)
        /// </summary>
        private long _buyPrice;

        /// <summary>
        ///   Gets or sets the item category
        /// </summary>
        private ItemCategory _category;

        /// <summary>
        ///   Gets or sets the container item slots (the value is zero if the item is not a container)
        /// </summary>
        private int _containerSlots;

        /// <summary>
        ///   Gets or sets the item description
        /// </summary>
        private string _description;

        /// <summary>
        ///   Gets or sets the enchanting skill rank required to disenchant the item. If the value is -1 or null, it means the item cannot be disenchanted.
        /// </summary>
        private int? _disenchantingSkillRank;

        /// <summary>
        ///   Gets or sets the item display info.
        /// </summary>
        private int? _displayInfoId;

        /// <summary>
        ///   Gets or sets the item can be equipped
        /// </summary>
        private bool _equippable;

        /// <summary>
        ///   Gets or sets the gem's information (this is null if the item is not a gem)
        /// </summary>
        private GemInfo _gemInfo;

        /// <summary>
        ///   Gets or sets whether the item has sockets
        /// </summary>
        private bool _hasSockets;

        /// <summary>
        ///   Gets or sets the item id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the item's inventory type
        /// </summary>
        private ItemInventoryType? _inventoryType;

        /// <summary>
        ///   Gets or sets whether the item can be sold in the auction house.
        /// </summary>
        private bool _isAuctionable;

        /// <summary>
        ///   Gets or sets the item's level (ilvl)
        /// </summary>
        private int _itemLevel;

        /// <summary>
        ///   Gets or sets the item's quality
        /// </summary>
        private ItemQuality _itemQuality;

        /// <summary>
        ///   Gets or sets the item's set's id (if the item belongs to a set)
        /// </summary>
        private ItemSet _itemSet;

        /// <summary>
        ///   ItemSpells field
        /// </summary>
        private IList<ItemSpell> _itemSpells;

        /// <summary>
        ///   Gets or sets the max quantity of the item that can be carried by a character. If the value is zero, then max amount is unlimited.
        /// </summary>
        private int _maxCount;

        /// <summary>
        ///   Gets or sets the max stack size for this item in inventory.
        /// </summary>
        private int _maxStackSize;

        /// <summary>
        ///   Gets or sets the maximum durability of the item. A value of zero means the item is indestructible.
        /// </summary>
        private int _maximumDurability;

        /// <summary>
        ///   Gets or sets the id of the faction required to obtain this item. If the value is zero, the item doesn't require a faction
        /// </summary>
        private int _minimumFactionId;

        /// <summary>
        ///   Gets or sets the minimum standing required with the faction to acquire the item
        /// </summary>
        private Standing _minimumFactionStanding;

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        private string _name;

        /// <summary>
        /// name description (heroic, raid finder, elite, etc)
        /// </summary>
        private string _nameDescription;

        /// <summary>
        /// color in which name description is displayed
        /// </summary>
        private string _nameDescriptionColor;

        /// <summary>
        ///   Gets or sets minimum character level required to use/equip the item
        /// </summary>
        private int _requiredLevel;

        /// <summary>
        ///   Gets or sets the profession required to use/equip the item
        /// </summary>
        private Skill _requiredProfession;

        /// <summary>
        ///   Gets or sets the minumum skill rank required to use/equip the item
        /// </summary>
        private int _requiredProfessionRank;

        /// <summary>
        ///   Gets or sets the item sell to vendor price (the price an NPC vendor would offer to buy the item)
        /// </summary>
        private long _sellPrice;

        /// <summary>
        ///   Gets or sets the item's socket information
        /// </summary>
        private SocketInfo _socketInfo;

        /// <summary>
        ///   Gets or sets the item source
        /// </summary>
        private ItemSource _source;

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        private int _subcategoryId;

        /// <summary>
        ///   Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        private WeaponInfo _weaponInfo;

        /// <summary>
        ///  Gets or sets whether the item is upgradable
        /// </summary>
        private bool _isUpgradable;

        /// <summary>
        ///   Gets or sets the item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        /// <summary>
        ///   Gets or sets the enchanting skill rank required to disenchant the item. If the value is -1 or null, it means the item cannot be disenchanted.
        /// </summary>
        [DataMember(Name = "disenchantingSkillRank", IsRequired = false)]
        public int? DisenchantingSkillRank
        {
            get
            {
                return _disenchantingSkillRank;
            }
            internal set
            {
                _disenchantingSkillRank = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item display info (probably this is the item's model).
        /// </summary>
        [DataMember(Name = "displayInfoId", IsRequired = false)]
        public int? DisplayInfoId
        {
            get
            {
                return _displayInfoId;
            }
            internal set
            {
                _displayInfoId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get
            {
                return _description;
            }
            internal set
            {
                _description = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   Gets or sets the name description (heroic, raid finder, elite, etc)
        /// </summary>
        [DataMember(Name = "nameDescription", IsRequired = false)]
        public string NameDescription
        {
            get
            {
                return _nameDescription;
            }
            internal set
            {
                _nameDescription = value;
            }
        }

        /// <summary>
        ///   Gets or sets the color in which name description is displayed
        /// </summary>
        [DataMember(Name = "nameDescriptionColor", IsRequired = false)]
        public string NameDescriptionColor
        {
            get
            {
                return _nameDescriptionColor;
            }
            internal set
            {
                _nameDescriptionColor = value;
            }
        }

        /// <summary>
        ///   Gets or sets the max stack size for this item in inventory.
        /// </summary>
        [DataMember(Name = "stackable", IsRequired = true)]
        public int MaxStackSize
        {
            get
            {
                return _maxStackSize;
            }
            internal set
            {
                _maxStackSize = value;
            }
        }

        /// <summary>
        ///   Gets or sets the ids of the classes allowed to use/equip this item. A null value means all classes can use the item
        /// </summary>
        [DataMember(Name = "allowableClasses", IsRequired = false)]
        public IList<ClassKey> AllowableClasses
        {
            get
            {
                return _allowableClasses;
            }
            internal set
            {
                _allowableClasses = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item bind type
        /// </summary>
        [DataMember(Name = "itemBind", IsRequired = true)]
        public ItemBindType BindType
        {
            get
            {
                return _bindType;
            }
            internal set
            {
                _bindType = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's bonus stats
        /// </summary>
        [DataMember(Name = "bonusStats", IsRequired = false)]
        public IList<ItemStat> BonusStats
        {
            get
            {
                return _bonusStats;
            }
            internal set
            {
                _bonusStats = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's spells (procs and use effects)
        /// </summary>
        [DataMember(Name = "itemSpells", IsRequired = false)]
        public IList<ItemSpell> ItemSpells
        {
            get
            {
                return _itemSpells;
            }
            internal set
            {
                _itemSpells = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item buy from vendor price (the price a character would pay to buy the item from an NPC vendor)
        /// </summary>
        [DataMember(Name = "buyPrice", IsRequired = true)]
        public long BuyPrice
        {
            get
            {
                return _buyPrice;
            }
            internal set
            {
                _buyPrice = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item category
        /// </summary>
        [DataMember(Name = "itemClass", IsRequired = true)]
        public ItemCategory Category
        {
            get
            {
                return _category;
            }
            internal set
            {
                _category = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        [DataMember(Name = "itemSubClass", IsRequired = true)]
        public int SubcategoryId
        {
            get
            {
                return _subcategoryId;
            }
            internal set
            {
                _subcategoryId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        public ItemSubcategory Subcategory
        {
            get
            {
                unchecked
                {
                    return (ItemSubcategory) (((long) Category << 32) | (uint) SubcategoryId);
                }
            }
            //internal set
            //{
            //    unchecked
            //    {
            //        this.SubcategoryId = (int)((long)value & 0xffffffffL);
            //        this.Category = (ItemCategory)(((long)value & 0xffff) >> 32);
            //    }
            //}
        }

        /// <summary>
        ///   Gets or sets the container item slots (the value is zero if the item is not a container)
        /// </summary>
        [DataMember(Name = "containerSlots", IsRequired = false)]
        public int ContainerSlots
        {
            get
            {
                return _containerSlots;
            }
            internal set
            {
                _containerSlots = value;
            }
        }

        /// <summary>
        ///   Gets or sets the gem's information (this is null if the item is not a gem)
        /// </summary>
        [DataMember(Name = "gemInfo", IsRequired = false)]
        public GemInfo GemInfo
        {
            get
            {
                return _gemInfo;
            }
            internal set
            {
                _gemInfo = value;
            }
        }

        /// <summary>
        ///   Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        [DataMember(Name = "weaponInfo", IsRequired = false)]
        public WeaponInfo WeaponInfo
        {
            get
            {
                return _weaponInfo;
            }
            internal set
            {
                _weaponInfo = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's inventory type
        /// </summary>
        [DataMember(Name = "inventoryType", IsRequired = false)]
        public ItemInventoryType? InventoryType
        {
            get
            {
                return _inventoryType;
            }
            internal set
            {
                _inventoryType = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item can be equipped
        /// </summary>
        [DataMember(Name = "equippable", IsRequired = true)]
        public bool Equippable
        {
            get
            {
                return _equippable;
            }
            internal set
            {
                _equippable = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's level (ilvl)
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = false)]
        public int ItemLevel
        {
            get
            {
                return _itemLevel;
            }
            internal set
            {
                _itemLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's set's id (if the item belongs to a set)
        /// </summary>
        [DataMember(Name = "itemSet", IsRequired = false)]
        public ItemSet ItemSet
        {
            get
            {
                return _itemSet;
            }
            internal set
            {
                _itemSet = value;
            }
        }

        /// <summary>
        ///   Gets or sets the max quantity of the item that can be carried by a character. If the value is zero, then max amount is unlimited.
        /// </summary>
        [DataMember(Name = "maxCount", IsRequired = true)]
        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
            internal set
            {
                _maxCount = value;
            }
        }

        /// <summary>
        ///   Gets or sets the maximum durability of the item. A value of zero means the item is indestructible.
        /// </summary>
        [DataMember(Name = "maxDurability", IsRequired = true)]
        public int MaximumDurability
        {
            get
            {
                return _maximumDurability;
            }
            internal set
            {
                _maximumDurability = value;
            }
        }

        /// <summary>
        ///   Gets or sets the id of the faction required to obtain this item. If the value is zero, the item doesn't require a faction
        /// </summary>
        [DataMember(Name = "minFactionId", IsRequired = true)]
        public int MinimumFactionId
        {
            get
            {
                return _minimumFactionId;
            }
            internal set
            {
                _minimumFactionId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minimum standing required with the faction to acquire the item
        /// </summary>
        [DataMember(Name = "minReputation", IsRequired = true)]
        public Standing MinimumFactionStanding
        {
            get
            {
                return _minimumFactionStanding;
            }
            internal set
            {
                _minimumFactionStanding = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality ItemQuality
        {
            get
            {
                return _itemQuality;
            }
            internal set
            {
                _itemQuality = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item sell to vendor price (the price an NPC vendor would offer to buy the item)
        /// </summary>
        [DataMember(Name = "sellPrice", IsRequired = true)]
        public long SellPrice
        {
            get
            {
                return _sellPrice;
            }
            internal set
            {
                _sellPrice = value;
            }
        }

        /// <summary>
        ///   Gets or sets minimum character level required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = true)]
        public int RequiredLevel
        {
            get
            {
                return _requiredLevel;
            }
            internal set
            {
                _requiredLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the profession required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkill", IsRequired = true)]
        public Skill RequiredProfession
        {
            get
            {
                return _requiredProfession;
            }
            internal set
            {
                _requiredProfession = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minumum skill rank required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredProfessionRank
        {
            get
            {
                return _requiredProfessionRank;
            }
            internal set
            {
                _requiredProfessionRank = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's socket information
        /// </summary>
        [DataMember(Name = "socketInfo", IsRequired = false)]
        public SocketInfo SocketInfo
        {
            get
            {
                return _socketInfo;
            }
            internal set
            {
                _socketInfo = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item source
        /// </summary>
        [DataMember(Name = "itemSource", IsRequired = false)]
        public ItemSource Source
        {
            get
            {
                return _source;
            }
            internal set
            {
                _source = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "baseArmor", IsRequired = true)]
        public int BaseArmor
        {
            get
            {
                return _baseArmor;
            }
            internal set
            {
                _baseArmor = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the item has sockets
        /// </summary>
        [DataMember(Name = "hasSockets", IsRequired = true)]
        public bool HasSockets
        {
            get
            {
                return _hasSockets;
            }
            internal set
            {
                _hasSockets = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the item can be sold in the auction house.
        /// </summary>
        [DataMember(Name = "isAuctionable", IsRequired = true)]
        public bool IsAuctionable
        {
            get
            {
                return _isAuctionable;
            }
            internal set
            {
                _isAuctionable = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the item is upgradable
        /// </summary>
        [DataMember(Name = "upgradable", IsRequired = false)]
        public bool IsUpgradable
        {
            get
            {
                return _isUpgradable;
            }
            internal set
            {
                _isUpgradable = value;
            }
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