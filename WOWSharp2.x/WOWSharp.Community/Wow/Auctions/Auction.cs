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
using Newtonsoft.Json.Converters;
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
        [DataMember(Name = "auc", IsRequired = true)]
        public long AuctionId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the item id
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the owner name
        /// </summary>
        [DataMember(Name = "owner", IsRequired = true)]
        public string OwnerName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        [DataMember(Name = "bid", IsRequired = true)]
        public long CurrentBidValue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        [DataMember(Name = "buyout", IsRequired = false)]
        public long? BuyoutValue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity
        {
            get;
            internal set;
        }

        /// <summary>
        ///  gets or sets the owner's realm for the auction
        /// </summary>
        [DataMember(Name = "ownerRealm", IsRequired = false)]
        public string OwnerRealm
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the time left for the auction to expire
        /// </summary>
        [DataMember(Name = "timeLeft", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuctionTimeLeft TimeLeft
        {
            get;
            internal set;
        }

        /// <summary>
        /// No clue what this value is about. rand property for auction returned by Blizzard's API
        /// </summary>
        [DataMember(Name = "rand", IsRequired = false)]
        public long Random
        {
            get;
            internal set;
        }

        /// <summary>
        /// No clue what this value is about. seed property for auction returned by Blizzard's API
        /// </summary>
        [DataMember(Name = "seed", IsRequired = false)]
        public long Seed
        {
            get;
            internal set;
        }

        /// <summary>
        /// Pet species Id (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "petSpeciesId", IsRequired = false)]
        public int PetSpeciesId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Pet breed Id (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "petBreedId", IsRequired = false)]
        public int PetBreedId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Pet level (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "petLevel", IsRequired = false)]
        public int PetLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// Pet quality (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "petQualityId", IsRequired = false)]
        public ItemQuality PetQuality
        {
            get;
            internal set;
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