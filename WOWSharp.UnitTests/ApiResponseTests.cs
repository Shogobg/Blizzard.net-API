
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.UnitTests
{
	/// <summary>
	/// Test ApiResponse class
	/// </summary>
	[TestClass]
    public class ApiResponseTests
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
        /// Test Refresh method
        /// </summary>
        [TestMethod]
        [TestCategory("WOW")]
        public void TestRefreshCharacter()
        {
            var client = new WowClient(TestConstants.TestRegionName, "en-gb", TestConstants.apiKey, null);
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.All).Result;
			client.RefreshAsync();
        }
    }
}
