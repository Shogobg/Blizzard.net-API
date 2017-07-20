// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    [DataContract]
    public class GuildNewsItem
    {
        /// <summary>
        ///   achievement
        /// </summary>
        private Achievement _achievement;

        /// <summary>
        ///   name of the character to which the news item is related
        /// </summary>
        private string _characterName;

        /// <summary>
        ///   the type of the news item
        /// </summary>
        private GuildNewsItemType _guildNewsItemtype;

        /// <summary>
        ///   item id
        /// </summary>
        private int _itemId;

        /// <summary>
        ///   timestamp
        /// </summary>
        private long _timestamp;

        /// <summary>
        /// level up
        /// </summary>
        private int _levelUp;

        /// <summary>
        ///   gets or sets achievement
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get
            {
                return _achievement;
            }
            internal set
            {
                _achievement = value;
            }
        }

        /// <summary>
        ///   gets or sets item id
        /// </summary>
        [DataMember(Name = "itemId", IsRequired = false)]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            internal set
            {
                _itemId = value;
            }
        }

        /// <summary>
        ///   gets or sets name of the character to which the news item is related
        /// </summary>
        [DataMember(Name = "character", IsRequired = false)]
        public string CharacterName
        {
            get
            {
                return _characterName;
            }
            internal set
            {
                _characterName = value;
            }
        }

        /// <summary>
        ///   gets or sets timestamp
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = false)]
        public long Timestamp
        {
            get
            {
                return _timestamp;
            }
            internal set
            {
                _timestamp = value;
            }
        }

        /// <summary>
        ///   Event date in Utc
        /// </summary>
        public DateTime DateTimeUtc
        {
            get
            {
                return ApiClient.GetUtcDateFromUnixTime(_timestamp);
            }
        }

        /// <summary>
        /// Level up
        /// </summary>
        [DataMember(Name="levelUp", IsRequired = false)]
        public int LevelUp
        {
            get
            {
                return _levelUp;
            }
            internal set
            {
                _levelUp = value;
            }
        }

        /// <summary>
        ///   gets or sets name of the type of the news item
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public string GuildNewsItemTypeName
        {
            get
            {
                return EnumHelper<GuildNewsItemType>.EnumToString(_guildNewsItemtype);
            }
            internal set
            {
                _guildNewsItemtype = EnumHelper<GuildNewsItemType>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   gets or sets name of the type of the news item
        /// </summary>
        public GuildNewsItemType GuildNewsItemType
        {
            get
            {
                return _guildNewsItemtype;
            }
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