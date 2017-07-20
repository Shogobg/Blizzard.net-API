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
using System.Threading.Tasks;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Represents a caching implementation that caches bnet api query results.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        ///   Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        ///   the new item is added.
        /// </summary>
        /// <param name="key"> Identifier for this CacheItem </param>
        /// <param name="value"> Value to be stored in cache. </param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        Task AddDataAsync(string key, object value);

        /// <summary>
        ///   Returns the value associated with the given key.
        /// </summary>
        /// <param name="key"> Key of item to return from cache. </param>
        /// <returns> Value stored in cache </returns>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        Task<object> LookupDataAsync(string key);
    }
}