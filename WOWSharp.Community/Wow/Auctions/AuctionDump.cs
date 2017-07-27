using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a realm auctions dump
	/// </summary>
	[DataContract]
    public class AuctionDump : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the realm for which the dump belongs (note that realm type, status and queue are not retrieved)
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public Realm Realm
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the alliance auction house data
        /// </summary>
        [DataMember(Name = "alliance", IsRequired = true)]
        public AuctionHouse Alliance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the horde auction house data
        /// </summary>
        [DataMember(Name = "horde", IsRequired = true)]
        public AuctionHouse Horde
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the neutral auction house data
        /// </summary>
        [DataMember(Name = "neutral", IsRequired = true)]
        public AuctionHouse Neutral
        {
            get;
            internal set;
        }
    }
}