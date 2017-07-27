
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// Guild news feed entry
    /// </summary>
    [DataContract]
    public class GuildNewsItem
    {
        /// <summary>
        ///   gets or sets achievement
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets item id
        /// </summary>
        [DataMember(Name = "itemId", IsRequired = false)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of the character to which the news item is related
        /// </summary>
        [DataMember(Name = "character", IsRequired = false)]
        public string CharacterName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Event date in Utc
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime DateTimeUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Level up
        /// </summary>
        [DataMember(Name="levelUp", IsRequired = false)]
        public int LevelUp
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of the type of the news item
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public GuildNewsItemType GuildNewsItemType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            switch (GuildNewsItemType)
            {
                case GuildNewsItemType.GuildAchievement:
                    return "Guild Achievement: " + CharacterName + " " + Achievement;
                case GuildNewsItemType.PlayerAchievement:
                    return "Player Achievement: " + CharacterName + " " + Achievement;
                case GuildNewsItemType.ItemPurchase:
                    return "Item Purchase: " + CharacterName + ItemId;
                case GuildNewsItemType.ItemLoot:
                    return "Item Loot: " + CharacterName + ItemId;
                case GuildNewsItemType.ItemCraft:
                    return "Item Craft: " + CharacterName + ItemId;
                case GuildNewsItemType.GuildLevelUp:
                    return "Guild Level: " + LevelUp;
                default:
                    return GuildNewsItemType.ToString();
            }
        }
    }
}