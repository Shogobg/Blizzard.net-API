
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;
using System.Threading.Tasks;

namespace WOWSharp.UnitTests
{
    /// <summary>
    /// Test cache API 
    /// </summary>
    [TestClass]
    public class CacheTests
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
        /// Test failing on add
        /// </summary>
        [TestMethod]
        public void TestCacheFailOnAdd()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(true, false));
            Assert.IsNotNull(client.GetItemAsync(49110).Result);
        }

        /// <summary>
        /// Test fail on get
        /// </summary>
        [TestMethod]
        public void TestCacheFailOnGet()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(false, true));
            Assert.IsNotNull(client.GetItemAsync(49110).Result);
            Assert.IsNotNull(client.GetItemAsync(49110).Result);
        }

        /// <summary>
        /// Test cache that doesn't fail
        /// </summary>
        [TestMethod]
        public void TestCacheNoFail()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(false, false));
            var item1 = client.GetItemAsync(49110).Result;
            var item2 = client.GetItemAsync(49110).Result;
            Assert.AreSame(item1, item2);
        }

        #region Nested type: MockupCache

        /// <summary>
        /// A class that emulates cache
        /// </summary>
        private class MockupCache : ICacheManager
        {
            /// <summary>
            /// Cache storage
            /// </summary>
            private readonly Dictionary<string, object> _dict = new Dictionary<string, object>();
            /// <summary>
            /// Whether the class should always fail on adding
            /// </summary>
            private readonly bool _failOnAdd;
            /// <summary>
            /// Whether the class should always fail on get
            /// </summary>
            private readonly bool _failOnGet;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="failOnAdd"></param>
            /// <param name="failOnGet"></param>
            public MockupCache(bool failOnAdd, bool failOnGet)
            {
                _failOnAdd = failOnAdd;
                _failOnGet = failOnGet;
            }

            #region ICacheManager Members

            /// <summary>
            /// Add data
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public Task AddDataAsync(string key, object value)
            {
                if (_failOnAdd)
                    throw new CacheManagerException();
                _dict[key] = value;
                return Task.FromResult(true);
            }

            /// <summary>
            /// Remove data
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public Task<object> LookupDataAsync(string key)
            {
                if (_failOnGet)
                    throw new CacheManagerException();
                object o;
                _dict.TryGetValue(key, out o);
                return Task.FromResult(o);
            }

            #endregion
        }

        #endregion
    }
}