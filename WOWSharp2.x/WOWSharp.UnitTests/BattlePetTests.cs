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
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
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
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
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
            var client = new WowClient(TestConstants.TestRegion, TestConstants.Credentials, null, null);
            var types = client.GetBattlePetTypesAsync().Result;
            Assert.IsNotNull(types);
            Assert.IsNotNull(types.PetTypes);
            Assert.AreNotEqual(0, types.PetTypes.Count);
            Assert.IsTrue(types.PetTypes.All(pt => pt.Name != null));
        }
    }
}