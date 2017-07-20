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
        ///   id
        /// </summary>
        private int _id;

        /// <summary>
        ///   key (culture independent name)
        /// </summary>
        private string _key;

        /// <summary>
        ///   name
        /// </summary>
        private string _name;

        /// <summary>
        ///   strong against type id
        /// </summary>
        private int _strongAgainstId;

        /// <summary>
        ///   type ability id
        /// </summary>
        private int _typeAbilityId;

        /// <summary>
        ///   Weak against id
        /// </summary>
        private int _weakAgainstId;

        /// <summary>
        ///   gets or sets id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        /// <summary>
        ///   gets or sets key (culture independent name)
        /// </summary>
        [DataMember(Name = "key", IsRequired = false)]
        public string Key
        {
            get
            {
                return _key;
            }
            internal set
            {
                _key = value;
            }
        }

        /// <summary>
        ///   gets or sets name
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   gets or sets strong against type id
        /// </summary>
        [DataMember(Name = "strongAgainstId", IsRequired = false)]
        public int StrongAgainstId
        {
            get
            {
                return _strongAgainstId;
            }
            internal set
            {
                _strongAgainstId = value;
            }
        }

        /// <summary>
        ///   gets or sets type ability id
        /// </summary>
        [DataMember(Name = "typeAbilityId", IsRequired = false)]
        public int TypeAbilityId
        {
            get
            {
                return _typeAbilityId;
            }
            internal set
            {
                _typeAbilityId = value;
            }
        }

        /// <summary>
        ///   gets or sets Weak against id
        /// </summary>
        [DataMember(Name = "weakAgainstId", IsRequired = false)]
        public int WeakAgainstId
        {
            get
            {
                return _weakAgainstId;
            }
            internal set
            {
                _weakAgainstId = value;
            }
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