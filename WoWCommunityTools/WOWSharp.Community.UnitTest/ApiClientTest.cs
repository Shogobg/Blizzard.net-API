using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community.ObjectModel;

namespace WOWSharp.Community.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ApiClientTest
    {
        public ApiClientTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Test auctions API
        /// </summary>
        [TestMethod]
        public void TestAuctions()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetAuctionDump(TestConstants.TestRealmName);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Alliance);
            Assert.IsNotNull(result.Alliance.Auctions);
            Assert.IsNotNull(result.Horde);
        }

        /// <summary>
        /// Test auctions API
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(WoWAPIException))]
        public void TestApiException()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetAuctionDump(TestConstants.TestRealmName + TestConstants.TestRealmName); // invalid realm name
            // should get realm not found
        }

        /// <summary>
        /// Test get Item
        /// </summary>
        [TestMethod]
        public void TestItems()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetItem(17182);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ItemQuality == ItemQuality.Legendary);
            Assert.IsNotNull(result.Id = 17182);
        }

        /// <summary>
        /// Test data API
        /// </summary>
        [TestMethod]
        public void TestPerks()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetGuildPerks();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Perks);
            Assert.IsNotNull(result.Perks.Length > 0);
        }

        /// <summary>
        /// Test data API
        /// </summary>
        [TestMethod]
        public void TestRewards()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetGuildRewards();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Rewards);
            Assert.IsNotNull(result.Rewards.Length > 0);
        }

        /// <summary>
        /// Test data API
        /// </summary>
        [TestMethod]
        public void TestItemCategoryNames()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetItemCategoryNames();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CategoryNames);
            Assert.IsNotNull(result.CategoryNames.Length > 0);
        }

        /// <summary>
        /// Test data API
        /// </summary>
        [TestMethod]
        public void TestClasses()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetClasses();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetClasses();
            Assert.IsTrue(object.ReferenceEquals(result, result2));
        }

        /// <summary>
        /// Test data API
        /// </summary>
        [TestMethod]
        public void TestRaces()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var result = client.GetRaces();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
            var result2 = client.GetRaces();
            Assert.IsTrue(object.ReferenceEquals(result, result2));
        }

        /// <summary>
        /// Tests async calls and realm status
        /// </summary>
        [TestMethod]
        public void TestRealmsAsync()
        {
            bool testResult = false;
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            object asyncState = new object();
            IAsyncResult result = client.BeginGetRealmStatus(
                (o) =>
                {
                    testResult = o.AsyncState == asyncState;
                }, asyncState
                );
            RealmStatusResponse response = client.EndGetRealmStatus(result);
            Assert.IsTrue(testResult);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Realms);
            Assert.IsTrue(response.Realms.Length > 0);
        }

        /// <summary>
        /// Tests get guild
        /// </summary>
        [TestMethod]
        public void TestGuild()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var guild = client.GetGuild(TestConstants.TestRealmName, TestConstants.TestGuildName, true);
            Assert.IsNotNull(guild);
            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);
            Assert.IsTrue(guild.Members.Length > 0);
            Assert.IsTrue(string.Equals(guild.Members[0].Character.Realm, TestConstants.TestRealmName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(guild.Name, TestConstants.TestGuildName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests get character
        /// </summary>
        [TestMethod]
        public void TestCharacter()
        {
            ApiClient client = new ApiClient(TestConstants.TestRegionName, null, null, null);
            var character = client.GetCharacter(TestConstants.TestRealmName, TestConstants.TestCharacterName, true);
            Assert.IsNotNull(character);
            Assert.IsNotNull(character.Professions);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Items);
            Assert.IsNotNull(character.Titles);
            Assert.IsNotNull(character.Mounts);
            Assert.IsNotNull(character.Companions);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Progression);
            Assert.IsTrue(character.Class == Class.Druid);
            Assert.IsTrue(character.Level >= 85);

            Assert.IsTrue(string.Equals(character.Realm, TestConstants.TestRealmName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(character.Name, TestConstants.TestCharacterName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
