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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
{
    /// <summary>
    ///   Test challenge mode api
    /// </summary>
    [TestClass]
    public class ChallengeTests
    {
        /// <summary>
        ///   Test leaders for a realm
        /// </summary>
        /// <param name="realmName"> realm name (null for region) </param>
        private void TestLeaders(string realmName)
        {
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
            var result = client.GetChallengeLeaders(realmName);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Challenges);
            Assert.IsTrue(result.Challenges.All(c => c != null));
            Assert.IsTrue(result.Challenges.All(c => c.Map != null));
            Assert.IsTrue(result.Challenges.All(c => c.Groups != null));
            Assert.IsTrue(result.Challenges.All(c => c.Groups.All(g => g != null)));
            Assert.IsTrue(result.Challenges.All(c => c.Groups.All(g => g.MedalName != null)));
            Assert.IsTrue(result.Challenges.All(c => c.Groups.All(g => g.Members.All(m => m != null))));
            Assert.IsTrue(result.Challenges.All(c => c.Groups.All(g => g.Time != null)));
            Assert.IsTrue(result.Challenges.All(c => c.Groups.All(g => g.Time.TotalMilliseconds > 0)));
        }

        /// <summary>
        ///   test region leaders
        /// </summary>
        [TestMethod]
        public void TestGettingRegionLeaders()
        {
            TestLeaders(null);
        }

        /// <summary>
        ///   realm leaders
        /// </summary>
        [TestMethod]
        public void TestGettingRealmLeaders()
        {
            TestLeaders(TestConstants.TestRealmName);
        }
    }
}