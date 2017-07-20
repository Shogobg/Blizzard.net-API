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
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
{
    /// <summary>
    ///   Tests PvP related APIs
    /// </summary>
    [TestClass]
    public class PvpTests
    {
        [TestMethod]
        public void TestPvPLeaderboard()
        {
            TestPvPLeaderboard(PvpBracket.Arena2v2);
            TestPvPLeaderboard(PvpBracket.Arena3v3);
            TestPvPLeaderboard(PvpBracket.Arena5v5);
            TestPvPLeaderboard(PvpBracket.RatedBattleground);
        }

        private void TestPvPLeaderboard(PvpBracket bracket)
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var response = client.GetPvpLeaderboard(bracket);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Leaderboard);
            Assert.IsNotNull(response.ToString());
            Assert.IsNotNull(new PvpLeaderboardResponse().ToString());
            Assert.IsTrue(response.Leaderboard.Count > 0);

            var first = response.Leaderboard[0];
            Assert.IsNotNull(first.ToString());
            Assert.IsNotNull(first.Name);
            Assert.IsTrue(first.Rating > 0);
            Assert.IsNotNull(first.Name);
            Assert.IsTrue(first.Ranking > 0);
            Assert.IsNotNull(first.RealmName);
            Assert.IsNotNull(first.RealmSlug);

            CharacterPvpBracketInformation info;
            var chr = client.GetCharacter(first.RealmName, first.Name, CharacterFields.Pvp);
            Assert.IsNotNull(chr.Pvp);
            Assert.IsNotNull(chr.Pvp.Brackets);
            
            
            switch (bracket)
            {
                case PvpBracket.Arena2v2:
                    info = chr.Pvp.Brackets.Arena2v2;
                    break;
                case PvpBracket.Arena3v3:
                    info = chr.Pvp.Brackets.Arena3v3;
                    break;
                case PvpBracket.Arena5v5:
                    info = chr.Pvp.Brackets.Arena5v5;
                    break;
                case PvpBracket.RatedBattleground:
                    info = chr.Pvp.Brackets.RatedBattleground;
                    break;
                default:
                    info = null;
                    break;
            }

            Assert.IsNotNull(info);
            Assert.AreEqual(info.Rating, first.Rating);
            Assert.AreEqual(info.SeasonWins, first.SeasonWins);
            Assert.AreEqual(info.SeasonLosses, first.SeasonLosses);
            Assert.AreEqual(info.WeeklyLosses, first.WeeklyLosses);
            Assert.AreEqual(info.WeeklyWins, first.WeeklyWins);
            
            Assert.AreEqual(info.WeeklyLosses + info.WeeklyWins, info.WeeklyPlayed);
            Assert.AreEqual(info.SeasonLosses + info.SeasonWins, info.SeasonPlayed);

            Assert.AreEqual(bracket, info.PvpBracket);
            Assert.AreEqual(1, first.Ranking);
        }

//        [TestMethod]
//        public void TestArenaLadder()
//        {
//            var client = new WowClient(TestConstants.TestRegion, "en-gb");
//            var battleGroups = client.GetBattleGroups();
//            Assert.IsNotNull(battleGroups);
//            Assert.IsNotNull(battleGroups.BattleGroups);
//            Assert.IsTrue(battleGroups.BattleGroups.Count > 0);
//            Assert.IsTrue(
//                battleGroups.ToString().StartsWith(battleGroups.BattleGroups.Count.ToString(CultureInfo.InvariantCulture)));

//            var firstBg = battleGroups.BattleGroups[3];
//            Assert.IsNotNull(firstBg);
//            Assert.IsNotNull(firstBg.Name);
//            Assert.IsNotNull(firstBg.Slug);
//            Assert.AreEqual(firstBg.Name, firstBg.ToString());

//            var random = new Random();
//            int teamCount = random.Next(5, 15);
//            int teamSize = random.Next(3);

//            if (teamSize == 0)
//                teamSize = 2;
//            else if (teamSize == 1)
//                teamSize = 3;
//            else
//                teamSize = 5;

//            const bool ascending = true;
//            var page = random.Next(3) + 1;

