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