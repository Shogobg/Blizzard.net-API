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
    ///   challenge map
    /// </summary>
    [DataContract]
    public class ChallengeMap
    {
        /// <summary>
        ///   bronze criteria
        /// </summary>
        private ChallengeCompletionTime _bronzeCriteria;

        /// <summary>
        ///   gold criteria
        /// </summary>
        private ChallengeCompletionTime _goldCriteria;

        /// <summary>
        ///   whether the map has a challenge mode
        /// </summary>
        private bool _hasChallengeMode;

        /// <summary>
        ///   id of the map
        /// </summary>
        private int _id;

        /// <summary>
        ///   name of the map
        /// </summary>
        private string _name;

        /// <summary>
        ///   silver criteria
        /// </summary>
        private ChallengeCompletionTime _silverCriteria;

        /// <summary>
        ///   slug for the map
        /// </summary>
        private string _slug;

        /// <summary>
        ///   gets or sets whether the map has a challenge mode
        /// </summary>
        [DataMember(Name = "hasChallengeMode", IsRequired = false)]
        public bool HasChallengeMode
        {
            get
            {
                return _hasChallengeMode;
            }
            internal set
            {
                _hasChallengeMode = value;
            }
        }

        /// <summary>
        ///   gets or sets id of the map
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
        ///   gets or sets name of the map
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
        ///   gets or sets slug for the map
        /// </summary>
        [DataMember(Name = "slug", IsRequired = false)]
        public string Slug
        {
            get
            {
                return _slug;
            }
            internal set
            {
                _slug = value;
            }
        }

        /// <summary>
        ///   gets or sets bronze criteria
        /// </summary>
        [DataMember(Name = "bronzeCriteria", IsRequired = false)]
        public ChallengeCompletionTime BronzeCriteria
        {
            get
            {
                return _bronzeCriteria;
            }
            internal set
            {
                _bronzeCriteria = value;
            }
        }

        /// <summary>
        ///   gets or sets silver criteria
        /// </summary>
        [DataMember(Name = "silverCriteria", IsRequired = false)]
        public ChallengeCompletionTime SilverCriteria
        {
            get
            {
                return _silverCriteria;
            }
            internal set
            {
                _silverCriteria = value;
            }
        }


        /// <summary>
        ///   gets or sets gold criteria
        /// </summary>
        [DataMember(Name = "goldCriteria", IsRequired = false)]
        public ChallengeCompletionTime GoldCriteria
        {
            get
            {
                return _goldCriteria;
            }
            internal set
            {
                _goldCriteria = value;
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}