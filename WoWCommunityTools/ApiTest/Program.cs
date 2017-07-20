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
using WOWSharp.Community;
using WOWSharp.Community.ObjectModel;
using System.Net;
using System.Configuration;
using System.IO;
using System.Reflection;

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

            ApiClient client = new ApiClient(Region.US, new ApiKeyPair(publicKey, privateKey), "pt", null);

            var rewards = client.GetGuildRewards();

            var perks = client.GetGuildPerks();

            var realms = client.GetRealmStatus();

            var classes = client.GetClasses();

            var itemCategories = client.GetItemCategoryNames();

            var races = client.GetRaces();

            var characterAchievements = client.GetCharacterAchievements();

            var guildAchievements = client.GetGuildAchievements();

            var quest = client.GetQuest(23);

            var topArena50Teams = client.GetBattlegroupArenaTeams("blackout", 3, 50);

            var character = client.GetCharacter("doomhammer", "grendizer", true);
            var characterCompletedAchievements =
                characterAchievements.Categories.Select((c) => GetCharacterAchievements(character, c));
            using (FileStream fs = new FileStream("emblem.png", FileMode.Create))
            {
                character.SaveGuildTabardImage(fs, 240, 240);
            }
            character.Refresh();
            
            var guild = client.GetGuild(character.Realm, character.Guild.Name, true);
            
            var items = character.Items.AllItems.Select(
                equippedItem => client.GetItem(equippedItem.ItemId)).ToArray();
            var gems = character.Items.AllItems.Where(ei => ei.Parameters != null)
                .SelectMany(ei => new int?[] { ei.Parameters.Gem0, ei.Parameters.Gem1, ei.Parameters.Gem2, ei.Parameters.Gem3 })
                .Where(gemid => gemid != null)
                .Distinct().Select(gemid => client.GetItem(gemid.Value)).ToArray();

            var auctions = client.GetAuctionDump(character.Realm);
        }

        private static AchievementCategory GetCharacterAchievements(Character character, AchievementCategory category)
        {
            return new AchievementCategory()
            {
                Achievements = category.Achievements.Where((ach) => character.Achievements.AchievementsCompleted.Contains(ach.Id)).ToArray(),
                Categories = category.Categories == null ? null : category.Categories.Select((c) => GetCharacterAchievements(character, c)).ToArray(),
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
