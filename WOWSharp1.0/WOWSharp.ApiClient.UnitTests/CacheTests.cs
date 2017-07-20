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

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void TestCacheFailOnAdd()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(true, false));
            Assert.IsNotNull(client.GetItem(49110));
        }

        [TestMethod]
        public void TestCacheFailOnGet()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(false, true));
            Assert.IsNotNull(client.GetItem(49110));
            Assert.IsNotNull(client.GetItem(49110));
        }

        [TestMethod]
        public void TestCacheNoFail()
        {
            var client = new WowClient(TestConstants.TestRegion, null, new MockupCache(false, false));
            var item1 = client.GetItem(49110);
            var item2 = client.GetItem(49110);
            Assert.AreSame(item1, item2);
        }

        #region Nested type: MockupCache

        private class MockupCache : ICacheManager
        {
            private readonly Dictionary<string, object> _dict = new Dictionary<string, object>();
            private readonly bool _failOnAdd;
            private readonly bool _failOnGet;

            public MockupCache(bool failOnAdd, bool failOnGet)
            {
                _failOnAdd = failOnAdd;
                _failOnGet = failOnGet;
            }

            #region ICacheManager Members

            public void AddData(string key, object value)
            {
                if (_failOnAdd)
                    throw new CacheManagerException();
                _dict[key] = value;
            }

            public object LookupData(string key)
            {
                if (_failOnGet)
                    throw new CacheManagerException();
                object o;
                _dict.TryGetValue(key, out o);
                return o;
            }

            #endregion
        }

        #endregion
    }
}