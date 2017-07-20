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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestItemAgilityCloak()
        {
            const int id = 77095;
            // Batwing Cloak
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);
            Assert.IsNotNull(item.Name);
            Assert.AreEqual(item.Name, item.ToString());
            Assert.IsTrue(item.BaseArmor > 0);
            Assert.IsTrue(item.SellPrice > 0);
            Assert.IsTrue(item.DisenchantingSkillRank.HasValue && item.DisenchantingSkillRank.Value > 0);
            Assert.IsTrue(item.Equippable);
            Assert.IsNotNull(item.SocketInfo);
            Assert.IsNotNull(item.SocketInfo.Sockets);
            Assert.IsNotNull(item.SocketInfo.SocketBonus);
            Assert.AreEqual(1, item.SocketInfo.Sockets.Count);
            Assert.AreEqual(SocketTypes.Red, item.SocketInfo.Sockets[0].SocketType);
            Assert.IsNotNull(item.SocketInfo.Sockets[0].SocketTypeName);
            Assert.IsNotNull(item.SocketInfo.Sockets[0].ToString());
            Assert.IsTrue(item.HasSockets);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(ItemInventoryType.Back, item.InventoryType);
            Assert.AreEqual(397, item.ItemLevel);
            Assert.AreEqual(ItemQuality.Epic, item.ItemQuality);
            Assert.IsTrue(item.RequiredLevel >= 85);
            Assert.IsTrue(item.DisplayInfoId > 0);
            Assert.AreEqual(ItemBindType.BindOnPickup, item.BindType);

            Assert.IsNotNull(item.BonusStats);
            Assert.IsTrue(item.BonusStats.Count > 0);
            Assert.IsNotNull(item.BonusStats[0]);
            Assert.IsNotNull(item.BonusStats[0].ToString());
            Assert.IsFalse(item.BonusStats[0].IsReforged);
            Assert.IsTrue(item.BonusStats[0].Amount > 0);
            Assert.IsTrue(item.BonusStats.Any(b => b.StatType == ItemStatType.Agility));
        }

        [TestMethod]
        public void TestItemAgilityChestDruidTierSet()
        {
            const int id = 78760;
            // Deep Earth Raiment
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);
            Assert.IsNotNull(item.Name);
            Assert.AreEqual(item.Name, item.ToString());
            Assert.IsTrue(item.BaseArmor > 0);
            Assert.IsTrue(item.SellPrice > 0);
            Assert.IsTrue(item.DisenchantingSkillRank.HasValue && item.DisenchantingSkillRank.Value > 0);
            Assert.IsTrue(item.Equippable);
            Assert.IsTrue(item.HasSockets);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(ItemInventoryType.Robe, item.InventoryType);
            Assert.AreEqual(ItemQuality.Epic, item.ItemQuality);
            Assert.IsTrue(item.RequiredLevel >= 85);

            Assert.IsTrue(item.MaximumDurability > 0);
            Assert.IsNotNull(item.AllowableClasses);
            Assert.AreEqual(1, item.AllowableClasses.Count);
            Assert.AreEqual(ClassKey.Druid, item.AllowableClasses[0]);

            Assert.IsNotNull(item.ItemSet);
            Assert.IsNotNull(item.ItemSet.Bonuses);
            Assert.AreEqual(2, item.ItemSet.Bonuses.Count);
            Assert.IsTrue(item.ItemSet.Id > 0);
            Assert.IsNotNull(item.ItemSet.Name);

            Assert.IsNotNull(item.ItemSet.ToString());
            Assert.IsNotNull(item.ItemSet.Bonuses[0].ToString());
            Assert.IsNotNull(item.ItemSet.Bonuses[0].Description);
            Assert.AreEqual(2, item.ItemSet.Bonuses[0].Threshold);

            Assert.IsNotNull(client.GetItemSet(item.ItemSet.Id));
        }

        [TestMethod]
        public void TestItemAgilityPoleArm()
        {
            const int id = 77194;
            // Kiril, fury of beasts
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);
            Assert.IsNotNull(item.Name);
            Assert.AreEqual(item.Name, item.ToString());
            Assert.IsTrue(item.BuyPrice > 0);
            Assert.IsTrue(item.SellPrice > 0);
            Assert.IsTrue(item.DisenchantingSkillRank.HasValue && item.DisenchantingSkillRank.Value > 0);
            Assert.IsTrue(item.Equippable);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(ItemInventoryType.TwoHanded, item.InventoryType);
            Assert.AreEqual(ItemQuality.Epic, item.ItemQuality);
            Assert.IsTrue(item.RequiredLevel >= 85);

            Assert.IsNotNull(item.Source);
            Assert.IsTrue(item.Source.SourceId > 0);
            Assert.IsNotNull(item.Source.SourceType);
            Assert.IsNotNull(item.Source.ToString());

            Assert.AreEqual(ItemSubcategory.WeaponsPoleArms, item.Subcategory);
            Assert.AreEqual(ItemCategory.Weapons, item.Category);
            Assert.IsTrue(item.SubcategoryId > 0);

            Assert.IsNotNull(item.WeaponInfo);
            Assert.IsNotNull(item.WeaponInfo.Damage);
            Assert.IsTrue(item.WeaponInfo.Damage.MaximumDamage > 0);
            Assert.IsTrue(item.WeaponInfo.Damage.MinimumDamage > 0);
            Assert.IsTrue(item.WeaponInfo.DamagePerSecond > 0);
            Assert.IsTrue(item.WeaponInfo.Speed > 0);
            Assert.IsNotNull(item.WeaponInfo.ToString());
            Assert.IsNotNull(item.WeaponInfo.Damage.ToString());

            Assert.IsNotNull(item.ItemSpells);
            Assert.IsTrue(item.ItemSpells.Count > 0);
            Assert.IsNotNull(item.ItemSpells[0].Spell);
            Assert.IsTrue(item.ItemSpells[0].SpellId > 0);
            Assert.AreEqual(ItemSpellTriggers.Equipped, item.ItemSpells[0].Trigger);
            Assert.IsNotNull(item.ItemSpells[0].TriggerName);
            Assert.IsNotNull(item.ItemSpells[0].ToString());
        }

        /// <summary>
        ///   test bags
        /// </summary>
        [TestMethod]
        public void TestBag()
        {
            const int id = 38082;
            // "Gigantique" Bag
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);
            Assert.AreEqual(22, item.ContainerSlots);
        }

        /// <summary>
        ///   test gems
        /// </summary>
        [TestMethod]
        public void TestGem()
        {
            int id = 52255;
            // Bold Chimera's Eye
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.Bonus.Name);
            Assert.IsNotNull(item.GemInfo.Bonus.ToString());
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.RequiredSkillId == Skill.JewelCrafting);
            Assert.IsTrue(item.GemInfo.Bonus.RequiredSkillRank > 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);
            Assert.IsTrue(item.RequiredProfession == Skill.JewelCrafting);
            Assert.IsTrue(item.RequiredProfessionRank > 0);

            id = 49110;
            // nightmare tear
            item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(SocketTypes.Prismatic, item.GemInfo.TypeOfGem.SocketType);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);

            id = 59477;
            // subtle cogwheel
            item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(SocketTypes.Cogwheel, item.GemInfo.TypeOfGem.SocketType);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);

            id = 68356;
            // Willful Ember Topaz
            item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(SocketTypes.Orange, item.GemInfo.TypeOfGem.SocketType);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);
            Assert.IsTrue(item.IsAuctionable);
            Assert.IsTrue(item.MaxStackSize > 1);
            Assert.IsTrue(item.BuyPrice > 0);
            Assert.IsTrue(item.IsAuctionable);

            id = 89873;
            // Crystallized Dread
            item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(SocketTypes.Hydraulic, item.GemInfo.TypeOfGem.SocketType);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);
            Assert.IsNotNull(item.Description);

            id = 52296;
            // Ember Shadowspirit Diamond
            item = client.GetItem(id);
            Assert.IsNotNull(item.GemInfo);
            Assert.IsNotNull(item.GemInfo.Bonus);
            Assert.IsNotNull(item.GemInfo.TypeOfGem);
            Assert.IsNotNull(item.GemInfo.TypeOfGem.Name);
            Assert.AreEqual(SocketTypes.Meta, item.GemInfo.TypeOfGem.SocketType);
            Assert.AreEqual(item.GemInfo.TypeOfGem.SocketType.ToString(), item.GemInfo.TypeOfGem.ToString());
            Assert.IsTrue(item.GemInfo.Bonus.ItemLevel > 0);
            Assert.IsTrue(item.GemInfo.Bonus.MinimumLevel >= 0);
            Assert.IsTrue(item.GemInfo.Bonus.SourceItemId == id);
        }

        [TestMethod]
        public void TestUniqueTabard()
        {
            const int id = 31781;
            // Sha'tar Tabard
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var item = client.GetItem(id);

            Assert.IsTrue(item.MaxCount > 0);
            Assert.IsTrue(item.MinimumFactionId > 0);
            Assert.IsTrue(item.MinimumFactionStanding == Standing.Exalted);
        }

        [TestMethod]
        public void TestItemCategories()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var result = client.GetItemCategoryNames();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CategoryNames);
            Assert.IsTrue(result.CategoryNames.Count > 0);
            foreach (var cat in result.CategoryNames)
            {
                Assert.IsNotNull(cat.Name);
                Assert.IsTrue((int) cat.Category >= 0);
                Assert.IsNotNull(cat.ToString());

                if (cat.Subcategories != null)
                {
                    foreach (var sub in cat.Subcategories)
                    {
                        Assert.IsNotNull(sub.Name);
                        Assert.IsTrue(sub.SubcategoryId >= 0);
                        Assert.IsNotNull(sub.ToString());
                    }
                }
            }
        }
    }
}