/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents information about an auction
    /// </summary>
    [DataContract]
    [Serializable]
    public class Auction : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or set the auction id
        /// </summary>
        [DataMember(Name = "auc", IsRequired = true)]
        public int AuctionId
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the item id
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the owner name
        /// </summary>
        [DataMember(Name = "owner", IsRequired = true)]
        public string OwnerName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bid value in copper
        /// </summary>
        [DataMember(Name = "bid", IsRequired = true)]
        public long CurrentBidValue
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the buyout value in copper
        /// </summary>
        [DataMember(Name = "buyout", IsRequired = false)]
        public long? BuyoutValue
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("Auction {0}, Item Id {1}, Owner {2}, Bid {3}, Buyout {4}, Quantity {5}",
                this.AuctionId, this.ItemId, this.OwnerName, this.CurrentBidValue, this.BuyoutValue, this.Quantity);
        }
    }
}
