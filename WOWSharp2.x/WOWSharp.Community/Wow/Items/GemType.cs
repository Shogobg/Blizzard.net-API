
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Get type information
    /// </summary>
    [DataContract]
    public class GemType
    {
        /// <summary>
        ///   Gets or sets the gem type
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