using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Follower type
	/// </summary>
	[DataContract]
    public enum FollowerType
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Templar
        /// </summary>
        [EnumMember(Value = "templar")]
        Templar = 1,
        /// <summary>
        /// Scoundrel
        /// </summary>
        [EnumMember(Value = "scoundrel")]
        Scoundrel = 2,
        /// <summary>
        /// Enchantress
        /// </summary>
        [EnumMember(Value = "enchantress")]
        Enchantress = 3
    }
}
