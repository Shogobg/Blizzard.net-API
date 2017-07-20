using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community.ObjectModel;

namespace WOWSharp.Community.UnitTest
{
    [TestClass]
    public class CharacterUnitTests
    {
        [TestMethod]
        public void TestCharacterProfessions()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Professions);
            Assert.IsNotNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.Companions);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

            Assert.IsNotNull(character.Professions.PrimaryProfessions);
            Assert.AreEqual(character.Professions.PrimaryProfessions.Length, 2);
            Assert.IsTrue(character.Professions.PrimaryProfessions.Any(p => p.Id == Skill.Alchemy));
            Assert.IsTrue(character.Professions.PrimaryProfessions.Any(p => p.Id == Skill.Leatherworking));
            for (int i = 0; i < character.Professions.PrimaryProfessions.Length; i++)
            {
                CharacterProfession profession = character.Professions.PrimaryProfessions[i];
                Assert.IsNotNull(profession.Name);
                Assert.IsTrue(profession.Rank >= 525);
                Assert.IsTrue(profession.Maximum >= 525);
                Assert.IsNotNull(profession.Recipes);
                Assert.IsTrue(profession.Recipes.Length > 0);
                Assert.IsNotNull(profession.Icon);
            }

            Assert.IsNotNull(character.Professions.SecondaryProfessions);
            Assert.AreEqual(character.Professions.SecondaryProfessions.Length, 4);

            for (int i = 0; i < character.Professions.SecondaryProfessions.Length; i++)
            {
                CharacterProfession profession = character.Professions.SecondaryProfessions[i];
                Assert.IsNotNull(profession.Name);
                Assert.IsTrue(profession.Rank >= 525);
                Assert.IsTrue(profession.Maximum >= 525);
                if (profession.Id == Skill.Cooking || profession.Id == Skill.FirstAid)
                {
                    Assert.IsNotNull(profession.Recipes);
                    Assert.IsTrue(profession.Recipes.Length > 0);
                }
                Assert.IsNotNull(profession.Icon);
            }

            
        }

        [TestMethod]
        public void TestCharacterAchievements()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Achievements);
            Assert.IsNull(character.Professions);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.Companions);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

            Assert.IsNotNull(character.Achievements.AchievementsCompleted);
            Assert.AreNotEqual(character.Achievements.AchievementsCompleted.Length, 0);
            Assert.IsNotNull(character.Achievements.AchievementsCompletedTimestamps);
            Assert.IsNotNull(character.Achievements.Criteria);
        }

        [TestMethod]
        public void TestCharacterAppearance()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Appearance);
            Assert.IsNotNull(character.Appearance);
        }

        [TestMethod]
        public void TestCharacterCompanions()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Companions);
            Assert.IsNotNull(character.Companions);
            Assert.AreNotEqual(character.Companions.Length, 0);
        }

        [TestMethod]
        public void TestCharacterMounts()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Mounts);
            Assert.IsNotNull(character.Mounts);
            Assert.AreNotEqual(character.Mounts.Length, 0);
        }

        [TestMethod]
        public void TestCharacterStats()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Stats);
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
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Reputation);
            Assert.IsNotNull(character.Reputations);
            Assert.IsTrue(character.Reputations.Length > 0);
            
            Assert.IsTrue(character.Reputations.Any(o => o.Standing == Standing.Exalted));
            Assert.IsFalse(character.Reputations.Any(o => o.Maximum == 0));
            Assert.IsFalse(character.Reputations.Any(o => o.Id == 0));
            Assert.IsFalse(character.Reputations.Any(o => string.IsNullOrEmpty(o.Name)));
            Assert.IsTrue(character.Reputations.Any(o => o.Value > 0));
        }

        [TestMethod]
        public void TestCharacterTitles()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Titles);
            Assert.IsNotNull(character.Titles);
            Assert.IsTrue(character.Titles.Length > 0);

            Assert.IsTrue(character.Titles.Any(o => o.IsSelected));
            Assert.IsFalse(character.Titles.Any(o => o.Id == 0));
            Assert.IsFalse(character.Titles.Any(o => string.IsNullOrEmpty(o.Name)));
        }

        //[TestMethod]
        //public void TestCharacterTitles()
        //{
        //    ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
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
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Progression);
            Assert.IsNotNull(character.Progression);
            Assert.IsNotNull(character.Progression.Raids);
            Assert.AreNotEqual(character.Progression.Raids.Length, 0);

            for (int i = 0; i < character.Progression.Raids.Length; i++)
            {
                var raid = character.Progression.Raids[i];
                Assert.IsNotNull(raid);
                Assert.IsTrue(raid.Id > 0);
                Assert.IsNotNull(raid.Name);
                Assert.IsNotNull(raid.Bosses);
                Assert.AreNotEqual(raid.Bosses.Length, 0);

                for (int j = 0; j < raid.Bosses.Length; j++)
                {
                    var boss = raid.Bosses[j];
                    Assert.IsNotNull(boss);
                    Assert.IsNotNull(boss.Name);
                    Assert.IsTrue(boss.Id > 0);
                    if (boss.Name.Contains("Halfus"))
                    {
                        Assert.IsTrue(boss.NormalKills > 0);
                        Assert.IsTrue(boss.HeroicKills > 0);
                    }
                }
            }
        }

        [TestMethod]
        public void TestCharacterGuild()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterField.Guild);
            Assert.IsNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.Companions);
            Assert.IsNotNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

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
        }

        /// <summary>
        /// Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacterAllFields()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, true);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Professions);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Items);
            Assert.IsNotNull(character.Titles);
            Assert.IsNotNull(character.Mounts);
            Assert.IsNotNull(character.Companions);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Progression);
            Assert.IsNotNull(character.Appearance);
            Assert.IsNotNull(character.Pvp);
            Assert.IsNotNull(character.CompletedQuestIds);
            Assert.IsNotNull(character.Reputations);
            Assert.IsNotNull(character.Stats);
            Assert.IsNotNull(character.Talents);
            
            
            Assert.AreEqual(character.Class, Class.Druid);
            Assert.IsTrue(character.Level >= 85);
            Assert.AreEqual(character.Race, Race.Tauren);
            Assert.IsTrue(character.AchievementPoints > 0);
            Assert.AreEqual(character.Gender, CharacterGender.Male);
            
            Assert.AreEqual(character.Realm, TestConstants.TestRealmName, true);
            Assert.AreEqual(character.Name, TestConstants.TestCharacterName, true);
        }

        /// <summary>
        /// Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacterNoFields()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, false);
            Assert.IsNotNull(character);
            Assert.IsNull(character.Professions);
            Assert.IsNull(character.Achievements);
            Assert.IsNull(character.Items);
            Assert.IsNull(character.Titles);
            Assert.IsNull(character.Mounts);
            Assert.IsNull(character.Companions);
            Assert.IsNull(character.Guild);
            Assert.IsNull(character.Progression);
            Assert.IsNull(character.Appearance);
            Assert.IsNull(character.Pvp);
            Assert.IsNull(character.CompletedQuestIds);
            Assert.IsNull(character.Reputations);
            Assert.IsNull(character.Stats);
            Assert.IsNull(character.Talents);

            Assert.AreEqual(character.Class, Class.Druid);
            Assert.IsTrue(character.Level >= 85);
            Assert.AreEqual(character.Race, Race.Tauren);
            Assert.IsTrue(character.AchievementPoints > 0);
            Assert.AreEqual(character.Gender, CharacterGender.Male);

            Assert.AreEqual(character.Realm, TestConstants.TestRealmName, true);
            Assert.AreEqual(character.Name, TestConstants.TestCharacterName, true);
        }
    }
}
