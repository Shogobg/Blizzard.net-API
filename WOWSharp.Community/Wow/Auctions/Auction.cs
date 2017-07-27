
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