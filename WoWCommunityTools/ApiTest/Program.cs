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

using System.Linq;
using WOWSharp.Community;
using System.Configuration;
using System.IO;
using WOWSharp.Community.Wow;

namespace ApiTest
{
	/// <summary>
	/// Sample console application to for API usage
	/// </summary>
	class Program
    {
        /// <summary>
        /// Main entry point for the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string privateKey = ConfigurationManager.AppSettings["PrivateKey"];
            string publicKey = ConfigurationManager.AppSettings["PublicKey"];

            var client = new WowClient(Region.US, "", "pt", null);

            var rewards = client.GetGuildRewardsAsync().Result;

            var perks = client.GetGuildPerksAsync().Result;

            var realms = client.GetRealmStatusAsync().Result;

            var classes = client.GetClassesAsync().Result;

            var itemCategories = client.GetItemCategoryNamesAsync().Result;

            var races = client.GetRacesAsync().Result;

            var characterAchievements = client.GetCharacterAchievementsAsync().Result;

            var guildAchievements = client.GetGuildAchievementsAsync().Result;

            var quest = client.GetQuestAsync(23).Result;
			
            var character = client.GetCharacterAsync("doomhammer", "grendizer", CharacterFields.All).Result;
			
            using (FileStream fs = new FileStream("emblem.png", FileMode.Create))
            {
                character.SaveGuildTabardImage(fs, 240, 240);
            }
            character.RefreshAsync(client);
            
            var guild = client.GetGuildAsync(character.Realm, character.Guild.Name, GuildFields.All);
            
            var items = character.Items.AllItems.Select(
                equippedItem => client.GetItemAsync(equippedItem.ItemId).Result).ToArray();
            var gems = character.Items.AllItems.Where(ei => ei.Parameters != null)
                .SelectMany(ei => new int?[] { ei.Parameters.Gem0, ei.Parameters.Gem1, ei.Parameters.Gem2, ei.Parameters.Gem3 })
                .Where(gemid => gemid != null)
                .Distinct().Select(gemid => client.GetItemAsync(gemid.Value).Result).ToArray();

            var auctions = client.GetAuctionDump(character.Realm);
        }
    }
}
