/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WOWSharp.Community
{
    /// <summary>
    /// A memory cache (for objects that are cached permanently, such as race information)
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    /// <remarks>This class is thread safe</remarks>
    internal class MemoryCache<TKey, TValue> : IDisposable where TValue : class
    {
        /// <summary>
        /// Dictionary for the cache
        /// </summary>
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey,TValue>();
        
        /// <summary>
        /// Reader writer lock to synchronize access to this object.
        /// </summary>
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Looks up value in cache, and calls cacheMissFunction to retrieve it in case of a cache miss
        /// </summary>
        /// <param name="key">key to lookup</param>
        /// <returns>The value</returns>
        public TValue LookupValue(TKey key)
        {
            if (_lock == null)
                throw new ObjectDisposedException(this.GetType().Name);
            TValue value;
            // read-only lock
            _lock.EnterReadLock();
            try
            {
                _dictionary.TryGetValue(key, out value);
                return value;
            }
            finally
            {
                // exit read-only lock
                _lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Adds a value to the cache
        /// </summary>
        /// <param name="key">key to add</param>
        /// <param name="value">the value to add</param>
        public void AddValue(TKey key, TValue value)
        {
            if (_lock == null)
                throw new ObjectDisposedException(this.GetType().Name);
            // read-only lock
            _lock.EnterWriteLock();
            try
            {
                if(!_dictionary.ContainsKey(key))
                {
                    _dictionary.Add(key, value);
                }
                else
                {
                    _dictionary[key] = value;
                }
            }
            finally
            {
                // exit read-only lock
                _lock.ExitWriteLock();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes resources used by this object
        /// </summary>
        public void Dispose()
        {
            if (_lock != null)
                _lock.Dispose();
            _lock = null;
        }

        #endregion
    }
}
