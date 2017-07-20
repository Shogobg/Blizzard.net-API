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
using WOWSharp.Community;
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
            string privateKey = ConfigurationManager.AppSettings["PrivateKey"];
            string publicKey = ConfigurationManager.AppSettings["PublicKey"];
            var pair = new ApiKeyPair(publicKey, privateKey);

            var client = new WowClient(Region.EU, pair, "en-gb", null);
            var dump = client.GetAuctionDump("Argent Dawn");
            
            var character = client.GetCharacter("kazzak", "Grendiser", true);
            character.Refresh();

            var petTypes = client.GetBattlePetTypes();

            var kazzakChallengeLeaders = client.GetChallengeLeaders("kazzak");

            var euChallengeLeaders = client.GetChallengeLeaders(null);

            var bgs = client.GetBattleGroups();

            var rewards = client.GetGuildRewards();

            var perks = client.GetGuildPerks();

            var realms = client.GetRealmStatus();

            var classes = client.GetClasses();

            var itemCategories = client.GetItemCategoryNames();

            var races = client.GetRaces();

            var characterAchievements = client.GetCharacterAchievements();

            var guildAchievements = client.GetGuildAchievements();

            var quest = client.GetQuest(23);

            var talents = client.GetTalents();

            var topArenaPlayers = client.GetPvpLeaderboard(PvpBracket.Arena5v5);
            var topBgPlayers = client.GetPvpLeaderboard(PvpBracket.RatedBattleground);
            var itemSet = client.GetItemSet(1058);



            var ability = client.GetBattlePetAbility(640);
            var petSpecies = client.GetBattlePetSpecies(258);

            var guild = client.GetGuild(character.Realm, character.Guild.Name, true);

            var items = character.Items.AllItems.Select(
                equippedItem => client.GetItem(equippedItem.ItemId)).ToArray();
            var gems = character.Items.AllItems.Where(ei => ei.Parameters != null)
                .SelectMany(ei => new[] { ei.Parameters.Gem0, ei.Parameters.Gem1, ei.Parameters.Gem2, ei.Parameters.Gem3 })
                .Where(gemid => gemid != null)
                .Distinct();

            var auctions = client.GetAuctionDump(character.Realm);
        }
    }
}