//            var teams = client.GetBattleGroupArenaTeams(firstBg.Name, teamSize, teamCount, page, ascending);
//            Assert.IsNotNull(teams);
//            Assert.IsNotNull(teams.ArenaTeams);
//            Assert.AreEqual(teamCount, teams.ArenaTeams.Count);
////            Assert.IsTrue(teams.ArenaTeams.Any(t => t.CurrentWeekRanking >= 1));
//            client.GetArenaTeam(teams.ArenaTeams[0].Realm, teams.ArenaTeams[0].Name, teamSize);
//            foreach (var team in teams.ArenaTeams)
//            {
//                Assert.IsNotNull(team);
//                Assert.IsNotNull(team.Members);
//                //Assert.IsTrue(team.Members.Count >= teamSize);
//                Assert.IsTrue(team.Members.Count > 0);
//                Assert.IsTrue(team.Ranking >= 1);
//                Assert.IsTrue(team.LastSeasonRanking >= 0);
//                Assert.AreEqual(teamSize, team.TeamSize);
//                Assert.AreEqual(team.WeekGamesPlayed, team.WeekGamesLost + team.WeekGamesWon);
//                Assert.AreEqual(team.SeasonGamesPlayed, team.SeasonGamesLost + team.SeasonGamesWon);


//                string desc = string.Format(CultureInfo.CurrentCulture, "{1}vs{1} Team: {0}@{2}", team.Name, teamSize,
//                                            team.Realm);
//                Assert.IsNotNull(team.Name);
//                Assert.IsNotNull(team.Realm);
//                Assert.IsNotNull(team.CreateDateString);
//                Assert.IsTrue(team.CreateDate.Year >= 2005 && team.CreateDate.Year <= DateTime.Now.Year);
//                Assert.AreEqual(desc, team.ToString());


//                Assert.IsTrue(team.Rating >= 0);
//                Assert.AreNotEqual(Faction.Neutral, team.Side);
//                Assert.IsNotNull(team.SideName);

//                foreach (var member in team.Members)
//                {
//                    Assert.IsNotNull(member);
//                    Assert.IsNotNull(member.Character);
//                    Assert.IsTrue(member.Rank >= 0);
//                    Assert.AreEqual(team.Realm, member.Character.Realm);
//                    Assert.AreEqual(team.Side, member.Character.Faction);
//                    Assert.AreEqual(member.SeasonGamesPlayed, member.SeasonGamesLost + member.SeasonGamesWon);
//                    Assert.AreEqual(member.WeekGamesPlayed, member.WeekGamesLost + member.WeekGamesWon);
//                    Assert.IsTrue(member.PersonalRating >= 0);
//                    Assert.AreEqual(member.Character.ToString(), member.ToString());
//                }
//            }
//        }

        ///// <summary>
        /////   test character arena teams
        ///// </summary>
        //[TestMethod]
        //public void TestCharacterArena()
        //{
        //    var client = new WowClient(TestConstants.TestRegionName, null, null, null);
        //    var battleGroups = client.GetBattleGroups();
        //    var firstBg = battleGroups.BattleGroups[3];

        //    var random = new Random();
        //    int teamSize = random.Next(3);
        //    PvpBracket type;

        //    if (teamSize == 0)
        //        type = PvpBracket.Arena2v2;
        //    else if (teamSize == 1)
        //        type = PvpBracket.Arena3v3;
        //    else
        //        type = PvpBracket.Arena5v5;
            
        //    var topPlayers = client.GetPvpLeaderboard(type);
        //    var character = client.GetCharacter(topPlayers.Leaderboard[0].RealmName, topPlayers.Leaderboard[0].Name);

        //    Assert.IsNotNull(character.Pvp);
        //    Assert.IsNotNull(character.Pvp.ArenaTeams);
        //    Assert.IsTrue(character.Pvp.ArenaTeams.Count > 0);

        //    var team = character.Pvp.ArenaTeams[0];
        //    Assert.IsNotNull(team.Name);
        //    Assert.IsTrue(team.PersonalRating >= 0);
        //    Assert.IsTrue(team.TeamRating >= 0);
        //    Assert.IsTrue(team.TeamSize > 0);
        //    Assert.IsTrue(team.TeamSizeName.StartsWith(team.TeamSize.ToString(CultureInfo.InvariantCulture)));
        //    Assert.IsNotNull(team.ToString());

        //    Assert.IsNotNull(character.Pvp.ToString());
        //}
    }
}