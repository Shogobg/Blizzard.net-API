
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item type
	/// </summary>
	[DataContract]
    public enum ItemType
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "None")]
        None = 0,
        #region ALL Classes Armor
        /// <summary>
        /// Boots
        /// </summary>
        [EnumMember(Value = "Boots")]
        Boots = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Boots + 1,

        /// <summary>
        /// Ring
        /// </summary>
        [EnumMember(Value = "Ring")]
        Ring = ItemHelper.Tradable + ItemHelper.AllFollowers + ItemHelper.AllClassesMask + ItemHelper.Finger + 2,

        /// <summary>
        /// Helm
        /// </summary>
        [EnumMember(Value = "GenericHelm")]
        GenericHelm = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Head + 3,

        /// <summary>
        /// Gloves
        /// </summary>
        [EnumMember(Value = "Gloves")]
        Gloves = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Hands + 4,

        /// <summary>
        /// Bracers
        /// </summary>
        [EnumMember(Value = "Bracers")]
        Bracers = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Bracers + 5,

        /// <summary>
        /// Lege
        /// </summary>
        [EnumMember(Value = "Legs")]
        Legs = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Legs + 6,

        /// <summary>
        /// Chest
        /// </summary>
        [EnumMember(Value = "GenericChestArmor")]
        GenericChest = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Torso + 7,

        /// <summary>
        /// Shoulders
        /// </summary>
        [EnumMember(Value = "Shoulders")]
        Shoulders = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Shoulders + 8,

        /// <summary>
        /// Neck
        /// </summary>
        [EnumMember(Value = "Amulet")]
        Amulet = ItemHelper.Tradable + ItemHelper.AllFollowers + ItemHelper.AllClassesMask + ItemHelper.Neck + 9,

        /// <summary>
        /// Shield
        /// </summary>
        [EnumMember(Value = "Shield")]
        Shield = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.AllClassesMask + ItemHelper.OffHand + 10,

        /// <summary>
        /// Belt
        /// </summary>
        [EnumMember(Value = "GenericBelt")]
        Belt = ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.Waist + 11,

        /// <summary>
        /// Chest (Blizzard sometimes returns GenericChestArmor and some times ChestArmor)
        /// Both are the same
        /// </summary>
        [EnumMember(Value = "ChestArmor")]
        Chest = GenericChest,

        /// <summary>
        /// Helm
        /// </summary>
        [EnumMember(Value = "Helm")]
        Helm = GenericHelm,
        
        #endregion
        #region 1 Handed Generic Weapons
        /// <summary>
        /// Mace
        /// </summary>
        [EnumMember(Value = "Mace")]
        OneHandedMace = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.Enchantress + ItemHelper.AllClassesMask + ItemHelper.MainHand + 20,

        /// <summary>
        /// One handed Sword Weapons
        /// </summary>
        [EnumMember(Value = "Sword")]
        OneHandedSword = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.Enchantress + ItemHelper.AllClassesMask + ItemHelper.MainHand + 21,

        /// <summary>
        /// One handed axe Weapons
        /// </summary>
        [EnumMember(Value = "Axe")]
        OneHandedAxe = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.Enchantress + ItemHelper.AllClassesMask + ItemHelper.MainHand + 22,

        /// <summary>
        /// Dagger
        /// </summary>
        [EnumMember(Value = "Dagger")]
        Dagger = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.Enchantress + ItemHelper.AllClassesMask + ItemHelper.MainHand + 23,

        /// <summary>
        /// Spear
        /// </summary>
        [EnumMember(Value = "Spear")]
        Spear = ItemHelper.Tradable + ItemHelper.Templar + ItemHelper.Enchantress + ItemHelper.AllClassesMask + ItemHelper.MainHand + 24,

        #endregion
        #region 2H Generic Weapons
        /// <summary>
        /// Two handed axe
        /// </summary>
        [EnumMember(Value = "Axe2H")]
        TwoHandedAxe = ItemHelper.Enchantress + 
        ItemHelper.Barbarian + ItemHelper.Monk + ItemHelper.Witchdoctor + ItemHelper.Wizard + 
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 30,

        /// <summary>
        /// two handed mace
        /// </summary>
        [EnumMember(Value = "Mace2H")]
        TwoHandedMace = ItemHelper.Enchantress +
        ItemHelper.Barbarian + ItemHelper.Monk + ItemHelper.Witchdoctor + ItemHelper.Wizard +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 31,

        /// <summary>
        /// Two handed sword
        /// </summary>
        [EnumMember(Value = "Sword2H")]
        TwoHandedSword = ItemHelper.Enchantress +
        ItemHelper.Barbarian + ItemHelper.Monk + ItemHelper.Witchdoctor + ItemHelper.Wizard +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 32,

        /// <summary>
        /// Polearm
        /// </summary>
        [EnumMember(Value = "Polearm")]
        Polearm = ItemHelper.Barbarian + ItemHelper.Monk + ItemHelper.Witchdoctor +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 33,

        /// <summary>
        /// Crossbow
        /// </summary>
        [EnumMember(Value = "Crossbow")]
        Crossbow = ItemHelper.Scoundrel +
        ItemHelper.DemonHunter + ItemHelper.Witchdoctor + ItemHelper.Wizard +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 34,

        /// <summary>
        /// Bow
        /// </summary>
        [EnumMember(Value = "Bow")]
        Bow = ItemHelper.Scoundrel +
        ItemHelper.DemonHunter + ItemHelper.Witchdoctor + ItemHelper.Wizard +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 35,

        /// <summary>
        /// Staff
        /// </summary>
        [EnumMember(Value = "Staff")]
        Staff = ItemHelper.Enchantress +
        ItemHelper.Monk + ItemHelper.Witchdoctor + ItemHelper.Wizard +
        ItemHelper.Tradable + ItemHelper.TwoHanded + ItemHelper.MainHand + 36,

        /// <summary>
        /// Combat Staff
        /// </summary>
        [EnumMember(Value = "CombatStaff")]
        CombatStaff = Staff,

        #endregion
        #region Class Weapons
        /// <summary>
        /// Fist Weapon (Monk)
        /// </summary>
        [EnumMember(Value = "FistWeapon")]
        FistWeapon = ItemHelper.Monk + ItemHelper.MainHand + ItemHelper.Tradable + 40,

        /// <summary>
        /// Daibo
        /// </summary>
        [EnumMember(Value = "Daibo")]
        Daibo = ItemHelper.Monk + ItemHelper.TwoHanded + ItemHelper.MainHand + ItemHelper.Tradable + 41,

        /// <summary>
        /// Wand (Wizard)
        /// </summary>
        [EnumMember(Value = "Wand")]
        Wand = ItemHelper.Wizard + ItemHelper.MainHand + ItemHelper.Tradable + 42,

        /// <summary>
        /// One handed Mighty Weapons
        /// </summary>
        [EnumMember(Value = "MightyWeapon1H")]
        OneHandedMightyWeapon = ItemHelper.Barbarian + ItemHelper.MainHand + ItemHelper.Tradable + 43,
        
        /// <summary>
        /// One handed flail
        /// </summary>
        [EnumMember(Value = "Flail1H")]
        OneHandedFlail = ItemHelper.Crusader + ItemHelper.MainHand + ItemHelper.Tradable + 47,

        /// <summary>
        /// Hand cross bow (demon hunter)
        /// </summary>
        [EnumMember(Value = "HandXBow")]
        HandCrossbow = ItemHelper.DemonHunter + ItemHelper.MainHand + ItemHelper.Tradable + 44,

        /// <summary>
        /// Two handed mighty weapon
        /// </summary>
        [EnumMember(Value = "MightyWeapon2H")]
        TwoHandedMightyWeapon = ItemHelper.Barbarian + ItemHelper.TwoHanded + ItemHelper.MainHand + ItemHelper.Tradable + 45,

        /// <summary>
        /// Two handed flail
        /// </summary>
        [EnumMember(Value = "Flail2H")]
        TwoHandedFlail = ItemHelper.Crusader + ItemHelper.TwoHanded + ItemHelper.Tradable + 48,

        /// <summary>
        /// CeremonialDagger (Witch Doctor)
        /// </summary>
        [EnumMember(Value = "CeremonialDagger")]
        CeremonialDagger = ItemHelper.Witchdoctor + ItemHelper.MainHand + ItemHelper.Tradable + 46,

        #endregion
        #region Class Armor

        /// <summary>
        /// WizardHat
        /// </summary>
        [EnumMember(Value = "WizardHat")]
        WizardHat = ItemHelper.Wizard + ItemHelper.Head + ItemHelper.Tradable + 50,

        /// <summary>
        /// Cloak
        /// </summary>
        [EnumMember(Value = "Cloak")]
        Cloak = ItemHelper.DemonHunter + ItemHelper.Torso + ItemHelper.Tradable + 51,

        /// <summary>
        /// Mighty belt (Barbarian only)
        /// </summary>
        [EnumMember(Value = "Belt_Barbarian")]
        MightyBelt = ItemHelper.Barbarian + ItemHelper.Waist + ItemHelper.Tradable + 52,

        /// <summary>
        /// Quiver (Demon Hunter)
        /// </summary>
        [EnumMember(Value = "Quiver")]
        Quiver = ItemHelper.DemonHunter + ItemHelper.OffHand + ItemHelper.Tradable + 53,

        /// <summary>
        /// Voodoo Mask (Witch Doctor)
        /// </summary>
        [EnumMember(Value = "VoodooMask")]
        VoodooMask = ItemHelper.Witchdoctor + ItemHelper.Head + ItemHelper.Tradable + 54,

        /// <summary>
        /// Spirit stone
        /// </summary>
        [EnumMember(Value = "SpiritStone_Monk")]
        SpiritStone = ItemHelper.Monk + ItemHelper.Head + ItemHelper.Tradable + 55,

        /// <summary>
        /// Mojo (Witch Doctor)
        /// </summary>
        [EnumMember(Value = "Mojo")]
        Mojo = ItemHelper.Witchdoctor + ItemHelper.OffHand + ItemHelper.Tradable + 56,

        /// <summary>
        /// Orb or magic source(Wizard)
        /// </summary>
        [EnumMember(Value = "Orb")]
        MagicSource = ItemHelper.Wizard + ItemHelper.OffHand + ItemHelper.Tradable + 57,

        /// <summary>
        /// Crusader's shield
        /// </summary>
        [EnumMember(Value = "CrusaderShield")]
        CrusaderShield = ItemHelper.Crusader + ItemHelper.OffHand + ItemHelper.Tradable + 58,
        #endregion
        #region Followers
        /// <summary>
        /// Enchantress special
        /// </summary>
        [EnumMember(Value = "EnchantressSpecial")]
        EnchantressSpecial = ItemHelper.Enchantress + ItemHelper.Tradable + ItemHelper.Follower + 60,

        /// <summary>
        /// Templar special
        /// </summary>
        [EnumMember(Value = "TemplarSpecial")]
        TemplarSpecial = ItemHelper.Templar + ItemHelper.Tradable + ItemHelper.Follower + 61,

        /// <summary>
        /// Scoundrel special
        /// </summary>
        [EnumMember(Value = "ScoundrelSpecial")]
        ScoundrelSpecial = ItemHelper.Scoundrel + ItemHelper.Tradable + ItemHelper.Follower + 62,
        #endregion
        #region Gem Socketable items
        /// <summary>
        /// Weapon
        /// </summary>
        [EnumMember(Value = "Weapon")]
        Weapon = ItemHelper.MainHand + ItemHelper.Tradable + ItemHelper.AllClassesMask + ItemHelper.AllFollowers + 100,
        /// <summary>
        /// All armor except head
        /// </summary>
        [EnumMember(Value = "All")]
        AnyArmorExceptHead = ItemHelper.EquipmentSlotMask + ItemHelper.Tradable + ItemHelper.AllFollowers + ItemHelper.AllClassesMask + 101,

		/// <summary>
		/// All armor except head
		/// </summary>
		[EnumMember(Value = "Helm_Barbarian")]
		HelmBarbarian = ItemHelper.Barbarian + 1000,
		
		#endregion
		#region Commodity

		/// <summary>
		/// Gem
		/// </summary>
		[EnumMember(Value = "Gem")]
        Gem = ItemHelper.Commodity + ItemHelper.Tradable + 120,

        /// <summary>
        /// Crafting Reagent
        /// </summary>
        [EnumMember(Value = "CraftingReagent")]
        CraftingReagent = ItemHelper.Commodity + ItemHelper.Tradable + 121,

        /// <summary>
        /// Training tome (e.g. tome of secrets)
        /// </summary>
        [EnumMember(Value = "TrainingTome")]
        TrainingTome = ItemHelper.Commodity + ItemHelper.Tradable + 122,

        /// <summary>
        /// Health potion
        /// </summary>
        [EnumMember(Value = "HealthPotion")]
        HealthPotion = ItemHelper.Commodity + ItemHelper.Tradable + 123,

        /// <summary>
        /// Dye
        /// </summary>
        [EnumMember(Value = "Dye")]
        Dye = ItemHelper.Commodity + ItemHelper.Tradable + 124,

        /// <summary>
        /// Page of blacksmithig or Tome of black smithing
        /// </summary>
        [EnumMember(Value = "PageOfTraining_Smith")]
        BlacksmithTraining = ItemHelper.Commodity + ItemHelper.Tradable + 125,

        /// <summary>
        /// Page of jewelcrafting or Tome of black jewelcrafting
        /// </summary>
        [EnumMember(Value = "PageOfTraining_Jeweler")]
        JewelerTraining = ItemHelper.Commodity + ItemHelper.Tradable + 126,

        /// <summary>
        /// Jewelcrafting design
        /// </summary>
        [EnumMember(Value = "CraftingPlan_Jeweler")]
        JewelerDesign = ItemHelper.Commodity + ItemHelper.Tradable + 127,

        /// <summary>
        /// Blacksmith plan
        /// </summary>
        [EnumMember(Value = "CraftingPlan_Smith")]
        BlacksmithPlan = ItemHelper.Commodity + ItemHelper.Tradable + 128,
        #endregion
        #region Miscelanous
        /// <summary>
        /// Infernal machine
        /// </summary>
        [EnumMember(Value = "PortalDevice")]
        PortalDevice = 140,

        /// <summary>
        /// Angelic wings (collector edition)
        /// </summary>
        [EnumMember(Value = "ScrollAngelWings")]
        AngelicWings = 141,

        /// <summary>
        /// Ornament (such as staff of herding mats)
        /// </summary>
        [EnumMember(Value = "Ornament")]
        Ornament = 142,

        /// <summary>
        /// Demonic Key (Keys obtained from keywardens to craft infernal machine)
        /// </summary>
        [EnumMember(Value = "DemonicKey")]
        DemonicKey = 143,

        /// <summary>
        /// Hell fire rings mats dropped from Über bosses
        /// </summary>
        [EnumMember(Value = "DemonicOrgan")]
        DemonicOrgan = 144,
        #endregion
        // TODO: 
        // the black rock ledger?
    }
}
