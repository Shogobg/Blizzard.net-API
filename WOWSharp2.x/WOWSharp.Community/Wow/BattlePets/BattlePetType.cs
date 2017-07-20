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

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   information about a battle pet type
    /// </summary>
    [DataContract]
    public class BattlePetType
    {
        /// <summary>
        ///   gets or sets id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets key (culture independent name)
        /// </summary>
        [DataMember(Name = "key", IsRequired = false)]
        public string Key
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets strong against type id
        /// </summary>
        [DataMember(Name = "strongAgainstId", IsRequired = false)]
        public int StrongAgainstId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets type ability id
        /// </summary>
        [DataMember(Name = "typeAbilityId", IsRequired = false)]
        public int TypeAbilityId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets Weak against id
        /// </summary>
        [DataMember(Name = "weakAgainstId", IsRequired = false)]
        public int WeakAgainstId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}