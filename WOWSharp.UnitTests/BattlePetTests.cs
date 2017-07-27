
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.UnitTests
{
    /// <summary>
    ///   Testing battle pets api
    /// </summary>
    [TestClass]
    public class BattlePetTests
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
        ///   test battlePetAbilityApi
        /// </summary>
        [TestMethod]
        [TestCategory("WOWPets")]
        public void TestBattlePetAbility()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var ability = client.GetBattlePetAbilityAsync(640).Result;
            Assert.IsNotNull(ability);
            Assert.IsNotNull(ability.Name);
            Assert.AreEqual(ability.Id, 640);
            Assert.IsNotNull(ability.Icon);
        }

        /// <summary>
        ///   test battlePetAbilityApi
        /// </summary>
        [TestMethod]
        [TestCategory("WOWPets")]
        public void TestBattlePetSpecies()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var species = client.GetBattlePetSpeciesAsync(258).Result;
            Assert.IsNotNull(species);
            Assert.IsNotNull(species.Description);
            Assert.AreEqual(258, species.SpeciesId);
            Assert.IsNotNull(species.Icon);
        }

        /// <summary>
        ///   Test battle pet types
        /// </summary>
        [TestMethod]
        [TestCategory("WOWPets")]
        public void TestBattlePetTypes()
        {
            var client = new WowClient(TestConstants.TestRegion, "en-gb", TestConstants.apiKey, null);
            var types = client.GetBattlePetTypesAsync().Result;
            Assert.IsNotNull(types);
            Assert.IsNotNull(types.PetTypes);
            Assert.AreNotEqual(0, types.PetTypes.Count);
            Assert.IsTrue(types.PetTypes.All(pt => pt.Name != null));
        }
    }
}