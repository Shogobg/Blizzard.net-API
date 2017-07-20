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