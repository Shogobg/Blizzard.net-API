using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Guild news item type
	/// </summary>
	[DataContract]
    public enum GuildNewsItemType
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        ///   Guild achievement
        /// </summary>
        [EnumMember(Value = "guildAchievement")]
        GuildAchievement = 0x1,

        /// <summary>
        ///   Player achievement
        /// </summary>
        [EnumMember(Value = "playerAchievement")]
        PlayerAchievement = 0x2,

        /// <summary>
        ///   Item purchase
        /// </summary>
        [EnumMember(Value = "itemPurchase")]
        ItemPurchase = 0x3,

        /// <summary>
        ///   Item loot
        /// </summary>
        [EnumMember(Value = "itemLoot")]
        ItemLoot = 0x4,

        /// <summary>
        ///   Item craft
        /// </summary>
        [EnumMember(Value = "itemCraft")]
        ItemCraft = 0x5,

        /// <summary>
        ///   Guild Level
        /// </summary>
        [EnumMember(Value = "guildLevel")]
        GuildLevelUp = 0x6
    }
}