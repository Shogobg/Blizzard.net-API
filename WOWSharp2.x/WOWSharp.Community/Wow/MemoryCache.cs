
using System.Collections.Generic;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   A memory cache (for objects that are cached permanently, such as race information)
    /// </summary>
    /// <typeparam name="TKey"> Key type </typeparam>
    /// <typeparam name="TValue"> Value type </typeparam>
    /// <remarks>
    ///   This class is thread safe
    /// </remarks>
    internal class MemoryCache<TKey, TValue> where TValue : class
    {
        /// <summary>
        ///   Dictionary for the cache
        /// </summary>
        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        ///   Reader writer lock to synchronize access to this object.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        ///   Looks up value in cache, and calls cacheMissFunction to retrieve it in case of a cache miss
        /// </summary>
        /// <param name="key"> key to lookup </param>
        /// <returns> The value </returns>
        public TValue LookupValue(TKey key)
        {
            // read-only lock
            lock (_lock)
            {
                TValue value;
                _dictionary.TryGetValue(key, out value);
                return value;
            }
        }

        /// <summary>
        ///   Adds a value to the cache
        /// </summary>
        /// <param name="key"> key to add </param>
        /// <param name="value"> the value to add </param>
        public void AddValue(TKey key, TValue value)
        {
            // read-only lock
            lock (_lock)
            {
                if (!_dictionary.ContainsKey(key))
                {
                    _dictionary.Add(key, value);
                }
            }
        }
    }
}