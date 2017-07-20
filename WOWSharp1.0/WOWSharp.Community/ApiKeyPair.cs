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
using System.Text;

namespace WOWSharp.Community
{
    /// <summary>
    ///   An public/private key pair used to authenticate request to battle.net site
    /// </summary>
    public sealed class ApiKeyPair
    {
        /// <summary>
        ///   Private key
        /// </summary>
        private readonly string _privateKey;

        /// <summary>
        ///   gets the public key
        /// </summary>
        private string _publicKey;

        /// <summary>
        ///   constructor. initializes a new instance of ApiKeyPair class
        /// </summary>
        /// <param name="publicKey"> public key </param>
        /// <param name="privateKey"> private key </param>
        public ApiKeyPair(string publicKey, string privateKey)
        {
            if (string.IsNullOrEmpty(publicKey))
                throw new ArgumentNullException("publicKey");
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException("privateKey");
            PublicKey = publicKey;
            _privateKey = privateKey;
        }

        /// <summary>
        ///   gets the public key
        /// </summary>
        public string PublicKey
        {
            get
            {
                return _publicKey;
            }
            private set
            {
                _publicKey = value;
            }
        }

        /// <summary>
        ///   Gets the private key
        /// </summary>
        public string PrivateKey
        {
            get
            {
                return _privateKey;
            }
        }

        /// <summary>
        ///   gets the private key
        /// </summary>
        public byte[] GetPrivateKeyBytes()
        {
            return Encoding.UTF8.GetBytes(_privateKey);
        }
    }
}