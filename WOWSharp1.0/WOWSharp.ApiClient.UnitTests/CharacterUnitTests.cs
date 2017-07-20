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
    public class CharacterUnitTests
    {
        [TestMethod]
        public void TestCharacterProfessions()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Professions);
            Assert.IsNotNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.Stats);

            Assert.IsNotNull(character.Professions.PrimaryProfessions);
            Assert.AreEqual(character.Professions.PrimaryProfessions.Count, 2);
            Assert.IsTrue(character.Professions.PrimaryProfessions.Any(p => p.Id == TestConstants.TestProfession1));
            Assert.IsTrue(character.Professions.PrimaryProfessions.Any(p => p.Id == TestConstants.TestProfession2));
            foreach (var profession in character.Professions.PrimaryProfessions)
            {
                Assert.IsNotNull(profession.Name);
                Assert.IsTrue(profession.Rank >= 525);
                Assert.IsTrue(profession.Maximum >= 525);
                Assert.IsNotNull(profession.Recipes);
                Assert.IsTrue(profession.Recipes.Count > 0);
                Assert.IsNotNull(profession.Icon);
                Assert.IsNotNull(profession.ToString());
            }
            Assert.IsNotNull(character.Professions.ToString());

            Assert.IsNotNull(character.Professions.SecondaryProfessions);
            Assert.AreEqual(character.Professions.SecondaryProfessions.Count, 4);

            foreach (var profession in character.Professions.SecondaryProfessions)
            {
                Assert.IsNotNull(profession.Name);
                Assert.IsTrue(profession.Rank >= 525);
                Assert.IsTrue(profession.Maximum >= 525);
                if (profession.Id == Skill.Cooking || profession.Id == Skill.FirstAid)
                {
                    Assert.IsNotNull(profession.Recipes);
                    Assert.IsTrue(profession.Recipes.Count > 0);
                }
                Assert.IsNotNull(profession.Icon);
            }

            var cp = new CharacterProfession();
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            cp.ToString();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
            var cps = new CharacterProfessions();
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            cps.ToString();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
        }

        [TestMethod]
        public void TestCharacterAchievements()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Achievements);
            Assert.IsNull(character.Professions);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.PetSlots);
            Assert.IsNull(character.Pets);
            Assert.IsNull(character.HunterPets);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

            Assert.IsNotNull(character.Achievements.AchievementsCompleted);
            Assert.AreNotEqual(character.Achievements.AchievementsCompleted.Count, 0);
            Assert.IsNotNull(character.Achievements.AchievementsCompletedTimestamps);
            Assert.IsNotNull(character.Achievements.Criteria);
            Assert.IsNotNull(character.Achievements.AchievementsCompletedDatesUtc);
            Assert.IsNotNull(character.Achievements.CriteriaCreatedTimestamps);
            Assert.IsNotNull(character.Achievements.CriteriaCreatedDatesUtc);
            Assert.IsNotNull(character.Achievements.CriteriaTimestamps);
            Assert.IsNotNull(character.Achievements.CriteriaDatesUtc);
            Assert.IsNotNull(character.Achievements.CriteriaQuantity);

            var a = new Achievements();
            Assert.IsNull(a.AchievementsCompletedDatesUtc);
            Assert.IsNull(a.CriteriaCreatedDatesUtc);
            Assert.IsNull(a.CriteriaDatesUtc);
        }

        [TestMethod]
        public void TestCharacterCompanions()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Pets);
            Assert.IsNotNull(character.Pets);
            Assert.IsNotNull(character.Pets.Collected);
            Assert.AreNotEqual(character.Pets.CollectedCount, 0);
            Assert.AreNotEqual(character.Pets.NotCollectedCount, 0);
            Assert.AreEqual(character.Pets.CollectedCount, character.Pets.Collected.Count);
        }

        [TestMethod]
        public void TestCharacterMounts()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Mounts);
            Assert.IsNotNull(character.Mounts);
            Assert.IsNotNull(character.Mounts.Collected);
            Assert.AreNotEqual(character.Mounts.Collected.Count, 0);
            Assert.AreNotEqual(character.Mounts.NotCollectedCount, 0);
            Assert.AreNotEqual(character.Mounts.CollectedCount, 0);
            Assert.AreEqual(character.Mounts.CollectedCount, character.Mounts.Collected.Count);
        }

        [TestMethod]
        public void TestCharacterStats()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Stats);
            Assert.IsNotNull(character.Stats);
            Assert.IsTrue(character.Stats.Stamina > 0);
            Assert.IsTrue(character.Stats.Agility > 0);
            Assert.IsTrue(character.Stats.Armor > 0);
            Assert.IsTrue(character.Stats.Intellect > 0);
            Assert.IsTrue(character.Stats.Spirit > 0);
            Assert.IsTrue(character.Stats.Strength > 0);
        }

        [TestMethod]
        public void TestCharacterReputation()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Reputation);
            Assert.IsNotNull(character.Reputations);
            Assert.IsTrue(character.Reputations.Count > 0);

            Assert.IsTrue(character.Reputations.Any(o => o.Standing == Standing.Exalted));
            Assert.IsFalse(character.Reputations.Any(o => o.Maximum == 0));
            Assert.IsFalse(character.Reputations.Any(o => o.Id == 0));
            Assert.IsFalse(character.Reputations.Any(o => string.IsNullOrEmpty(o.Name)));
            Assert.IsTrue(character.Reputations.Any(o => o.Value > 0));
            Assert.IsNotNull(character.Reputations[0].ToString());
        }

        [TestMethod]
        public void TestCharacterTitles()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Titles);
            Assert.IsNotNull(character.Titles);
            Assert.IsTrue(character.Titles.Count > 0);

            Assert.IsTrue(character.Titles.Any(o => o.IsSelected));
            Assert.IsFalse(character.Titles.Any(o => o.Id == 0));
            Assert.IsFalse(character.Titles.Any(o => string.IsNullOrEmpty(o.Name)));
            Assert.IsNotNull(character.Titles[0].ToString());
        }

        [TestMethod]
        public void TestCharacterSpec()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Talents);
            Assert.IsNotNull(character.Talents);
            Assert.IsTrue(character.Talents.Any(t => t.IsSelected));
            foreach (var ct in character.Talents)
            {
                Assert.IsNotNull(ct.CalculatorGlyphs);
                Assert.IsNotNull(ct.CalculatorSpecialization);
                Assert.IsNotNull(ct.CalculatorTalent);
                Assert.IsNotNull(ct.Glyphs);
                Assert.IsNotNull(ct.Build);
                Assert.IsNotNull(ct.Build.Count > 0);
                Assert.IsTrue(ct.Build.Any(t => t.Column > 0));
                Assert.IsTrue(ct.Build.Any(t => t.Tier > 0));
                Assert.IsNotNull(ct.Build[0].Spell);
                Assert.IsTrue(ct.Build.Any(t => t.Spell.CastTime != null));
                Assert.IsNotNull(ct.Build[0].Spell.Description);
                Assert.IsNotNull(ct.Build[0].Spell.Icon);
                Assert.IsNotNull(ct.Build[0].Spell.Name);
                Assert.IsNotNull(ct.Build[0].Spell.ToString());
                //Assert.IsTrue(ct.Build.Any(t => t.Spell.Range != null));
                //Assert.IsNotNull(ct.Build[0].Spell.Subtext);
                Assert.IsTrue(ct.Build[0].Spell.Id > 0);
                Assert.IsNotNull(ct.ToString());
                Assert.IsNotNull(ct.Specialization);
                Assert.IsNotNull(ct.Specialization.Name);
                Assert.IsNotNull(ct.Specialization.RoleName);
                Assert.AreNotEqual(CharacterRoles.None, ct.Specialization.Role);
                Assert.IsNotNull(ct.Specialization.Order > 0);
                Assert.IsNotNull(ct.Specialization.BackgroundImage);
                Assert.IsNotNull(ct.Specialization.Description);
                Assert.IsNotNull(ct.Specialization.Icon);
                Assert.IsNotNull(ct.Specialization.ToString());
                Assert.IsNotNull(ct.Glyphs);
                Assert.IsNotNull(ct.Glyphs.MajorGlyphs);
                Assert.IsNotNull(ct.Glyphs.MinorGlyphs);
                Assert.IsTrue(ct.Glyphs.MajorGlyphs.Count > 0);
                Assert.IsTrue(ct.Glyphs.MinorGlyphs.Count > 0);
                Assert.IsNotNull(ct.Glyphs.MajorGlyphs[0].Name);
                Assert.IsNotNull(ct.Glyphs.MajorGlyphs[0].Icon);
                Assert.IsTrue(ct.Glyphs.MajorGlyphs[0].GlyphId > 0);
                Assert.IsTrue(ct.Glyphs.MajorGlyphs[0].ItemId > 0);
                Assert.AreEqual(ct.Glyphs.MajorGlyphs[0].Name, ct.Glyphs.MajorGlyphs[0].ToString());
            }
        }

        //[TestMethod]
        //public void TestCharacterTitles()
        //{
        //    WowClient client = new WowClient(TestConstants.TestRegionName, null, null, null);
        //    var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Talents);
        //    Assert.IsNotNull(character.Titles);
        //    Assert.IsTrue(character.Titles.Length > 0);

        //    Assert.IsTrue(character.Titles.Any(o => o.IsSelected));
        //    Assert.IsFalse(character.Titles.Any(o => o.Id == 0));
        //    Assert.IsFalse(character.Titles.Any(o => string.IsNullOrEmpty(o.Name)));
        //}


        [TestMethod]
        public void TestCharacterProgression()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Progression);
            Assert.IsNotNull(character.Progression);
            Assert.IsNotNull(character.Progression.Raids);
            Assert.AreNotEqual(character.Progression.Raids.Count, 0);

            foreach (var raid in character.Progression.Raids)
            {
                Assert.IsNotNull(raid);
                Assert.IsTrue(raid.Id > 0);
                Assert.IsNotNull(raid.Name);
                Assert.IsNotNull(raid.Bosses);
                Assert.AreNotEqual(raid.Bosses.Count, 0);

                foreach (var boss in raid.Bosses)
                {
                    Assert.IsNotNull(boss);
                    Assert.IsNotNull(boss.Name);
                    // The assert is removed because some fights have no Id like Gunship Battle or Will of the Emperor
                    //Assert.IsTrue(boss.Id > 0);
                    if (boss.Name.Contains("Halfus"))
                    {
                        Assert.IsTrue(boss.NormalKills > 0);
                        Assert.IsTrue(boss.HeroicKills > 0);
                    }
                    if (boss.Name.Contains("Elegon"))
                    {
                        Assert.IsTrue(boss.NormalKills > 1);
                        Assert.IsTrue(boss.LfrKills > 1);
                        Assert.IsTrue(boss.HeroicKills >= 1);
                        Assert.IsTrue(boss.HeroicTimestamp.GetValueOrDefault() > 0);
                        Assert.IsTrue(boss.LfrTimestamp.GetValueOrDefault() > 0);
                        Assert.IsTrue(boss.NormalTimestamp > 0);
                        Assert.IsTrue(boss.HeroicFirstKillUtc.HasValue);
                        Assert.IsTrue(boss.NormalFirstKillUtc.HasValue);
                        Assert.IsTrue(boss.LfrFirstKillUtc.HasValue);
                    }
                    if (boss.Name.Contains("Garrosh Hellscream"))
                    {
                        Assert.IsTrue(boss.FlexKills.HasValue);
                        Assert.IsTrue(boss.FlexTimestamp.HasValue);
                    }
                }
            }
        }

        [TestMethod]
        public void TestCharacterGuild()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Guild);
            Assert.IsNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);

            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

            Assert.IsNotNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.Stats);

            Assert.IsTrue(character.Guild.AchievementPoints > 0);
            Assert.IsTrue(character.Guild.Level >= 25);
            Assert.AreEqual(character.Guild.Name, TestConstants.TestGuildName, true);
            Assert.AreEqual(character.Guild.Realm, TestConstants.TestRealmName, true);
            Assert.IsNotNull(character.Guild.Emblem);
            Assert.IsNotNull(character.Guild.Emblem.BackgroundColor);
            Assert.IsNotNull(character.Guild.Emblem.BorderColor);
            Assert.IsNotNull(character.Guild.Emblem.IconColor);
            Assert.IsTrue(character.Guild.Emblem.Icon > 0);
            Assert.IsTrue(character.Guild.Emblem.Border >= 0);

            Assert.IsNotNull(character.Guild.ToString());
        }

        /// <summary>
        ///   Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacterAllFields()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, true);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Professions);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Items);
            Assert.IsNotNull(character.Titles);
            Assert.IsNotNull(character.Mounts);
            Assert.IsNotNull(character.Pets);
            Assert.IsNotNull(character.PetSlots);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Progression);
            Assert.IsNotNull(character.Appearance);
            Assert.IsNotNull(character.Pvp);
            Assert.IsNotNull(character.CompletedQuestIds);
            Assert.IsNotNull(character.Reputations);
            Assert.IsNotNull(character.Stats);
            Assert.IsNotNull(character.Talents);


            Assert.AreEqual(character.Class, TestConstants.TestClass);
            Assert.IsTrue(character.Level >= 85);
            Assert.AreEqual(character.Race, TestConstants.TestRace);
            Assert.IsTrue(character.AchievementPoints > 0);
            Assert.AreEqual(character.Gender, TestConstants.TestGender);

            Assert.AreEqual(character.Realm, TestConstants.TestRealmName, true);
            Assert.AreEqual(character.Name, TestConstants.TestCharacterName, true);
        }

        /// <summary>
        ///   Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacterNoFields()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, false);
            Assert.IsNotNull(character);
            Assert.IsNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.Stats);

            Assert.AreEqual(character.Class, TestConstants.TestClass);
            Assert.IsTrue(character.Level >= 85);
            Assert.AreEqual(character.Race, TestConstants.TestRace);
            Assert.IsTrue(character.AchievementPoints > 0);
            Assert.AreEqual(character.Gender, TestConstants.TestGender);

            Assert.AreEqual(character.Realm, TestConstants.TestRealmName, true);
            Assert.AreEqual(character.Name, TestConstants.TestCharacterName, true);
        }

        /// <summary>
        ///   Test char appearance
        /// </summary>
        [TestMethod]
        public void TestCharacterAppearance()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Appearance);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Appearance);
            //Assert.IsTrue(character.Appearance.FaceVariation > 0);
            //Assert.IsTrue(character.Appearance.FeatureVariation > 0);
            //Assert.IsTrue(character.Appearance.HairVariation > 0);
            //Assert.IsTrue(character.Appearance.ShowCloak);
            //Assert.IsTrue(character.Appearance.ShowHelm);
            //Assert.IsTrue(character.Appearance.SkinColor > 0);
        }

        /// <summary>
        ///   Test char gear
        /// </summary>
        [TestMethod]
        public void TestCharacterGear()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Items);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Items);
            Assert.IsNotNull(character.Items.ToString());

            Assert.AreSame(character.Items.Head, character.Items[EquipmentSlot.Head]);
            Assert.AreSame(character.Items.Neck, character.Items[EquipmentSlot.Neck]);
            Assert.AreSame(character.Items.Shoulder, character.Items[EquipmentSlot.Shoulder]);
            Assert.AreSame(character.Items.Back, character.Items[EquipmentSlot.Back]);
            Assert.AreSame(character.Items.Chest, character.Items[EquipmentSlot.Chest]);
            Assert.AreSame(character.Items.Tabard, character.Items[EquipmentSlot.Tabard]);
            Assert.AreSame(character.Items.Shirt, character.Items[EquipmentSlot.Shirt]);
            Assert.AreSame(character.Items.Wrist, character.Items[EquipmentSlot.Wrist]);
            Assert.AreSame(character.Items.Hands, character.Items[EquipmentSlot.Hands]);
            Assert.AreSame(character.Items.Waist, character.Items[EquipmentSlot.Waist]);
            Assert.AreSame(character.Items.Legs, character.Items[EquipmentSlot.Legs]);
            Assert.AreSame(character.Items.Feet, character.Items[EquipmentSlot.Feet]);
            Assert.AreSame(character.Items.Finger1, character.Items[EquipmentSlot.Finger1]);
            Assert.AreSame(character.Items.Finger2, character.Items[EquipmentSlot.Finger2]);
            Assert.AreSame(character.Items.Trinket1, character.Items[EquipmentSlot.Trinket1]);
            Assert.AreSame(character.Items.Trinket2, character.Items[EquipmentSlot.Trinket2]);
            Assert.AreSame(character.Items.Offhand, character.Items[EquipmentSlot.Offhand]);
            Assert.AreSame(character.Items.MainHand, character.Items[EquipmentSlot.MainHand]);

            var item = character.Items.AllItems.First();
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Name);
            Assert.IsTrue(item.ItemId > 0);
            Assert.IsNotNull(item.Icon);
            Assert.AreEqual(item.Name, item.ToString());

            item = character.Items.Chest;
            Assert.IsNotNull(item.Parameters);
            Assert.IsTrue(item.Parameters.Enchant.HasValue);
            Assert.IsTrue(item.Parameters.Enchant.Value > 0);
            Assert.IsTrue(item.Parameters.Gem0.HasValue);
            Assert.IsTrue(item.Parameters.Gem0.Value > 0);
            //Assert.IsTrue(item.Parameters.Gem1.HasValue);
            //Assert.IsTrue(item.Parameters.Gem1.Value > 0);
            //Assert.IsTrue(item.Parameters.Gem2.HasValue);
            //Assert.IsTrue(item.Parameters.Gem2.Value > 0);
            //Assert.IsFalse(item.Parameters.Gem3.HasValue);
            Assert.IsTrue((int) item.Quality >= (int) ItemQuality.Rare);
            //Assert.IsNotNull(item.Parameters.SetItems);
            //Assert.IsTrue(item.Parameters.SetItems.Count > 0);
            //Assert.IsTrue(item.Parameters.TransmogrifyItemId.HasValue);
            //Assert.IsTrue(item.Parameters.TransmogrifyItemId.Value > 0);
            Assert.IsFalse(item.Parameters.Tinker.HasValue);

            var ritem = character.Items.AllItems.Any(i => i.Parameters.Reforge.HasValue);
            Assert.IsTrue(ritem);
        }

        /// <summary>
        ///   test hunter pets
        /// </summary>
        [TestMethod]
        public void TestCharacterHunterPets()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestHunter,
                                                CharacterFields.HunterPets);
            Assert.IsNotNull(character.HunterPets);
            Assert.IsTrue(character.HunterPets.Count > 0);
            Assert.IsNotNull(character.HunterPets[0].CalculatorSpecialization);
            Assert.IsNotNull(character.HunterPets[0].Name);
            Assert.IsTrue(character.HunterPets[0].CreatureId > 0);
            Assert.IsTrue(character.HunterPets.Any(p => p.Slot > 0));

            var pet = character.HunterPets.FirstOrDefault(p => p.Specialization != null && p.Specialization.Order > 0);

            Assert.IsNotNull(pet);
            Assert.IsNotNull(pet.Specialization.BackgroundImage);
            Assert.IsNotNull(pet.Specialization.Description);
            Assert.IsNotNull(pet.Specialization.Icon);
            Assert.IsNotNull(pet.Specialization.Name);
            Assert.IsTrue(pet.Specialization.Order > 0);
            Assert.IsNotNull(pet.Specialization.Role);
            //Assert.IsTrue(character.HunterPets.Any(p => p.IsSelected));
        }

        /// <summary>
        ///   test character progression
        /// </summary>
        [TestMethod]
        public void TestCharacterProgression2()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Progression);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Progression);
            Assert.IsNotNull(character.Progression.Raids);
            Assert.IsTrue(character.Progression.Raids.Count > 0);

            var instance =
                character.Progression.Raids.FirstOrDefault(r => r.HeroicProgress == CharacterInstanceStatus.Completed);
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Name);
            Assert.IsTrue(instance.Id > 0);
            Assert.IsNotNull(instance.Bosses);
            Assert.IsTrue(instance.Bosses.Count > 0);
            Assert.IsNotNull(instance.Bosses[0]);
            Assert.IsNotNull(instance.Bosses[0].Name);
            Assert.IsNotNull(instance.Bosses[0].Id > 0);
            Assert.AreNotEqual(0, instance.Bosses[0].HeroicKills);
            Assert.AreNotEqual(1, instance.Bosses[0].NormalKills);

            Assert.AreEqual(CharacterInstanceStatus.Completed, instance.NormalProgress);
            Assert.IsNotNull(instance.ToString());
            Assert.IsNotNull(instance.Bosses[0].ToString());
        }

        /// <summary>
        ///   test character feeds
        /// </summary>
        [TestMethod]
        public void TestCharacterFeeds()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Feed);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Feed);
            Assert.IsTrue(character.Feed.All(f => f != null));
            Assert.IsTrue(character.Feed.All(f => f.Achievement != null || f.FeedItemType != FeedItemType.Achievement));
            Assert.IsTrue(character.Feed.All(f => f.ItemId > 0 || f.FeedItemType != FeedItemType.Loot));
            Assert.IsTrue(character.Feed.All(f => f.Criteria != null || f.FeedItemType != FeedItemType.Criteria));
        }
    }
}