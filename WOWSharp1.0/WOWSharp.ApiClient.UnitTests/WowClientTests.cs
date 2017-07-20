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

using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
{
    [TestClass]
    public class WowClientTests
    {
        /// <summary>
        ///   Test auctions API
        /// </summary>
        [TestMethod]
        public void TestAuctions()
        {
            var client = new WowClient(TestConstants.TestRegionName,
                                       new ApiKeyPair(TestConstants.PublicKey, TestConstants.PrivateKey), null, null);
            //var result = client.GetAuctionDump(TestConstants.TestRealmName);
            var result = client.GetAuctionDump(TestConstants.TestAuctionHouseRealm);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Neutral);
            Assert.IsNotNull(result.Alliance);
            Assert.IsNotNull(result.Alliance.Auctions);
            Assert.IsNotNull(result.Horde);
            Assert.IsNotNull(result.Realm);

            Assert.IsNotNull(result.Horde.Auctions);
            Assert.IsTrue(result.Horde.Auctions.Count > 0);

            Assert.IsTrue(
                result.Horde.ToString().StartsWith(result.Horde.Auctions.Count.ToString(CultureInfo.InvariantCulture)));

            var auction = result.Horde.Auctions.FirstOrDefault(a => a.BuyoutValue.HasValue);
            Assert.IsNotNull(auction);
            Assert.IsTrue(auction.AuctionId > 0);
            Assert.IsTrue(auction.ItemId > 0);
            Assert.IsNotNull(auction.OwnerName != null);
            Assert.IsTrue(auction.Quantity >= 1);
            Assert.IsTrue(auction.CurrentBidValue > 0);
            Assert.IsTrue(auction.BuyoutValue != null && auction.BuyoutValue.Value >= auction.CurrentBidValue);
            Assert.IsNotNull(auction.ToString());

            var af = new AuctionFile();
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            af.LastModifiedValue.ToString(CultureInfo.InvariantCulture);
// ReSharper restore ReturnValueOfPureMethodIsNotUsed

            var ah = new AuctionHouse();
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            ah.ToString();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
        }

        /// <summary>
        ///   Test auctions API
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ApiException))]
        public void TestApiException()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            client.GetAuctionDump(TestConstants.TestRealmName + TestConstants.TestRealmName); // invalid realm name
            // should get realm not found
        }

        /// <summary>
        ///   Test get Item
        /// </summary>
        [TestMethod]
        public void TestItems()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var result = client.GetItem(17182);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ItemQuality == ItemQuality.Legendary);
            Assert.AreEqual(17182, result.Id);
            result = client.GetItem(86879);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsUpgradable);
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        public void TestPerks()
        {
            var client = new WowClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetGuildPerks();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Perks);
            Assert.IsNotNull(result.Perks.Count > 0);
            Assert.IsNotNull(result.Perks[0].ToString());
            Assert.IsTrue(result.Perks[0].GuildLevel > 0);
            Assert.IsTrue(result.Perks[0].Spell != null);
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        public void TestRewards()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var result = client.GetGuildRewards();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Rewards);
            Assert.IsTrue(result.Rewards.Count > 0);
            Assert.IsNotNull(result.Rewards[0].ToString());
            Assert.IsTrue(result.Rewards.Any(r => r.Races != null));
            Assert.IsTrue(result.Rewards.Any(r => r.MinimumGuildLevel >= 0));
            Assert.IsTrue((int) result.Rewards[0].MinimumGuildReputationLevel > (int) Standing.Unfriendly);
            Assert.IsNotNull(result.Rewards[0].RewardItem);
            Assert.IsNotNull(result.Rewards[0].RewardItem.Icon);
            Assert.IsTrue(result.Rewards[0].RewardItem.Quality != ItemQuality.Poor);
            Assert.IsTrue(result.Rewards[0].RewardItem.Id > 0);
            Assert.IsNotNull(result.Rewards[0].RewardItem.Name);
            //Assert.AreEqual(result.Rewards[0].RewardItem.Quality, ItemQuality.Heirloom);
            Assert.IsNotNull(result.Rewards[0].RewardItem.TooltipParameters);
            Assert.IsNotNull(result.Rewards[0].Achievement);

            var rw = new GuildReward();
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            rw.ToString();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        public void TestItemCategoryNames()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var result = client.GetItemCategoryNames();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CategoryNames);
            Assert.IsNotNull(result.CategoryNames.Count > 0);
        }

        [TestMethod]
        public void TestQuest()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var quest = client.GetQuest(9962);
            Assert.IsNotNull(quest);
            Assert.IsNotNull(quest.Title);
            Assert.IsNotNull(quest.ToString());
            Assert.IsNotNull(quest.Category);
            Assert.IsTrue(quest.SuggestedPartyMembers > 0);
            Assert.IsTrue(quest.Id > 0);
            Assert.IsTrue(quest.Level > 0);
            Assert.IsTrue(quest.RequiredLevel > 0);
            Assert.IsTrue(quest.Level > 0);
        }

        [TestMethod]
        public void TestRecipe()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var recipe = client.GetRecipe(70556);
            Assert.IsNotNull(recipe);
            Assert.IsNotNull(recipe.Name);
            Assert.IsNotNull(recipe.ToString());
            Assert.IsNotNull(recipe.ProfessionName);
            Assert.IsNotNull(recipe.Icon);
            Assert.IsTrue(recipe.Id > 0);
            Assert.IsTrue(recipe.Id > 0);
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        public void TestClasses()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var result = client.GetClasses();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetClasses();
            Assert.IsTrue(ReferenceEquals(result, result2));

            var cls = result.FirstOrDefault(c => c.Class == ClassKey.Rogue);
            Assert.IsNotNull(cls);
            Assert.IsTrue(cls.Mask > 0);
            Assert.IsNotNull(cls.Name);
            Assert.IsNotNull(cls.PowerTypeName);
            Assert.AreEqual(PowerType.Energy, cls.PowerType);
            Assert.AreEqual(cls.Name, cls.ToString());
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        public void TestRaces()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var result = client.GetRaces();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetRaces();
            Assert.IsTrue(ReferenceEquals(result, result2));

            var race = result.FirstOrDefault(r => r.Race == Race.Tauren);
            Assert.IsTrue(race != null && race.Mask > 0);
            Assert.IsNotNull(race.Name);
            Assert.AreEqual(Faction.Horde, race.Side);
            Assert.IsNotNull(race.SideName);
            Assert.AreEqual(race.Name, race.ToString());
        }

        [TestMethod]
        public void TestRealms()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            client.GetRealmStatus(null);
            Assert.AreEqual(1, client.GetRealmStatus(new[] {TestConstants.TestRealmName}).Realms.Count);
        }

        /// <summary>
        ///   Tests async calls and realm status
        /// </summary>
        [TestMethod]
        public void TestRealmsAsync()
        {
            bool testResult = false;
            var client = new WowClient(TestConstants.TestRegionName, null, null, null);
            var asyncState = new object();
            IAsyncResult result = client.BeginGetRealmStatus(
                o => { testResult = o.AsyncState == asyncState; }, asyncState
                );
            RealmStatusResponse response = client.EndGetRealmStatus(result);
            Assert.IsTrue(testResult);
            Assert.IsNotNull(response);
            Assert.IsTrue(new RealmStatusResponse().ToString().Contains('0'));
            Assert.IsNotNull(response.ToString());
            Assert.IsNotNull(response.Realms);
            Assert.IsTrue(response.Realms.Count > 0);
            Assert.IsTrue(response.Realms.Any(r => r.IsPvp));
            Assert.IsTrue(response.Realms.Any(r => r.IsRP));
            Assert.IsTrue(response.Realms.All(r => r.Locale != null));
            Assert.IsTrue(response.Realms.All(r => r.Name != null));
// ReSharper disable ConditionIsAlwaysTrueOrFalse
            Assert.IsTrue(!response.Realms.Any(r => r.ToString() == null));
// ReSharper restore ConditionIsAlwaysTrueOrFalse
            Assert.IsTrue(!response.Realms.Any(r => r.PopulationName == null && r.Queue));
            Assert.IsTrue(response.Realms.All(r => r.Slug != null));
            Assert.IsTrue(response.Realms.All(r => r.BattleGroupName != null));
            Assert.IsTrue(response.Realms.Any(r => r.Status));
            Assert.IsTrue(response.Realms.All(r => r.TimeZone != null));
            Assert.IsTrue(response.Realms.All(r => r.TypeName != null));
            Assert.IsTrue(response.Realms.Any(r => r.WinterGrasp != null));

            var tolBarad = response.Realms.Where(r => r.TolBarad != null
                                                      && r.Status).Select(r => r.TolBarad).FirstOrDefault();
            Assert.IsNotNull(tolBarad);
            Assert.IsTrue(tolBarad.AreaId > 0);
            Assert.IsTrue(tolBarad.ControllingFaction != Faction.Neutral);
            Assert.IsTrue(tolBarad.NextBattleTimeUtc.Year == DateTime.Now.Year);
            Assert.IsTrue(tolBarad.NextBattleTimestamp > 0);
            Assert.IsTrue(tolBarad.Status != PvpZoneStatus.Unknown);
        }

        /// <summary>
        ///   Tests get guild
        /// </summary>
        [TestMethod]
        public void TestGuild()
        {
            var client = new WowClient(TestConstants.TestRegionName, TestConstants.Credentials, null, null);
            var guild = client.GetGuild(TestConstants.TestRealmName, TestConstants.TestGuildName, true);
            Assert.IsNotNull(guild);
            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);
            Assert.IsTrue(guild.Members.Count > 0);
            Assert.IsTrue(guild.Members.Any(m => m.Rank > 0));
            Assert.IsTrue(string.Equals(guild.Members[0].Character.Realm, TestConstants.TestRealmName,
                                        StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(guild.Name, TestConstants.TestGuildName, StringComparison.OrdinalIgnoreCase));
            Assert.IsNotNull(guild.ToString());
            Assert.IsNotNull(guild.SideName);
            Assert.IsNotNull(guild.Members[0].ToString());
            Assert.IsTrue(guild.AchievementPoints > 0);
            Assert.IsNotNull(guild.BattleGroupName);
            Assert.IsNotNull(guild.Emblem);
            Assert.IsNotNull(guild.Emblem.BackgroundColor);
            Assert.IsNotNull(guild.Emblem.BorderColor);
            Assert.IsNotNull(guild.Emblem.IconColor);
            Assert.IsTrue(guild.Emblem.Icon > 0);
            Assert.IsTrue(guild.Emblem.Border >= 0);
            Assert.IsTrue(guild.Level >= 25);
            Assert.AreEqual(TestConstants.TestRealmName, guild.Realm);

            Assert.IsNotNull(guild.News);
            Assert.IsTrue(guild.News.All(n => n != null));
            Assert.IsTrue(guild.News.All(n => n.Achievement != null
                                              ||
                                              (n.GuildNewsItemType != GuildNewsItemType.PlayerAchievement &&
                                               n.GuildNewsItemType != GuildNewsItemType.GuildAchievement)));
            Assert.IsTrue(guild.News.All(n => n.ItemId > 0
                                              ||
                                              (n.GuildNewsItemType == GuildNewsItemType.PlayerAchievement ||
                                               n.GuildNewsItemType == GuildNewsItemType.GuildAchievement)));

            Assert.IsNotNull(guild.Challenges);
            Assert.AreNotEqual(0, guild.Challenges.Count);
        }

        /// <summary>
        ///   Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacter()
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
            //Assert.IsNotNull(character.HunterPets);
            Assert.IsNotNull(character.Feed);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Progression);
            Assert.IsTrue(character.Class == ClassKey.Druid);
            Assert.IsTrue(character.Level >= 85);

            Assert.IsTrue(string.Equals(character.Realm, TestConstants.TestRealmName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(character.Name, TestConstants.TestCharacterName,
                                        StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(character.LastModifiedValue > 0);

            Assert.IsNotNull(character.Thumbnail);
        }

        [TestMethod]
        public void TestAchievements()
        {
            var client = new WowClient("US", TestConstants.Credentials, "en-us", null);
            Assert.IsNotNull(client.GetGuildAchievements());
            var achievements = client.GetCharacterAchievements();
            Assert.IsNotNull(achievements.Categories);
            Assert.AreEqual(achievements.Categories[0].Name, achievements.Categories[0].ToString());
            var generalCategory = achievements.Categories.FirstOrDefault(c => c.Name == "General");
            Assert.IsNotNull(generalCategory);
            Assert.IsNotNull(generalCategory.Achievements);
            var higherlearning = generalCategory.Achievements.FirstOrDefault(a => a.Title == "Higher Learning");
            Assert.IsNotNull(higherlearning);
            Assert.IsTrue(higherlearning.Id > 0);
            Assert.AreEqual(higherlearning.Title, higherlearning.ToString());
            Assert.IsNotNull(higherlearning.Criteria);
            var criterion = higherlearning.Criteria[5];
            Assert.IsNotNull(criterion.Description);
            Assert.IsTrue(criterion.Id > 0);
            Assert.IsTrue(criterion.OrderIndex > 0);
            Assert.IsTrue(criterion.Max > 0);
            Assert.AreEqual(false, higherlearning.AccountWide);
            Assert.IsNotNull(higherlearning.Description);
            Assert.AreEqual(10, higherlearning.Points);
            Assert.IsNotNull(higherlearning.Reward);
            Assert.IsNotNull(higherlearning.RewardItems);
            Assert.IsTrue(higherlearning.RewardItems.Count > 0);
            var armoredBrownBear = generalCategory.Achievements.FirstOrDefault(a => a.Title == "Armored Brown Bear");
            Assert.IsNotNull(armoredBrownBear);
            Assert.AreEqual(true, armoredBrownBear.AccountWide);

            var questCategory = achievements.Categories.FirstOrDefault(c => c.Name == "Quests");
            Assert.IsTrue(questCategory != null && questCategory.Id > 0);
            Assert.IsNotNull(questCategory.Categories);
            Assert.IsTrue(questCategory.Categories.Count > 0);
        }

        /// <summary>
        ///   Tests get slug method
        /// </summary>
        [TestMethod]
        public void TestSlugs()
        {
            foreach (var region in Region.AllRegions)
            {
                var client = new WowClient(region);
                var allRealms = client.GetRealmStatus();
                foreach (var realm in allRealms.Realms)
                {
                    Assert.AreEqual(realm.Slug, WowClient.GetRealmSlug(realm.Name));
                }
                var allBattlegroups = client.GetBattleGroups();
                foreach (var battleGroup in allBattlegroups.BattleGroups)
                {
                    Assert.AreEqual(battleGroup.Slug, WowClient.GetBattleGroupSlug(battleGroup.Name));
                }
            }
        }

        /// <summary>
        ///   Test get spell
        /// </summary>
        [TestMethod]
        public void TestSpell()
        {
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
            var spell = client.GetSpell(8056);
            Assert.IsNotNull(spell);
            Assert.IsNotNull(spell.Name);
        }

        /// <summary>
        ///   Test get talents info
        /// </summary>
        [TestMethod]
        public void TestAllTalents()
        {
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
            var talents = client.GetTalents();
            Assert.IsNotNull(talents);
            Assert.IsNotNull(talents.Warrior);
            Assert.IsNotNull(talents.Warlock);
            Assert.IsNotNull(talents.Shaman);
            Assert.IsNotNull(talents.Rogue);
            Assert.IsNotNull(talents.Priest);
            Assert.IsNotNull(talents.Paladin);
            Assert.IsNotNull(talents.Monk);
            Assert.IsNotNull(talents.Mage);
            Assert.IsNotNull(talents.Hunter);
            Assert.IsNotNull(talents.Druid);
            Assert.IsNotNull(talents.DeathKnight);
        }
    }
}