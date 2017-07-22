
using System;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Thrown when an exception is thrown by a cache manager. This is the only type of exception that the ApiClient class will swallow.
    ///   If a cache manager throws any other exception it will not be caught
    /// </summary>
    public class CacheManagerException : Exception
    {
        /// <summary>
        ///   Constructor
        /// </summary>
        public CacheManagerException()
        {
        }

        /// <summary>
        ///   constructor
        /// </summary>
        /// <param name="message"> exception message </param>
        public CacheManagerException(string message) : base(message)
        {
        }

        /// <summary>
        ///   constructor
        /// </summary>
        /// <param name="message"> message </param>
        /// <param name="inner"> inner exception </param>
        public CacheManagerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}