using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents the list of recently generated AH dumps
	/// </summary>
	[DataContract]
    internal class AuctionFilesResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the list of recently generated files
        /// </summary>
        [DataMember(Name = "files", IsRequired = true)]
        public IList<AuctionFile> Files
        {
            get;
            internal set;
        }
    }
}