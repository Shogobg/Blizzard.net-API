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

using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WOWSharp.Community;
using WOWSharp.Community.Diablo;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.TestConsole
{
	internal static class Program
    {
        /// <summary>
        ///   Main entry point for the application
        /// </summary>
        private static void Main()
        {
            WOWSharp.Community.ApiClient.TestMode = false;
            
            //TestWowClientAsync().Wait();
            TestDiabloClientAsync().Wait();
        }

        /// <summary>
        /// Test accessing diablo asynchronously
        /// </summary>
        /// <returns>Task</returns>
        private async static Task TestDiabloClientAsync()
        {
			try {
				string apiKey = ConfigurationManager.AppSettings["apiKey"];

				// Init client
				var client = new DiabloClient(Region.EU, "en-gb", apiKey);

				// Get profile
				var profile = await client.GetProfileAsync("Grendizer#2508");

				// Get Hero
				var hero = await client.GetHeroAsync(profile.BattleTag, profile.Heroes[0].Id);

				// Get item
				var item = await client.GetItemAsync(hero.Items.Head.TooltipParameters);

				// Get blacksmith info
				var blackSmith = await client.GetArtisanInfoAsync(ArtisanType.Blacksmith);

				// Get scoundrel info
				var scoundrel = await client.GetFollowerInfoAsync(FollowerType.Scoundrel);
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}

        /// <summary>
        /// Gets accessing WOW API Asynchronously
        /// </summary>
        /// <returns></returns>
        private async static Task TestWowClientAsync()
        {
			var apiKey = "";

			// Init client
			var client = new WowClient(Region.EU, "en-gb", apiKey, null);
            
            // Character
            var character = await client.GetCharacterAsync("kazzak", "Grendiser", CharacterFields.All);
            // Refresh character info
            await character.RefreshAsync(client);

            // Gee pet types
            var petTypes = await client.GetBattlePetTypesAsync();

            // Get challenge leaders
            var kazzakChallengeLeaders = await client.GetChallengeLeadersAsync("kazzak");
            var euChallengeLeaders = await client.GetChallengeLeadersAsync(null);

            // Get battle groups
            var bgs = await client.GetBattleGroupsAsync();

            // Get rewards
            var rewards = await client.GetGuildRewardsAsync();

            // Get perks
            var perks = await client.GetGuildPerksAsync();

            // Get realms
            var realms = await client.GetRealmStatusAsync();

            // Get classes
            var classes = await client.GetClassesAsync();

            // Get item categories
            var itemCategories = await client.GetItemCategoryNamesAsync();

            // Get races
            var races = await client.GetRacesAsync();

            // Get character achievements
            var characterAchievements = await client.GetCharacterAchievementsAsync();

            // Get guild achievements
            var guildAchievements = await client.GetGuildAchievementsAsync();

            // Get quest
            var quest = await client.GetQuestAsync(23);

            // Get talents
            var talents = await client.GetTalentsAsync();

            // Get PVP information
            var topArenaPlayers = await client.GetPvpLeaderboardAsync(PvpBracket.Arena5v5);
            var topBgPlayers = await client.GetPvpLeaderboardAsync(PvpBracket.RatedBattleground);
            
            // Get item set
            var itemSet = await client.GetItemSetAsync(1058);

            // Get ability
            var ability = await client.GetBattlePetAbilityAsync(640);
            var petSpecies = await client.GetBattlePetSpeciesAsync(258);

            // Get guild
            var guild = await client.GetGuildAsync(character.Realm, character.Guild.Name, GuildFields.All);

            // Get items
            var itemsTasks = character.Items.AllItems.Select(
                equippedItem => client.GetItemAsync(equippedItem.ItemId)).ToArray();
            var allItemsTask = new Task<WOWSharp.Community.Wow.Item[]>(() =>
            {
                Task.WaitAll(itemsTasks);
                return itemsTasks.Select(t => t.Result).ToArray();
            });
            allItemsTask.Start();
            var items = await allItemsTask;

            var gems = character.Items.AllItems.Where(ei => ei.Parameters != null)
                .SelectMany(ei => new[] { ei.Parameters.Gem0, ei.Parameters.Gem1, ei.Parameters.Gem2, ei.Parameters.Gem3 })
                .Where(gemid => gemid != null)
                .Distinct();

            // Get AH dump
            var auctions = await client.GetAuctionDumpAsync(character.Realm);
        }
    }
}