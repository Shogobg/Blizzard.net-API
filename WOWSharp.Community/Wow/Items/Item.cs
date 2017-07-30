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
        ///   Gets or sets the item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the enchanting skill rank required to disenchant the item. If the value is -1 or null, it means the item cannot be disenchanted.
        /// </summary>
        [DataMember(Name = "disenchantingSkillRank", IsRequired = false)]
        public int? DisenchantingSkillRank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item display info (probably this is the item's model).
        /// </summary>
        [DataMember(Name = "displayInfoId", IsRequired = false)]
        public int? DisplayInfoId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item description
        /// </summary>
        [DataMember(Name = "description", IsRequired = false)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

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
        ///   Gets or sets the name description (heroic, raid finder, elite, etc)
        /// </summary>
        [DataMember(Name = "nameDescription", IsRequired = false)]
        public string NameDescription
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the color in which name description is displayed
        /// </summary>
        [DataMember(Name = "nameDescriptionColor", IsRequired = false)]
        public string NameDescriptionColor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the max stack size for this item in inventory.
        /// </summary>
        [DataMember(Name = "stackable", IsRequired = false)]
        public int MaxStackSize
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the ids of the classes allowed to use/equip this item. A null value means all classes can use the item
        /// </summary>
        [DataMember(Name = "allowableClasses", IsRequired = false)]
        public IList<ClassKey> AllowableClasses
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item bind type
        /// </summary>
        [DataMember(Name = "itemBind", IsRequired = false)]
        public ItemBindType BindType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's bonus stats
        /// </summary>
        [DataMember(Name = "bonusStats", IsRequired = false)]
        public IList<ItemStat> BonusStats
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's spells (procs and use effects)
        /// </summary>
        [DataMember(Name = "itemSpells", IsRequired = false)]
        public IList<ItemSpell> ItemSpells
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item buy from vendor price (the price a character would pay to buy the item from an NPC vendor)
        /// </summary>
        [DataMember(Name = "buyPrice", IsRequired = false)]
        public long BuyPrice
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item category
        /// </summary>
        [DataMember(Name = "itemClass", IsRequired = false)]
        public ItemCategory Category
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        [DataMember(Name = "itemSubClass", IsRequired = true)]
        public int SubcategoryId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the container item slots (the value is zero if the item is not a container)
        /// </summary>
        [DataMember(Name = "containerSlots", IsRequired = false)]
        public int ContainerSlots
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the gem's information (this is null if the item is not a gem)
        /// </summary>
        [DataMember(Name = "gemInfo", IsRequired = false)]
        public GemInfo GemInfo
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
        ///   Gets or sets the item's inventory type
        /// </summary>
        [DataMember(Name = "inventoryType", IsRequired = false)]
        public ItemInventoryType? InventoryType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item can be equipped
        /// </summary>
        [DataMember(Name = "equippable", IsRequired = true)]
        public bool Equippable
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's level (ilvl)
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = false)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's set's id (if the item belongs to a set)
        /// </summary>
        [DataMember(Name = "itemSet", IsRequired = false)]
        public ItemSet ItemSet
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the max quantity of the item that can be carried by a character. If the value is zero, then max amount is unlimited.
        /// </summary>
        [DataMember(Name = "maxCount", IsRequired = true)]
        public int MaxCount
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the maximum durability of the item. A value of zero means the item is indestructible.
        /// </summary>
        [DataMember(Name = "maxDurability", IsRequired = true)]
        public int MaximumDurability
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the faction required to obtain this item. If the value is zero, the item doesn't require a faction
        /// </summary>
        [DataMember(Name = "minFactionId", IsRequired = true)]
        public int MinimumFactionId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the minimum standing required with the faction to acquire the item
        /// </summary>
        [DataMember(Name = "minReputation", IsRequired = true)]
        public Standing MinimumFactionStanding
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality ItemQuality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item sell to vendor price (the price an NPC vendor would offer to buy the item)
        /// </summary>
        [DataMember(Name = "sellPrice", IsRequired = true)]
        public long SellPrice
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets minimum character level required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = true)]
        public int RequiredLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the profession required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkill", IsRequired = true)]
        public Skill RequiredProfession
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the minumum skill rank required to use/equip the item
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredProfessionRank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's socket information
        /// </summary>
        [DataMember(Name = "socketInfo", IsRequired = false)]
        public SocketInfo SocketInfo
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item source
        /// </summary>
        [DataMember(Name = "itemSource", IsRequired = false)]
        public ItemSource Source
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "baseArmor", IsRequired = true)]
        public int BaseArmor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = true)]
        public int Armor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Whether the item has the "heroic" tooltip
        /// </summary>
        [DataMember(Name = "heroicTooltip", IsRequired = false)]
        public bool HeroicTooltip
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the item has sockets
        /// </summary>
        [DataMember(Name = "hasSockets", IsRequired = true)]
        public bool HasSockets
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the item can be sold in the auction house.
        /// </summary>
        [DataMember(Name = "isAuctionable", IsRequired = true)]
        public bool IsAuctionable
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets whether the item is upgradable
        /// </summary>
        [DataMember(Name = "upgradable", IsRequired = false)]
        public bool IsUpgradable
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets item's tooltip parameters
        /// </summary>
        [DataMember(Name = "tooltipParams", IsRequired = false)]
        public EquippedItemParameters TooltipParameters
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