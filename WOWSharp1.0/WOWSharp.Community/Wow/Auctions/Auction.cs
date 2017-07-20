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
    ///   Represents information about an auction
    /// </summary>
    [DataContract]
    public class Auction
    {
        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        private long _auctionId;

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        private long? _buyoutValue;

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        private long _currentBidValue;

        /// <summary>
        ///   gets or sets the item id
        /// </summary>
        private int _itemId;

        /// <summary>
        ///   Gets or sets the owner name
        /// </summary>
        private string _ownerName;

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        private int _quantity;

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "auc", IsRequired = true)]
        public long AuctionId
        {
            get
            {
                return _auctionId;
            }
            internal set
            {
                _auctionId = value;
            }
        }

        /// <summary>
        ///   gets or sets the item id
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            internal set
            {
                _itemId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the owner name
        /// </summary>
        [DataMember(Name = "owner", IsRequired = true)]
        public string OwnerName
        {
            get
            {
                return _ownerName;
            }
            internal set
            {
                _ownerName = value;
            }
        }

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        [DataMember(Name = "bid", IsRequired = true)]
        public long CurrentBidValue
        {
            get
            {
                return _currentBidValue;
            }
            internal set
            {
                _currentBidValue = value;
            }
        }

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        [DataMember(Name = "buyout", IsRequired = false)]
        public long? BuyoutValue
        {
            get
            {
                return _buyoutValue;
            }
            internal set
            {
                _buyoutValue = value;
            }
        }

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            internal set
            {
                _quantity = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 "Auction {0}, Item Id {1}, Owner {2}, Bid {3}, Buyout {4}, Quantity {5}",
                                 AuctionId, ItemId, OwnerName, CurrentBidValue, BuyoutValue, Quantity);
        }
    }
}