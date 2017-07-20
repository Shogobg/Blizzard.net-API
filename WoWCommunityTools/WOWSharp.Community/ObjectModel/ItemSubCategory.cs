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

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Item Subcategory Enumeration
    /// </summary>
    public enum ItemSubCategory
    {
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Daggers (15)
        ///</summary>
        WeaponsDaggers = ((int)ItemCategory.Weapons << 16) | 15,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Fist Weapons (13)
        ///</summary>
        WeaponsFistWeapons = ((int)ItemCategory.Weapons << 16) | 13,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: One-Handed Axes (0)
        ///</summary>
        WeaponsOneHandedAxes = ((int)ItemCategory.Weapons << 16) | 0,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: One-Handed Maces (4)
        ///</summary>
        WeaponsOneHandedMaces = ((int)ItemCategory.Weapons << 16) | 4,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: One-Handed Swords (7)
        ///</summary>
        WeaponsOneHandedSwords = ((int)ItemCategory.Weapons << 16) | 7,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Polearms (6)
        ///</summary>
        WeaponsPolearms = ((int)ItemCategory.Weapons << 16) | 6,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Staves (10)
        ///</summary>
        WeaponsStaves = ((int)ItemCategory.Weapons << 16) | 10,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Two-Handed Axes (1)
        ///</summary>
        WeaponsTwoHandedAxes = ((int)ItemCategory.Weapons << 16) | 1,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Two-Handed Maces (5)
        ///</summary>
        WeaponsTwoHandedMaces = ((int)ItemCategory.Weapons << 16) | 5,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Two-Handed Swords (8)
        ///</summary>
        WeaponsTwoHandedSwords = ((int)ItemCategory.Weapons << 16) | 8,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Bows (2)
        ///</summary>
        WeaponsBows = ((int)ItemCategory.Weapons << 16) | 2,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Crossbows (18)
        ///</summary>
        WeaponsCrossbows = ((int)ItemCategory.Weapons << 16) | 18,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Guns (3)
        ///</summary>
        WeaponsGuns = ((int)ItemCategory.Weapons << 16) | 3,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Thrown (16)
        ///</summary>
        WeaponsThrown = ((int)ItemCategory.Weapons << 16) | 16,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Wands (19)
        ///</summary>
        WeaponsWands = ((int)ItemCategory.Weapons << 16) | 19,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Fishing Poles (20)
        ///</summary>
        WeaponsFishingPoles = ((int)ItemCategory.Weapons << 16) | 20,
        ///<summary>
        /// Category: Weapons (2) - Sub-Category: Miscellaneous (14)
        ///</summary>
        WeaponsMiscellaneous = ((int)ItemCategory.Weapons << 16) | 14,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Cloth (1)
        ///</summary>
        ArmorCloth = ((int)ItemCategory.Armor << 16) | 1,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Leather (2)
        ///</summary>
        ArmorLeather = ((int)ItemCategory.Armor << 16) | 2,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Mail (3)
        ///</summary>
        ArmorMail = ((int)ItemCategory.Armor << 16) | 3,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Plate (4)
        ///</summary>
        ArmorPlate = ((int)ItemCategory.Armor << 16) | 4,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Relics (11)
        ///</summary>
        ArmorRelics = ((int)ItemCategory.Armor << 16) | 11,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Shields (6)
        ///</summary>
        ArmorShields = ((int)ItemCategory.Armor << 16) | 6,
        ///<summary>
        /// Category: Armor (4) - Sub-Category: Miscellaneous (0)
        ///</summary>
        ArmorMiscellaneous = ((int)ItemCategory.Armor << 16) | 0,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Bags (0)
        ///</summary>
        ContainersBags = ((int)ItemCategory.Containers << 16) | 0,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Enchanting Bags (3)
        ///</summary>
        ContainersEnchantingBags = ((int)ItemCategory.Containers << 16) | 3,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Engineering Bags (4)
        ///</summary>
        ContainersEngineeringBags = ((int)ItemCategory.Containers << 16) | 4,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Gem Bags (5)
        ///</summary>
        ContainersGemBags = ((int)ItemCategory.Containers << 16) | 5,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Herb Bags (2)
        ///</summary>
        ContainersHerbBags = ((int)ItemCategory.Containers << 16) | 2,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Inscription Bags (8)
        ///</summary>
        ContainersInscriptionBags = ((int)ItemCategory.Containers << 16) | 8,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Leatherworking Bags (7)
        ///</summary>
        ContainersLeatherworkingBags = ((int)ItemCategory.Containers << 16) | 7,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Mining Bags (6)
        ///</summary>
        ContainersMiningBags = ((int)ItemCategory.Containers << 16) | 6,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Soul Bags (1)
        ///</summary>
        ContainersSoulBags = ((int)ItemCategory.Containers << 16) | 1,
        ///<summary>
        /// Category: Containers (1) - Sub-Category: Tackle Boxes (9)
        ///</summary>
        ContainersTackleBoxes = ((int)ItemCategory.Containers << 16) | 9,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Bandages (7)
        ///</summary>
        ConsumablesBandages = ((int)ItemCategory.Consumables << 16) | 7,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Consumables (0)
        ///</summary>
        ConsumablesConsumables = ((int)ItemCategory.Consumables << 16) | 0,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Elixirs (2)
        ///</summary>
        ConsumablesElixirs = ((int)ItemCategory.Consumables << 16) | 2,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Flasks (3)
        ///</summary>
        ConsumablesFlasks = ((int)ItemCategory.Consumables << 16) | 3,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Food & Drinks (5)
        ///</summary>
        ConsumablesFoodDrinks = ((int)ItemCategory.Consumables << 16) | 5,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Item Enhancements (Permanent) (6)
        ///</summary>
        ConsumablesItemEnhancements = ((int)ItemCategory.Consumables << 16) | 6,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Potions (1)
        ///</summary>
        ConsumablesPotions = ((int)ItemCategory.Consumables << 16) | 1,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Scrolls (4)
        ///</summary>
        ConsumablesScrolls = ((int)ItemCategory.Consumables << 16) | 4,
        ///<summary>
        /// Category: Consumables (0) - Sub-Category: Other (8)
        ///</summary>
        ConsumablesOther = ((int)ItemCategory.Consumables << 16) | 8,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Death Knight (6)
        ///</summary>
        GlyphsDeathKnight = ((int)ItemCategory.Glyphs << 16) | 6,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Druid (11)
        ///</summary>
        GlyphsDruid = ((int)ItemCategory.Glyphs << 16) | 11,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Hunter (3)
        ///</summary>
        GlyphsHunter = ((int)ItemCategory.Glyphs << 16) | 3,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Mage (8)
        ///</summary>
        GlyphsMage = ((int)ItemCategory.Glyphs << 16) | 8,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Paladin (2)
        ///</summary>
        GlyphsPaladin = ((int)ItemCategory.Glyphs << 16) | 2,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Priest (5)
        ///</summary>
        GlyphsPriest = ((int)ItemCategory.Glyphs << 16) | 5,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Rogue (4)
        ///</summary>
        GlyphsRogue = ((int)ItemCategory.Glyphs << 16) | 4,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Shaman (7)
        ///</summary>
        GlyphsShaman = ((int)ItemCategory.Glyphs << 16) | 7,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Warlock (9)
        ///</summary>
        GlyphsWarlock = ((int)ItemCategory.Glyphs << 16) | 9,
        ///<summary>
        /// Category: Glyphs (16) - Sub-Category: Warrior (1)
        ///</summary>
        GlyphsWarrior = ((int)ItemCategory.Glyphs << 16) | 1,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Armor Enchantments (14)
        ///</summary>
        TradeGoodsArmorEnchantments = ((int)ItemCategory.TradeGoods << 16) | 14,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Cloth (5)
        ///</summary>
        TradeGoodsCloth = ((int)ItemCategory.TradeGoods << 16) | 5,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Devices (3)
        ///</summary>
        TradeGoodsDevices = ((int)ItemCategory.TradeGoods << 16) | 3,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Elemental (10)
        ///</summary>
        TradeGoodsElemental = ((int)ItemCategory.TradeGoods << 16) | 10,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Enchanting (12)
        ///</summary>
        TradeGoodsEnchanting = ((int)ItemCategory.TradeGoods << 16) | 12,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Explosives (2)
        ///</summary>
        TradeGoodsExplosives = ((int)ItemCategory.TradeGoods << 16) | 2,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Herbs (9)
        ///</summary>
        TradeGoodsHerbs = ((int)ItemCategory.TradeGoods << 16) | 9,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Jewelcrafting (4)
        ///</summary>
        TradeGoodsJewelcrafting = ((int)ItemCategory.TradeGoods << 16) | 4,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Leather (6)
        ///</summary>
        TradeGoodsLeather = ((int)ItemCategory.TradeGoods << 16) | 6,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Materials (13)
        ///</summary>
        TradeGoodsMaterials = ((int)ItemCategory.TradeGoods << 16) | 13,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Meat (8)
        ///</summary>
        TradeGoodsMeat = ((int)ItemCategory.TradeGoods << 16) | 8,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Metal & Stone (7)
        ///</summary>
        TradeGoodsMetalStone = ((int)ItemCategory.TradeGoods << 16) | 7,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Parts (1)
        ///</summary>
        TradeGoodsParts = ((int)ItemCategory.TradeGoods << 16) | 1,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Weapon Enchantments (15)
        ///</summary>
        TradeGoodsWeaponEnchantments = ((int)ItemCategory.TradeGoods << 16) | 15,
        ///<summary>
        /// Category: Trade Goods (7) - Sub-Category: Other (11)
        ///</summary>
        TradeGoodsOther = ((int)ItemCategory.TradeGoods << 16) | 11,
        ///<summary>
        /// Category: Projectiles (6) - Sub-Category: Arrows (2)
        ///</summary>
        ProjectilesArrows = ((int)ItemCategory.Projectiles << 16) | 2,
        ///<summary>
        /// Category: Projectiles (6) - Sub-Category: Bullets (3)
        ///</summary>
        ProjectilesBullets = ((int)ItemCategory.Projectiles << 16) | 3,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Books (0)
        ///</summary>
        RecipesBooks = ((int)ItemCategory.Recipes << 16) | 0,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Alchemy (6)
        ///</summary>
        RecipesAlchemy = ((int)ItemCategory.Recipes << 16) | 6,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Blacksmithing (4)
        ///</summary>
        RecipesBlacksmithing = ((int)ItemCategory.Recipes << 16) | 4,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Cooking (5)
        ///</summary>
        RecipesCooking = ((int)ItemCategory.Recipes << 16) | 5,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Enchanting (8)
        ///</summary>
        RecipesEnchanting = ((int)ItemCategory.Recipes << 16) | 8,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Engineering (3)
        ///</summary>
        RecipesEngineering = ((int)ItemCategory.Recipes << 16) | 3,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: First Aid (7)
        ///</summary>
        RecipesFirstAid = ((int)ItemCategory.Recipes << 16) | 7,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Fishing (9)
        ///</summary>
        RecipesFishing = ((int)ItemCategory.Recipes << 16) | 9,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Inscription (11)
        ///</summary>
        RecipesInscription = ((int)ItemCategory.Recipes << 16) | 11,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Jewelcrafting (10)
        ///</summary>
        RecipesJewelcrafting = ((int)ItemCategory.Recipes << 16) | 10,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Leatherworking (1)
        ///</summary>
        RecipesLeatherworking = ((int)ItemCategory.Recipes << 16) | 1,
        ///<summary>
        /// Category: Recipes (9) - Sub-Category: Tailoring (2)
        ///</summary>
        RecipesTailoring = ((int)ItemCategory.Recipes << 16) | 2,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Meta (6)
        ///</summary>
        GemsMeta = ((int)ItemCategory.Gems << 16) | 6,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Red (0)
        ///</summary>
        GemsRed = ((int)ItemCategory.Gems << 16) | 0,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Blue (1)
        ///</summary>
        GemsBlue = ((int)ItemCategory.Gems << 16) | 1,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Yellow (2)
        ///</summary>
        GemsYellow = ((int)ItemCategory.Gems << 16) | 2,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Purple (3)
        ///</summary>
        GemsPurple = ((int)ItemCategory.Gems << 16) | 3,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Green (4)
        ///</summary>
        GemsGreen = ((int)ItemCategory.Gems << 16) | 4,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Orange (5)
        ///</summary>
        GemsOrange = ((int)ItemCategory.Gems << 16) | 5,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Prismatic (8)
        ///</summary>
        GemsPrismatic = ((int)ItemCategory.Gems << 16) | 8,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Hydraulic (9)
        ///</summary>
        GemsHydraulic = ((int)ItemCategory.Gems << 16) | 9,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Cogwheel (10)
        ///</summary>
        GemsCogwheel = ((int)ItemCategory.Gems << 16) | 10,
        ///<summary>
        /// Category: Gems (3) - Sub-Category: Simple (7)
        ///</summary>
        GemsSimple = ((int)ItemCategory.Gems << 16) | 7,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Holiday (3)
        ///</summary>
        MiscellaneousHoliday = ((int)ItemCategory.Miscellaneous << 16) | 3,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Junk (0)
        ///</summary>
        MiscellaneousJunk = ((int)ItemCategory.Miscellaneous << 16) | 0,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Reagents (1)
        ///</summary>
        MiscellaneousReagents = ((int)ItemCategory.Miscellaneous << 16) | 1,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Mounts (5)
        ///</summary>
        MiscellaneousMounts = ((int)ItemCategory.Miscellaneous << 16) | 5,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Companions (2)
        ///</summary>
        MiscellaneousCompanions = ((int)ItemCategory.Miscellaneous << 16) | 2,
        ///<summary>
        /// Category: Miscellaneous (15) - Sub-Category: Other (4)
        ///</summary>
        MiscellaneousOther = ((int)ItemCategory.Miscellaneous << 16) | 4,


    }
}
