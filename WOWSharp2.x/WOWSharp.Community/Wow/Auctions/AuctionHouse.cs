using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents an auction house date
	/// </summary>
	[DataContract]
    public class AuctionHouse
    {
        /// <summary>
        ///   Gets or sets the auctions
        /// </summary>
        [DataMember(Name = "auctions", IsRequired = true)]
        public IList<Auction> Auctions
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
            return string.Format(CultureInfo.CurrentCulture, "{0} auctions.", Auctions == null ? 0 : Auctions.Count);
        }
    }
}