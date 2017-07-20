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
using WOWSharp.Community.ObjectModel;
using System.Net;
using System.Collections.ObjectModel;
using System.Web;
using System.Globalization;
using System.Threading;

namespace WOWSharp.Community
{
    /// <summary>
    /// A Blizzard's WOW community API client
    /// </summary>
    // This partial file contains the synchronous methods that and properties that are not available in Silver Light
    public partial class ApiClient
    {
        /// <summary>
        /// Get the realm status for all the realms in the region
        /// </summary>
        /// <returns>the realm status for all the realms in the region</returns>
        public RealmStatusResponse GetRealmStatus()
        {
            IAsyncResult result = BeginGetRealmStatus(null, null);
            return this.EndGetRealmStatus(result);
        }

        /// <summary>
        /// Get the realm status for specified realms in the region
        /// </summary>
        /// <param name="realms">Realms to query</param>
        /// <returns>the realm status for all the realms in the region</returns>
        /// <remarks>If invalid realms passed are not returned in the response but no error is thrown.</remarks>
        public RealmStatusResponse GetRealmStatus(params string[] realms)
        {
            IAsyncResult result = BeginGetRealmStatus(realms, null, null);
            return this.EndGetRealmStatus(result);
        }

        /// <summary>
        /// Get character profile information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <returns>character profile information</returns>
        /// <remarks>Only basic character information is returned</remarks>
        public Character GetCharacter(string realm, string characterName)
        {
            return GetCharacter(realm, characterName, CharacterField.None);
        }

        /// <summary>
        /// Get character profile information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <param name="getAllFields">If true all character information is returned, otherwise only basic information is returned</param>
        /// <returns>character profile information</returns>
        /// <remarks>Only basic character information is returned</remarks>
        public Character GetCharacter(string realm, string characterName, bool getAllFields)
        {
            return GetCharacter(realm, characterName, getAllFields ? CharacterField.All : CharacterField.None);
        }

        /// <summary>
        /// Get character profile information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="characterName">character name</param>
        /// <param name="fieldsToRetrieve">The profile fields to retrieve</param>
        /// <returns>character profile information</returns>
        public Character GetCharacter(string realm, string characterName, CharacterField fieldsToRetrieve)
        {
            IAsyncResult result = BeginGetCharacter(realm, characterName, fieldsToRetrieve, null, null);
            return this.EndGetCharacter(result);
        }

        /// <summary>
        /// Gets guild information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <returns>guild information</returns>
        /// <remarks>Only basic guild information is returned</remarks>
        public Guild GetGuild(string realm, string guildName)
        {
            return GetGuild(realm, guildName, GuildField.None);
        }

        /// <summary>
        /// Gets guild information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <param name="getAllFields">if true, all fields are returned, otherwise only basic information is returned</param>
        /// <returns>guild information</returns>
        /// <remarks>returns guild information</remarks>
        public Guild GetGuild(string realm, string guildName, bool getAllFields)
        {
            return GetGuild(realm, guildName, getAllFields ? GuildField.All : GuildField.None);
        }

        /// <summary>
        /// Gets guild information
        /// </summary>
        /// <param name="realm">realm name</param>
        /// <param name="guildName">guild name</param>
        /// <param name="fieldsToRetrieve">the guild fields to retrieve</param>
        /// <returns>guild information</returns>
        public Guild GetGuild(string realm, string guildName, GuildField fieldsToRetrieve)
        {
            IAsyncResult result = BeginGetGuild(realm, guildName, fieldsToRetrieve, null, null);
            return this.EndGetGuild(result);
        }

        /// <summary>
        /// Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm">realm to get auction house data for</param>
        /// <returns>The auction house dump for the specified realm</returns>
        public AuctionDump GetAuctionDump(string realm)
        {
            IAsyncResult result = BeginGetAuctionDump(realm, null, null);
            return this.EndGetAuctionDump(result);
        }

        /// <summary>
        /// Gets the most recent auction house dump
        /// </summary>
        /// <param name="realm">realm to get auction house data for</param>
        /// <param name="ifModifiedSince">The datetime of the lastModified header of the last auction dump.</param>
        /// <returns>The auction house dump for the specified realm</returns>
        public AuctionDump GetAuctionDump(string realm, DateTime ifModifiedSince)
        {
            IAsyncResult result = BeginGetAuctionDump(realm, ifModifiedSince, null, null);
            return this.EndGetAuctionDump(result);
        }

