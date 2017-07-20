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
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   information about a challenge
    /// </summary>
    [DataContract]
    public class Challenge
    {
        /// <summary>
        ///   groups that completed the challenge
        /// </summary>
        private IList<ChallengeGroup> _groups;

        /// <summary>
        ///   map
        /// </summary>
        private ChallengeMap _map;

        /// <summary>
        ///   realm
        /// </summary>
        private Realm _realm;

        /// <summary>
        ///   gets or sets groups that completed the challenge
        /// </summary>
        [DataMember(Name = "groups", IsRequired = false)]
        public IList<ChallengeGroup> Groups
        {
            get
            {
                return _groups;
            }
            internal set
            {
                _groups = value;
            }
        }

        /// <summary>
        ///   gets or sets map
        /// </summary>
        [DataMember(Name = "map", IsRequired = false)]
        public ChallengeMap Map
        {
            get
            {
                return _map;
            }
            internal set
            {
                _map = value;
            }
        }

        /// <summary>
        ///   gets or sets realm
        /// </summary>
        [DataMember(Name = "realm", IsRequired = false)]
        public Realm Realm
        {
            get
            {
                return _realm;
            }
            internal set
            {
                _realm = value;
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} - {1}", Map, Realm);
        }
    }
}