using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Feed item types
	/// </summary>
	[DataContract]
    public enum FeedItemType
    {
        /// <summary>
        ///   Feed item boss kill
        /// </summary>
        [EnumMember(Value = "BOSSKILL")]
        BossKill,

        /// <summary>
        ///   Feed item Achievement completed
        /// </summary>
        [EnumMember(Value = "ACHIEVEMENT")]
        Achievement,

        /// <summary>
        ///   Feed item loot
        /// </summary>
        [EnumMember(Value = "LOOT")]
        Loot,

        /// <summary>
        ///   achievement criteria
        /// </summary>
        [EnumMember(Value = "CRITERIA")]
        Criteria
    }
}