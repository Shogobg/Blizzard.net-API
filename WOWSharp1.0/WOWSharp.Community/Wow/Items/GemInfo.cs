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
    ///   Represents gem information
    /// </summary>
    [DataContract]
    public class GemInfo
    {
        /// <summary>
        ///   gets or sets the gem's bonus
        /// </summary>
        private GemBonus _bonus;

        /// <summary>
        ///   gets or sets the gem's type
        /// </summary>
        private GemType _typeOfGem;

        /// <summary>
        ///   gets or sets the gem's bonus
        /// </summary>
        [DataMember(Name = "bonus", IsRequired = false)]
        public GemBonus Bonus
        {
            get
            {
                return _bonus;
            }
            internal set
            {
                _bonus = value;
            }
        }

        /// <summary>
        ///   gets or sets the gem's type
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public GemType TypeOfGem
        {
            get
            {
                return _typeOfGem;
            }
            internal set
            {
                _typeOfGem = value;
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return TypeOfGem + ": " + Bonus;
        }
    }
}