
using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;
using Newtonsoft.Json;
using System.IO;

namespace WOWSharp.UnitTests
{
    /// <summary>
    /// Client tests
    /// </summary>
    [TestClass]
    public class WowClientTests
    {
        /// <summary>
        /// Set test mode
        /// </summary>
        [TestInitialize]
        public void SetTestMode()
        {
            ApiClient.TestMode = true;
        }

        /// <summary>
        ///   Test auctions API
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestAuctions()
        {
            var client = new WowClient(TestConstants.TestRegionName,
                                       "", null, null);
            //var result = client.GetAuctionDump(TestConstants.TestRealmName);
            var result = client.GetAuctionDumpAsync(TestConstants.TestAuctionHouseRealm).Result;

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
        }

        /// <summary>
        ///   Test auctions API
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ApiException))]
        [TestCategory("WOW")]
        public void TestApiException()
        {
            try
            {
                var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
                var result = client.GetAuctionDumpAsync(TestConstants.TestRealmName + TestConstants.TestRealmName).Result; // invalid realm name
            }
            catch (AggregateException ex)
            {
                Assert.AreEqual(1, ex.InnerExceptions.Count);
                Assert.IsNotNull(ex.InnerExceptions[0]);
                throw ex.InnerExceptions[0];
            }
            // should get realm not found
        }

        /// <summary>
        ///   Test get Item
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestItems()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var result = client.GetItemAsync(17182).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ItemQuality == ItemQuality.Legendary);
            Assert.AreEqual(17182, result.Id);
            result = client.GetItemAsync(86879).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsUpgradable);
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestPerks()
        {
            var client = new WowClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetGuildPerksAsync().Result;
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
        [TestCategory("WOW")]
        public void TestRewards()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var result = client.GetGuildRewardsAsync().Result;
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
        [TestCategory("WOW")]
        public void TestItemCategoryNames()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var result = client.GetItemCategoryNamesAsync().Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CategoryNames);
            Assert.IsNotNull(result.CategoryNames.Count > 0);
        }

        /// <summary>
        /// quest api
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestQuest()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var quest = client.GetQuestAsync(9962).Result;
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

        /// <summary>
        /// Test recipe
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestRecipe()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var recipe = client.GetRecipeAsync(70556).Result;
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
        [TestCategory("WOW")]
        public void TestClasses()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var result = client.GetClassesAsync().Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetClassesAsync().Result;
            Assert.IsTrue(ReferenceEquals(result, result2));

            var cls = result.FirstOrDefault(c => c.Class == ClassKey.Rogue);
            Assert.IsNotNull(cls);
            Assert.IsTrue(cls.Mask > 0);
            Assert.IsNotNull(cls.Name);
            Assert.AreEqual(PowerType.Energy, cls.PowerType);
            Assert.AreEqual(cls.Name, cls.ToString());
        }

        /// <summary>
        ///   Test data API
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestRaces()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var result = client.GetRacesAsync().Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetRacesAsync().Result;
            Assert.IsTrue(ReferenceEquals(result, result2));

            var race = result.FirstOrDefault(r => r.Race == Race.Tauren);
            Assert.IsTrue(race != null && race.Mask > 0);
            Assert.IsNotNull(race.Name);
            Assert.AreEqual(Faction.Horde, race.Faction);
            Assert.AreEqual(race.Name, race.ToString());
        }

        [TestMethod]
        [TestCategory("WOW")]
        public void TestRealms()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var realms = client.GetRealmStatusAsync(null).Result;
            realms = client.GetRealmStatusAsync(new[] { TestConstants.TestRealmName }).Result;
            Assert.AreEqual(1, realms.Realms.Count);
        }

        /// <summary>
        ///   Tests async calls and realm status
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestRealmsAsync()
        {
            var client = new WowClient(TestConstants.TestRegionName, null, null, null);
            var task = client.GetRealmStatusAsync();
            RealmStatusResponse response = task.Result;
            Assert.IsNotNull(response);
            Assert.IsTrue(new RealmStatusResponse().ToString().Contains('0'));
            Assert.IsNotNull(response.ToString());
            Assert.IsNotNull(response.Realms);
            Assert.IsTrue(response.Realms.Count > 0);
            Assert.IsTrue(response.Realms.Any(r => r.IsPvp));
            Assert.IsTrue(response.Realms.Any(r => r.IsRP));
            Assert.IsTrue(response.Realms.All(r => r.Locale != null));
            Assert.IsTrue(response.Realms.All(r => r.Name != null));
            Assert.IsTrue(!response.Realms.Any(r => r.ToString() == null));
            Assert.IsTrue(response.Realms.All(r => r.Slug != null));
            Assert.IsTrue(response.Realms.All(r => r.BattleGroupName != null));
            Assert.IsTrue(response.Realms.Any(r => r.Status));
            Assert.IsTrue(response.Realms.All(r => r.TimeZone != null));
            Assert.IsTrue(response.Realms.Any(r => r.WinterGrasp != null));

            var tolBarad = response.Realms.Where(r => r.TolBarad != null
                                                      && r.Status).Select(r => r.TolBarad).FirstOrDefault();
            Assert.IsNotNull(tolBarad);
            Assert.IsTrue(tolBarad.AreaId > 0);
            Assert.IsTrue(tolBarad.ControllingFaction != Faction.Neutral);
            Assert.IsTrue(tolBarad.NextBattleTimeUtc.Year == DateTime.Now.Year);
            Assert.IsTrue(tolBarad.Status != PvpZoneStatus.Unknown);
        }

        /// <summary>
        ///   Tests get guild
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestGuild()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var guild = client.GetGuildAsync(TestConstants.TestRealmName, TestConstants.TestGuildName, GuildFields.All).Result;
            Assert.IsNotNull(guild);
            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);
            Assert.IsTrue(guild.Members.Count > 0);
            Assert.IsTrue(guild.Members.Any(m => m.Rank > 0));
            Assert.IsTrue(string.Equals(guild.Members[0].Character.Realm, TestConstants.TestRealmName,
                                        StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(guild.Name, TestConstants.TestGuildName, StringComparison.OrdinalIgnoreCase));
            Assert.IsNotNull(guild.ToString());
            Assert.IsNotNull(guild.Faction);
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
        [TestCategory("WOW")]
        public void TestCharacter()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.All).Result;
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
            
            Assert.IsNotNull(character.Thumbnail);
        }

        /// <summary>
        /// Test achievements
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestAchievements()
        {
            var client = new WowClient("US", "en-us", TestConstants.apiKey, null);
            Assert.IsNotNull(client.GetGuildAchievementsAsync().Result);
            var achievements = client.GetCharacterAchievementsAsync().Result;
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
        [TestCategory("WOW")]
        public void TestSlugs()
        {
            foreach (var region in Region.AllRegions)
            {
                var client = new WowClient(region);
                var allRealms = client.GetRealmStatusAsync().Result;
                foreach (var realm in allRealms.Realms)
                {
                    Assert.AreEqual(realm.Slug, WowClient.GetRealmSlug(realm.Name));
                }
                var allBattlegroups = client.GetBattleGroupsAsync().Result;
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
        [TestCategory("WOW")]
        public void TestSpell()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var spell = client.GetSpellAsync(8056).Result;
            Assert.IsNotNull(spell);
            Assert.IsNotNull(spell.Name);
        }

        /// <summary>
        ///   Test get talents info
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestAllTalents()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var talents = client.GetTalentsAsync().Result;
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

        /// <summary>
        /// Test achievements
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestSerializationRoundTrip()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Achievements).Result;
            JsonSerializer serializer = new JsonSerializer();
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, character);
                using (var reader = new StringReader(writer.ToString()))
                {
                    var jsonReader = new JsonTextReader(reader);
                    var character2 = serializer.Deserialize<Character>(jsonReader);

                    Assert.AreEqual(character.Name, character2.Name);
                    Assert.AreEqual(character.Class, character2.Class);
                    Assert.AreEqual(character.Achievements.AchievementsCompleted.Count, character2.Achievements.AchievementsCompleted.Count);
                    Assert.AreEqual(character.Achievements.AchievementsCompletedDatesUtc.Count, character2.Achievements.AchievementsCompletedDatesUtc.Count);
                    Assert.AreEqual(character.Achievements.AchievementsCompleted[0], character2.Achievements.AchievementsCompleted[0]);
                }
            }
        }
    }
}