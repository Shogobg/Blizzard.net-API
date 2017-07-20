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
    ///   Represents a weapon's damage
    /// </summary>
    [DataContract]
    public class WeaponDamage
    {
        /// <summary>
        ///   Gets or sets the maximum weapon damage
        /// </summary>
        private int _maximumDamage;

        /// <summary>
        ///   Gets or sets the minimum weapon damage
        /// </summary>
        private int _minimumDamage;

        /// <summary>
        ///   Gets or sets the exact maximum weapon damage
        /// </summary>
        private double _exactMaximumDamage;

        /// <summary>
        ///   Gets or sets the exact minimum weapon damage
        /// </summary>
        private double _exactMinimumDamage;

        /// <summary>
        ///   Gets or sets the maximum weapon damage
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int MaximumDamage
        {
            get
            {
                return _maximumDamage;
            }
            internal set
            {
                _maximumDamage = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minimum weapon damage
        /// </summary>
        [DataMember(Name = "min", IsRequired = true)]
        public int MinimumDamage
        {
            get
            {
                return _minimumDamage;
            }
            internal set
            {
                _minimumDamage = value;
            }
        }

        /// <summary>
        ///   Gets or sets the exact maximum weapon damage
        /// </summary>
        [DataMember(Name = "exactMax", IsRequired = true)]
        public double ExactMaximumDamage
        {
            get
            {
                return _exactMaximumDamage;
            }
            internal set
            {
                _exactMaximumDamage = value;
            }
        }

        /// <summary>
        ///   Gets or sets the exact minimum weapon damage
        /// </summary>
        [DataMember(Name = "exactMin", IsRequired = true)]
        public double ExactMinimumDamage
        {
            get
            {
                return _exactMinimumDamage;
            }
            internal set
            {
                _exactMinimumDamage = value;
            }
        }


        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} - {1}", MinimumDamage, MaximumDamage);
        }
    }
}