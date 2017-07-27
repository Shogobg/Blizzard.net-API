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
            WOWSharp.Community.ApiClient.TestMode = true;
            
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
				var profile = await client.GetProfileAsync("Shogo#2690");

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
            await client.RefreshAsync();

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