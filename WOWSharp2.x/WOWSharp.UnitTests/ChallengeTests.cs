
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community.Wow;
using WOWSharp.Community;

namespace WOWSharp.UnitTests
{
    /// <summary>
    ///   Test challenge mode api
    /// </summary>
    [TestClass]
    public class ChallengeTests
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
        ///   Test leaders for a realm
        /// </summary>
        /// <param name="realmName"> realm name (null for region) </param>
        private void TestLeaders(string realmName)
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var result = client.GetChallengeLeadersAsync(realmName).Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Challenges);
            Assert.IsTrue(result.Challenges.All(c => c != null));
            Assert.IsTrue(result.Challenges.Any(c => c.Map != null));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups != null));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups.All(g => g != null)));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups.Any(g => g.Medal != ChallengeMedalType.None)));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups.All(g => g.Members.All(m => m != null))));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups.All(g => g.Time != null)));
            Assert.IsTrue(result.Challenges.Any(c => c.Groups.All(g => g.Time.TotalMilliseconds > 0)));
        }

        /// <summary>
        ///   test region leaders
        /// </summary>
        [TestMethod]
        [TestCategory("WowChallengeMode")]
        public void TestGettingRegionLeaders()
        {
            TestLeaders(null);
        }

        /// <summary>
        ///   realm leaders
        /// </summary>
        [TestMethod]
        [TestCategory("WowChallengeMode")]
        public void TestGettingRealmLeaders()
        {
            TestLeaders(TestConstants.TestRealmName);
        }
    }
}