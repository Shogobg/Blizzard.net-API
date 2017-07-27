using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// An item set bonus
	/// </summary>
	[DataContract]
    public class ItemSetBonus
    {
		/// <summary>
		/// Number of set items required to activate the set bonus
		/// </summary>
		[DataMember(Name = "required")]
		public int Required
		{
			get;
			internal set;
		}

		/// <summary>
		/// A user readable list of attributes in the locale specified by the client
		/// </summary>
		[DataMember(Name = "attributes")]
        public ItemAttributes Attributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attributes in locale independent format
        /// </summary>
        [DataMember(Name = "attributesRaw")]
        public IDictionary<string, AttributeValue> RawAttributes
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
            return Attributes.ToString();
        }
    }
}
