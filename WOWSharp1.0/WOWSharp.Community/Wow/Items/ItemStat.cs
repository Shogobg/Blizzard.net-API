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
    ///   Represents an item bonus stat
    /// </summary>
    [DataContract]
    public class ItemStat
    {
        /// <summary>
        ///   Gets or sets the bonus stat amount
        /// </summary>
        private int _amount;

        /// <summary>
        ///   Gets or sets whether the stat is reforged (this is always false when requesting item info)
        /// </summary>
        private bool _isReforged;

        /// <summary>
        ///   Gets or sets the bonus stat type
        /// </summary>
        private ItemStatType _statType;

        /// <summary>
        ///   Gets or sets the reforged amount (this should be negative)
        /// </summary>
        private int _reforgedAmount;

        /// <summary>
        ///   Gets or sets the bonus stat type
        /// </summary>
        [DataMember(Name = "stat", IsRequired = true)]
        public ItemStatType StatType
        {
            get
            {
                return _statType;
            }
            internal set
            {
                _statType = value;
            }
        }

        /// <summary>
        ///   Gets or sets the bonus stat amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true)]
        public int Amount
        {
            get
            {
                return _amount;
            }
            internal set
            {
                _amount = value;
            }
        }


        /// <summary>
        ///   Gets or sets whether the stat is reforged. this is true for the reforged to stat (the stat that is increased)
        /// </summary>
        [DataMember(Name = "reforged", IsRequired = false)]
        public bool IsReforged
        {
            get
            {
                return _isReforged;
            }
            internal set
            {
                _isReforged = value;
            }
        }

        /// <summary>
        ///    Gets or sets the reforged amount i.e. the stat that is decreased when the item is reforged (this should be negative)
        /// </summary>
        [DataMember(Name = "reforgedAmount", IsRequired = false)]
        public int ReforgedAmount
        {
            get
            {
                return _reforgedAmount;
            }
            internal set
            {
                _reforgedAmount = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", StatType, Amount);
        }
    }
}