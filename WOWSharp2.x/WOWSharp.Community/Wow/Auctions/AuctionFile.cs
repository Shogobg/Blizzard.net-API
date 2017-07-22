
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents an auction house dump file
	/// </summary>
	[DataContract]
    internal class AuctionFile
    {
        /// <summary>
        ///   Gets or sets the dump file url
        /// </summary>
        [DataMember(Name = "url", IsRequired = true)]
        public string DownloadPath
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets the last modified date in UTC
        /// </summary>
        [DataMember(Name = "lastModified", IsRequired = true)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime LastModifiedUtc
        {
            get;
            internal set;
        }
    }
}