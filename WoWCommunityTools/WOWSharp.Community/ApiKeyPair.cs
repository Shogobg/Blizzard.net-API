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

namespace WOWSharp.Community
{
    /// <summary>
    /// An public/private key pair used to authenticate request to battle.net site
    /// </summary>
    public sealed class ApiKeyPair
    {
        /// <summary>
        /// constructor. initializes a new instance of ApiKeyPair class
        /// </summary>
        /// <param name="publicKey">public key</param>
        /// <param name="privateKey">private key</param>
        /// <param name="ignoreOnPartialTrust">In .NET Framework 3.5, Date header cannot be set without fulltrust. When this flag is true, the no exception is thrown when running in partial trust and the request is performed without using the key.</param>
        public ApiKeyPair(string publicKey, string privateKey, bool ignoreOnPartialTrust)
        {
            if (string.IsNullOrEmpty(publicKey))
                throw new ArgumentNullException("publicKey");
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException("privateKey");
            this.PublicKey = publicKey;
            this.PrivateKey = Encoding.UTF8.GetBytes(privateKey);
            this.IgnoreOnPartialTrust = ignoreOnPartialTrust;
        }

        /// <summary>
        /// constructor. initializes a new instance of ApiKeyPair class
        /// </summary>
        /// <param name="publicKey">public key</param>
        /// <param name="privateKey">private key</param>
        public ApiKeyPair(string publicKey, string privateKey) : this(publicKey, privateKey, true)
        {
            
        }

        /// <summary>
        /// gets the public key
        /// </summary>
        public string PublicKey
        {
            get;
            private set;
        }

        /// <summary>
        /// gets the private key
        /// </summary>
        public byte[] PrivateKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets whether to ignore this key when running in .NET 3.5 partial trust environment
        /// </summary>
        public bool IgnoreOnPartialTrust
        {
            get;
            private set;
        }
    }
}
