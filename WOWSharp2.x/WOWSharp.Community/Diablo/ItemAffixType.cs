using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	[DataContract]
    public enum ItemAffixType
    {
        /// <summary>
        /// none
        /// </summary>
        [DataMember(Name = "none")]
        None = 0,

        /// <summary>
        /// default
        /// </summary>
        [DataMember(Name = "default")]
        Default = 1,

        /// <summary>
        /// utility
        /// </summary>
        [DataMember(Name = "utility")]
        Utility = 2,

        /// <summary>
        /// enchant
        /// </summary>
        [DataMember(Name = "enchant")]
        Enchant = 3,
    }
}
