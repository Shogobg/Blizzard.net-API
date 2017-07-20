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
using WOWSharp.Community;

namespace WOWSharp.UnitTests
{
    /// <summary>
    ///   Tests PvP related APIs
    /// </summary>
    [TestClass]
    public class PvpTests
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
        /// Test wow PvP
        /// </summary>
        [TestMethod]
        [TestCategory("WowPvP")]
        public void TestPvPLeaderboard()
        {
            TestPvPLeaderboard(PvpBracket.Arena2v2);
            TestPvPLeaderboard(PvpBracket.Arena3v3);
            TestPvPLeaderboard(PvpBracket.Arena5v5);
            TestPvPLeaderboard(PvpBracket.RatedBattleground);
        }

        /// <summary>
        /// Leader boards test
        /// </summary>
        /// <param name="bracket"></param>
        private void TestPvPLeaderboard(PvpBracket bracket)
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb");
            var response = client.GetPvpLeaderboardAsync(bracket).Result;
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
            var chr = client.GetCharacterAsync(first.RealmName, first.Name, CharacterFields.Pvp).Result;
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
    }
}