using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Effect applied when a gem in inserted into an item
	/// </summary>
	[DataContract]
    public class SocketEffect
    {
        /// <summary>
        /// A user readable list of attributes in the locale specified by the client
        /// For a socket gem, the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributes")]
        public IList<string> Attributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attributes in locale independent format
        /// the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributesRaw")]
        public IDictionary<string, AttributeValue> RawAttributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item type
        /// </summary>
        [DataMember(Name = "itemTypeId")]
        public ItemType ItemType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item type name
        /// </summary>
        [DataMember(Name = "itemTypeName")]
        public string ItemTypeName
        {
            get;
            internal set;
        }
    }
}
