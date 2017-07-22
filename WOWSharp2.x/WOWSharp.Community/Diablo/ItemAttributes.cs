using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item attributes
	/// </summary>
	[DataContract]
    public class ItemAttributes
    {
        /// <summary>
        /// passive item affixes
        /// </summary>
        [DataMember(Name = "passive")]
        public IList<ItemAffix> Passive
        {
            get;
            internal set;
        }

        /// <summary>
        /// primary item affixes
        /// </summary>
        [DataMember(Name = "primary")]
        public IList<ItemAffix> PrimaryAffixes
        {
            get;
            internal set;
        }

        /// <summary>
        /// secondary item affixes
        /// </summary>
        [DataMember(Name = "secondary")]
        public IList<ItemAffix> SecondaryAffixes
        {
            get;
            internal set;
        }

        
    }
}
