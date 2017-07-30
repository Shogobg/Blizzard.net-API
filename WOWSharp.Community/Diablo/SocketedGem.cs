using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Socketed gem
	/// </summary>
	[DataContract]
    public class SocketedGem
    {
        /// <summary>
        /// A user readable list of attributes in the locale specified by the client
        /// For a socket gem, the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributes")]
        public ItemAttributes Attributes
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
        /// The gem item
        /// </summary>
        [DataMember(Name = "item", IsRequired = false)]
        public Item Item
        {
            get;
            internal set;
        }

		/// <summary>
		/// IsGem
		/// </summary>
		[DataMember(Name = "isGem", IsRequired = false)]
		public bool IsGem
		{
			get;
			internal set;
		}

		/// <summary>
		/// IsJewel
		/// </summary>
		[DataMember(Name = "isJewel", IsRequired = false)]
		public bool IsJewel
		{
			get;
			internal set;
		}

		/// <summary>
		/// String representation for debug purposes
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
            return Item == null ? "" : Item.ToString();
        }
    }
}
