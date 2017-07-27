
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about an item's socket type
    /// </summary>
    [DataContract]
    public class Socket
    {
        /// <summary>
        ///   Gets or sets the socket type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SocketTypes SocketType
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
            return SocketType.ToString();
        }
    }
}