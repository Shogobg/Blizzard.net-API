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

using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a character's current standing with a faction
    /// </summary>
    [DataContract]
    public class CharacterReputation
    {
        /// <summary>
        ///   gets or sets faction id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the max value to reach the next standing
        /// </summary>
        private int _maximum;

        /// <summary>
        ///   gets or sets faction name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the current standing
        /// </summary>
        private Standing _standing;

        /// <summary>
        ///   Gets or sets the progress within the current standing
        /// </summary>
        private int _value;

        /// <summary>
        ///   gets or sets faction id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
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
        ///   gets or sets faction name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
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
        ///   Gets or sets the current standing
        /// </summary>
        [DataMember(Name = "standing", IsRequired = true)]
        public Standing Standing
        {
            get
            {
                return _standing;
            }
            internal set
            {
                _standing = value;
            }
        }

        /// <summary>
        ///   Gets or sets the progress within the current standing
        /// </summary>
        [DataMember(Name = "value", IsRequired = true)]
        public int Value
        {
            get
            {
                return _value;
            }
            internal set
            {
                _value = value;
            }
        }

        /// <summary>
        ///   Gets or sets the max value to reach the next standing
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            internal set
            {
                _maximum = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} {1} {2}/{3}", Name, Standing, Value, Maximum);
        }
    }
}