        /// <summary>
        /// Gets an item's information
        /// </summary>
        /// <param name="itemId">the id of the item to fetch data for</param>
        /// <returns>The item information request</returns>
        public Item GetItem(int itemId)
        {
            IAsyncResult result = BeginGetItem(itemId, null, null);
            return EndGetItem(result);
        }

        /// <summary>
        /// Gets information about character classes
        /// </summary>
        /// <returns>information about character classes</returns>
        public IList<CharacterClass> GetClasses()
        {
            IAsyncResult result = BeginGetClasses(null, null);
            return EndGetClasses(result);
        }

        /// <summary>
        /// Gets information about character races
        /// </summary>
        /// <returns>information about character classes</returns>
        public IList<CharacterRace> GetRaces()
        {
            IAsyncResult result = BeginGetRaces(null, null);
            return EndGetRaces(result);
        }

        /// <summary>
        /// gets an arena team
        /// </summary>
        /// <param name="realm">Team's realm</param>
        /// <param name="name">Team name</param>
        /// <param name="teamSize">Team size</param>
        /// <returns>the requested arena team</returns>
        public ArenaTeam GetArenaTeam(string realm, string name, int teamSize)
        {
            IAsyncResult result = BeginGetArenaTeam(realm, name, teamSize, null, null);
            return this.EndGetArenaTeam(result);
        }

        /// <summary>
        /// gets all guild rewards
        /// </summary>
        /// <returns>All guild rewards</returns>
        public GuildRewardsResponse GetGuildRewards()
        {
            IAsyncResult result = BeginGetGuildRewards(null, null);
            return this.EndGetGuildRewards(result);
        }

        /// <summary>
        /// gets all guild perks
        /// </summary>
        /// <returns>All guild perks</returns>
        public GuildPerksResponse GetGuildPerks()
        {
            IAsyncResult result = BeginGetGuildPerks(null, null);
            return this.EndGetGuildPerks(result);
        }

        /// <summary>
        /// gets all item category names
        /// </summary>
        /// <returns>All item category names</returns>
        public ItemCategoryNamesResponse GetItemCategoryNames()
        {
            IAsyncResult result = BeginGetItemCategoryNames(null, null);
            return this.EndGetItemCategoryNames(result);
        }

        /// <summary>
        /// gets all character achievements
        /// </summary>
        /// <returns>All character achievements</returns>
        public AchievementsResponse GetCharacterAchievements()
        {
            IAsyncResult result = BeginGetCharacterAchievements(null, null);
            return this.EndGetCharacterAchievements(result);
        }

        /// <summary>
        /// gets all guild achievements
        /// </summary>
        /// <returns>All guild achievements</returns>
        public AchievementsResponse GetGuildAchievements()
        {
            IAsyncResult result = BeginGetGuildAchievements(null, null);
            return this.EndGetGuildAchievements(result);
        }

        /// <summary>
        /// gets a quest's information
        /// </summary>
        /// <param name="questId">the quest id</param>
        /// <returns>The quest information</returns>
        public Quest GetQuest(int questId)
        {
            IAsyncResult result = BeginGetQuest(questId, null, null);
            return this.EndGetQuest(result);
        }

        /// <summary>
        /// Gets the top ranked arena teams from a battle group in a specified bracket
        /// </summary>
        /// <param name="battlegroupName">battlegroup name</param>
        /// <param name="teamSize">team size</param>
        /// <param name="numberOfTeamsToGet">Number of teams to get</param>
        /// <returns>the arena teams</returns>
        public ArenaTeamsResponse GetBattlegroupArenaTeams(string battlegroupName, int teamSize, int numberOfTeamsToGet)
        {
            IAsyncResult result = BeginGetBattlegroupArenaTeams(battlegroupName, teamSize, numberOfTeamsToGet, null, null);
            return this.EndGetBattlegroupArenaTeams(result);
        }

        /// <summary>
        /// Get Recipe information
        /// </summary>
        /// <param name="recipeId">the id of the recipe to get</param>
        /// <returns>Recipe information</returns>
        public RecipeInfo GetRecipe(int recipeId)
        {
            IAsyncResult result = BeginGetRecipe(recipeId, null, null);
            return this.EndGetRecipe(result);
        }

    }
}
