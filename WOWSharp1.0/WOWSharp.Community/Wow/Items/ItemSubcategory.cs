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

using System.Diagnostics.CodeAnalysis;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Item Subcategory Enumeration
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum ItemSubcategory : long
    {
        /// <summary>
        ///   Category: Weapons (2) - Sub-Category: Ranged Weapons (262156)
        /// </summary>
        WeaponsRangedWeapons = ((long) ItemCategory.Weapons << 32) | 262156,

        /// <summary>
        ///   Category: Weapons (2) - Sub-Category: Exotic (11)
        /// </summary>
        WeaponsExotic = ((long) ItemCategory.Weapons << 32) | 11,

        /// <summary>
        ///   Category: Weapons (2) - Sub-Category: Melee Weapon (173555)
        /// </summary>
        WeaponsMeleeWeapons = ((long) ItemCategory.Weapons << 32) | 173555,

        /// <summary>
        ///   Category: Weapons (2) - Sub-Category: One-Handed Melee Weapon (41105)
        /// </summary>
        WeaponsOneHandedMeleeWeapons = ((long) ItemCategory.Weapons << 32) | 41105,

        /// <summary>
        ///   Category: Weapons (2) - Sub-Category: Obsolete (9)
        /// </summary>
        WeaponsObsolete = ((long) ItemCategory.Weapons << 32) | 9,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Daggers (15)
        ///</summary>
        WeaponsDaggers = ((long) ItemCategory.Weapons << 32) | 15,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Fist Weapons (13)
        ///</summary>
        WeaponsFistWeapons = ((long) ItemCategory.Weapons << 32) | 13,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: One-Handed Axes (0)
        ///</summary>
        WeaponsOneHandedAxes = ((long) ItemCategory.Weapons << 32) | 0,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: One-Handed Maces (4)
        ///</summary>
        WeaponsOneHandedMaces = ((long) ItemCategory.Weapons << 32) | 4,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: One-Handed Swords (7)
        ///</summary>
        WeaponsOneHandedSwords = ((long) ItemCategory.Weapons << 32) | 7,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Polearms (6)
        ///</summary>
        WeaponsPoleArms = ((long) ItemCategory.Weapons << 32) | 6,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Staves (10)
        ///</summary>
        WeaponsStaves = ((long) ItemCategory.Weapons << 32) | 10,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Two-Handed Axes (1)
        ///</summary>
        WeaponsTwoHandedAxes = ((long) ItemCategory.Weapons << 32) | 1,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Two-Handed Maces (5)
        ///</summary>
        WeaponsTwoHandedMaces = ((long) ItemCategory.Weapons << 32) | 5,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Two-Handed Swords (8)
        ///</summary>
        WeaponsTwoHandedSwords = ((long) ItemCategory.Weapons << 32) | 8,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Bows (2)
        ///</summary>
        WeaponsBows = ((long) ItemCategory.Weapons << 32) | 2,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Crossbows (18)
        ///</summary>
        WeaponsCrossbows = ((long) ItemCategory.Weapons << 32) | 18,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Guns (3)
        ///</summary>
        WeaponsGuns = ((long) ItemCategory.Weapons << 32) | 3,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Thrown (16)
        ///</summary>
        WeaponsThrown = ((long) ItemCategory.Weapons << 32) | 16,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Wands (19)
        ///</summary>
        WeaponsWands = ((long) ItemCategory.Weapons << 32) | 19,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Fishing Poles (20)
        ///</summary>
        WeaponsFishingPoles = ((long) ItemCategory.Weapons << 32) | 20,

        ///<summary>
        ///  Category: Weapons (2) - Sub-Category: Miscellaneous (14)
        ///</summary>
        WeaponsMiscellaneous = ((long) ItemCategory.Weapons << 32) | 14,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Cloth (1)
        ///</summary>
        ArmorCloth = ((long) ItemCategory.Armor << 32) | 1,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Leather (2)
        ///</summary>
        ArmorLeather = ((long) ItemCategory.Armor << 32) | 2,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Mail (3)
        ///</summary>
        ArmorMail = ((long) ItemCategory.Armor << 32) | 3,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Plate (4)
        ///</summary>
        ArmorPlate = ((long) ItemCategory.Armor << 32) | 4,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Relics (11)
        ///</summary>
        ArmorRelics = ((long) ItemCategory.Armor << 32) | 11,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Librams (7)
        ///</summary>
        ArmorLibrams = ((long) ItemCategory.Armor << 32) | 7,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Idols (8)
        ///</summary>
        ArmorIdols = ((long) ItemCategory.Armor << 32) | 8,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Totems (9)
        ///</summary>
        ArmorTotems = ((long) ItemCategory.Armor << 32) | 9,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Sigils (10)
        ///</summary>
        ArmorSigils = ((long) ItemCategory.Armor << 32) | 10,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Shields (6)
        ///</summary>
        ArmorShields = ((long) ItemCategory.Armor << 32) | 6,

        ///<summary>
        ///  Category: Armor (4) - Sub-Category: Miscellaneous (0)
        ///</summary>
        ArmorMiscellaneous = ((long) ItemCategory.Armor << 32) | 0,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Bags (0)
        ///</summary>
        ContainersBags = ((long) ItemCategory.Containers << 32) | 0,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Enchanting Bags (3)
        ///</summary>
        ContainersEnchantingBags = ((long) ItemCategory.Containers << 32) | 3,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Engineering Bags (4)
        ///</summary>
        ContainersEngineeringBags = ((long) ItemCategory.Containers << 32) | 4,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Gem Bags (5)
        ///</summary>
        ContainersGemBags = ((long) ItemCategory.Containers << 32) | 5,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Herb Bags (2)
        ///</summary>
        ContainersHerbBags = ((long) ItemCategory.Containers << 32) | 2,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Inscription Bags (8)
        ///</summary>
        ContainersInscriptionBags = ((long) ItemCategory.Containers << 32) | 8,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Leatherworking Bags (7)
        ///</summary>
        ContainersLeatherworkingBags = ((long) ItemCategory.Containers << 32) | 7,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Mining Bags (6)
        ///</summary>
        ContainersMiningBags = ((long) ItemCategory.Containers << 32) | 6,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Soul Bags (1)
        ///</summary>
        ContainersSoulBags = ((long) ItemCategory.Containers << 32) | 1,

        ///<summary>
        ///  Category: Containers (1) - Sub-Category: Tackle Boxes (9)
        ///</summary>
        ContainersTackleBoxes = ((long) ItemCategory.Containers << 32) | 9,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Bandages (7)
        ///</summary>
        ConsumablesBandages = ((long) ItemCategory.Consumables << 32) | 7,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Consumables (0)
        ///</summary>
        ConsumablesConsumables = ((long) ItemCategory.Consumables << 32) | 0,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Elixirs (2)
        ///</summary>
        ConsumablesElixirs = ((long) ItemCategory.Consumables << 32) | 2,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Flasks (3)
        ///</summary>
        ConsumablesFlasks = ((long) ItemCategory.Consumables << 32) | 3,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Food & Drinks (5)
        ///</summary>
        ConsumablesFoodDrinks = ((long) ItemCategory.Consumables << 32) | 5,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Item Enhancements (Permanent) (6)
        ///</summary>
        ConsumablesItemEnhancements = ((long) ItemCategory.Consumables << 32) | 6,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Potions (1)
        ///</summary>
        ConsumablesPotions = ((long) ItemCategory.Consumables << 32) | 1,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Scrolls (4)
        ///</summary>
        ConsumablesScrolls = ((long) ItemCategory.Consumables << 32) | 4,

        ///<summary>
        ///  Category: Consumables (0) - Sub-Category: Other (8)
        ///</summary>
        ConsumablesOther = ((long) ItemCategory.Consumables << 32) | 8,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Death Knight (6)
        ///</summary>
        GlyphsDeathKnight = ((long) ItemCategory.Glyphs << 32) | 6,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Druid (11)
        ///</summary>
        GlyphsDruid = ((long) ItemCategory.Glyphs << 32) | 11,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Monk (10)
        ///</summary>
        GlyphsMonk = ((long) ItemCategory.Glyphs << 32) | 10,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Hunter (3)
        ///</summary>
        GlyphsHunter = ((long) ItemCategory.Glyphs << 32) | 3,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Mage (8)
        ///</summary>
        GlyphsMage = ((long) ItemCategory.Glyphs << 32) | 8,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Paladin (2)
        ///</summary>
        GlyphsPaladin = ((long) ItemCategory.Glyphs << 32) | 2,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Priest (5)
        ///</summary>
        GlyphsPriest = ((long) ItemCategory.Glyphs << 32) | 5,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Rogue (4)
        ///</summary>
        GlyphsRogue = ((long) ItemCategory.Glyphs << 32) | 4,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Shaman (7)
        ///</summary>
        GlyphsShaman = ((long) ItemCategory.Glyphs << 32) | 7,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Warlock (9)
        ///</summary>
        GlyphsWarlock = ((long) ItemCategory.Glyphs << 32) | 9,

        ///<summary>
        ///  Category: Glyphs (16) - Sub-Category: Warrior (1)
        ///</summary>
        GlyphsWarrior = ((long) ItemCategory.Glyphs << 32) | 1,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Item Enchantments (14)
        ///</summary>
        TradeGoodsItemEnchantments = ((long) ItemCategory.TradeGoods << 32) | 14,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Cloth (5)
        ///</summary>
        TradeGoodsCloth = ((long) ItemCategory.TradeGoods << 32) | 5,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Devices (3)
        ///</summary>
        TradeGoodsDevices = ((long) ItemCategory.TradeGoods << 32) | 3,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Elemental (10)
        ///</summary>
        TradeGoodsElemental = ((long) ItemCategory.TradeGoods << 32) | 10,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Enchanting (12)
        ///</summary>
        TradeGoodsEnchanting = ((long) ItemCategory.TradeGoods << 32) | 12,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Explosives (2)
        ///</summary>
        TradeGoodsExplosives = ((long) ItemCategory.TradeGoods << 32) | 2,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Herbs (9)
        ///</summary>
        TradeGoodsHerbs = ((long) ItemCategory.TradeGoods << 32) | 9,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Jewelcrafting (4)
        ///</summary>
        TradeGoodsJewelCrafting = ((long) ItemCategory.TradeGoods << 32) | 4,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Leather (6)
        ///</summary>
        TradeGoodsLeather = ((long) ItemCategory.TradeGoods << 32) | 6,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Materials (13)
        ///</summary>
        TradeGoodsMaterials = ((long) ItemCategory.TradeGoods << 32) | 13,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Cooking (8)
        ///</summary>
        TradeGoodsCooking = ((long) ItemCategory.TradeGoods << 32) | 8,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Metal & Stone (7)
        ///</summary>
        TradeGoodsMetalStone = ((long) ItemCategory.TradeGoods << 32) | 7,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Parts (1)
        ///</summary>
        TradeGoodsParts = ((long) ItemCategory.TradeGoods << 32) | 1,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Weapon Enchantments (15)
        ///</summary>
        TradeGoodsWeaponEnchantments = ((long) ItemCategory.TradeGoods << 32) | 15,

        ///<summary>
        ///  Category: Trade Goods (7) - Sub-Category: Other (11)
        ///</summary>
        TradeGoodsOther = ((long) ItemCategory.TradeGoods << 32) | 11,

        ///<summary>
        ///  Category: Projectiles (6) - Sub-Category: Arrows (2)
        ///</summary>
        ProjectilesArrows = ((long) ItemCategory.Projectiles << 32) | 2,

        ///<summary>
        ///  Category: Projectiles (6) - Sub-Category: Bullets (3)
        ///</summary>
        ProjectilesBullets = ((long) ItemCategory.Projectiles << 32) | 3,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Books (0)
        ///</summary>
        RecipesBooks = ((long) ItemCategory.Recipes << 32) | 0,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Alchemy (6)
        ///</summary>
        RecipesAlchemy = ((long) ItemCategory.Recipes << 32) | 6,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Blacksmithing (4)
        ///</summary>
        RecipesBlacksmithing = ((long) ItemCategory.Recipes << 32) | 4,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Cooking (5)
        ///</summary>
        RecipesCooking = ((long) ItemCategory.Recipes << 32) | 5,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Enchanting (8)
        ///</summary>
        RecipesEnchanting = ((long) ItemCategory.Recipes << 32) | 8,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Engineering (3)
        ///</summary>
        RecipesEngineering = ((long) ItemCategory.Recipes << 32) | 3,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: First Aid (7)
        ///</summary>
        RecipesFirstAid = ((long) ItemCategory.Recipes << 32) | 7,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Fishing (9)
        ///</summary>
        RecipesFishing = ((long) ItemCategory.Recipes << 32) | 9,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Inscription (11)
        ///</summary>
        RecipesInscription = ((long) ItemCategory.Recipes << 32) | 11,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Jewelcrafting (10)
        ///</summary>
        RecipesJewelCrafting = ((long) ItemCategory.Recipes << 32) | 10,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Leatherworking (1)
        ///</summary>
        RecipesLeatherworking = ((long) ItemCategory.Recipes << 32) | 1,

        ///<summary>
        ///  Category: Recipes (9) - Sub-Category: Tailoring (2)
        ///</summary>
        RecipesTailoring = ((long) ItemCategory.Recipes << 32) | 2,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Meta (6)
        ///</summary>
        GemsMeta = ((long) ItemCategory.Gems << 32) | 6,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Red (0)
        ///</summary>
        GemsRed = ((long) ItemCategory.Gems << 32) | 0,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Blue (1)
        ///</summary>
        GemsBlue = ((long) ItemCategory.Gems << 32) | 1,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Yellow (2)
        ///</summary>
        GemsYellow = ((long) ItemCategory.Gems << 32) | 2,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Purple (3)
        ///</summary>
        GemsPurple = ((long) ItemCategory.Gems << 32) | 3,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Green (4)
        ///</summary>
        GemsGreen = ((long) ItemCategory.Gems << 32) | 4,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Orange (5)
        ///</summary>
        GemsOrange = ((long) ItemCategory.Gems << 32) | 5,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Prismatic (8)
        ///</summary>
        GemsPrismatic = ((long) ItemCategory.Gems << 32) | 8,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: CrystalOfFear (9)
        ///</summary>
        GemsCrystalOfFear = ((long) ItemCategory.Gems << 32) | 9,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Cogwheel (10)
        ///</summary>
        GemsCogwheel = ((long) ItemCategory.Gems << 32) | 10,

        ///<summary>
        ///  Category: Gems (3) - Sub-Category: Simple (7)
        ///</summary>
        GemsSimple = ((long) ItemCategory.Gems << 32) | 7,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Holiday (3)
        ///</summary>
        MiscellaneousHoliday = ((long) ItemCategory.Miscellaneous << 32) | 3,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Junk (0)
        ///</summary>
        MiscellaneousJunk = ((long) ItemCategory.Miscellaneous << 32) | 0,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Reagents (1)
        ///</summary>
        MiscellaneousReagents = ((long) ItemCategory.Miscellaneous << 32) | 1,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Mounts (5)
        ///</summary>
        MiscellaneousMounts = ((long) ItemCategory.Miscellaneous << 32) | 5,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Companions (2)
        ///</summary>
        MiscellaneousCompanions = ((long) ItemCategory.Miscellaneous << 32) | 2,

        ///<summary>
        ///  Category: Miscellaneous (15) - Sub-Category: Other (4)
        ///</summary>
        MiscellaneousOther = ((long) ItemCategory.Miscellaneous << 32) | 4,

        /// <summary>
        ///   Category: Quiver (11) - Sub-Category: Quiver (2)
        /// </summary>
        QuiverQuiver = ((long) ItemCategory.Quiver << 32) | 2,

        /// <summary>
        ///   Category: Quiver (11) - Sub-Category: Ammo Pouch (3)
        /// </summary>
        QuiverAmmoPouch = ((long) ItemCategory.Quiver << 32) | 3,

        /// <summary>
        ///   Category: Quest (12) - Sub-Category: Quest (0)
        /// </summary>
        QuestQuest = ((long) ItemCategory.Quest << 32) | 0,

        /// <summary>
        ///   Category: Key (13) - Sub-Category: LockPick (1)
        /// </summary>
        KeysLockPick = ((long) ItemCategory.Keys << 32) | 1,

        /// <summary>
        ///   Category: Key (13) - Sub-Category: Key (0)
        /// </summary>
        KeysKey = ((long) ItemCategory.Keys << 32) | 0,

        /// <summary>
        ///   Category: BattlePet (17) - Sub-Category: BattlePet (0)
        /// </summary>
        BattlePetsBattlePet = ((long) ItemCategory.BattlePets << 32) | 0,
    }
}