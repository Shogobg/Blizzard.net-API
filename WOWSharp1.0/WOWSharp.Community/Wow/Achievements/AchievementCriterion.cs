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
    ///   An achievement criteria
    /// </summary>
    [DataContract]
    public class AchievementCriterion
    {
        /// <summary>
        ///   Achievement description
        /// </summary>
        private string _description;

        /// <summary>
        ///   Achievement criteria
        /// </summary>
        private int _id;

        /// <summary>
        ///   Max
        /// </summary>
        private int _max;

        /// <summary>
        ///   Order Index
        /// </summary>
        private int _orderIndex;

        /// <summary>
        ///   Achievement criteria
        /// </summary>
        [DataMember(Name = "id")]
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
        ///   Achievement description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get
            {
                return _description;
            }
            internal set
            {
                _description = value;
            }
        }

        /// <summary>
        ///   Order Index
        /// </summary>
        [DataMember(Name = "orderIndex")]
        public int OrderIndex
        {
            get
            {
                return _orderIndex;
            }
            internal set
            {
                _orderIndex = value;
            }
        }

        /// <summary>
        ///   Max
        /// </summary>
        [DataMember(Name = "max")]
        public int Max
        {
            get
            {
                return _max;
            }
            internal set
            {
                _max = value;
            }
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            return Description;
        }
    }
}