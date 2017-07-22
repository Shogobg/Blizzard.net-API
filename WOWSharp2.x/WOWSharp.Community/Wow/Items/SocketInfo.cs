
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents an item's socket info
    /// </summary>
    [DataContract]
    public class SocketInfo
    {
        /// <summary>
        ///   Gets or sets the socket bonus for the item
        /// </summary>
        [DataMember(Name = "socketBonus")]
        public string SocketBonus
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's sockets
        /// </summary>
        [DataMember(Name = "sockets", IsRequired = true)]
        public IList<Socket> Sockets
        {
            get;
            internal set;
        }
    }
}