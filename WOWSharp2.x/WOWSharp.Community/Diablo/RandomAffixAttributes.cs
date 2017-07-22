using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Random affix attributes
	/// </summary>
	[DataContract]
    public class RandomAffixAttributes
    {
        /// <summary>
        /// random affix attributes
        /// </summary>
        [DataMember(Name = "attributes")]
        public ItemAttributes Attributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item raw attributes
        /// </summary>
        [DataMember(Name = "attributesRaw")]
        public IDictionary<string, AttributeValue> RawAttributes
        {
            get;
            internal set;
        }
    }
}
