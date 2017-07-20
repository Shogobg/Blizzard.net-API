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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Base class for character and guild feeds
    /// </summary>
    [DataContract]
    public class FeedItem
    {
        /// <summary>
        ///   gets or sets name of the feed item type
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedItemType FeedItemType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets the time the event occured
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime TimeUtc
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
        ///   gets or sets achievement
        /// </summary>
        [DataMember(Name = "achievement", IsRequired = false)]
        public Achievement Achievement
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets criteria completed
        /// </summary>
        [DataMember(Name = "criteria", IsRequired = false)]
        public AchievementCriterion Criteria
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether this is a feat of stregth
        /// </summary>
        [DataMember(Name = "featOfStrength", IsRequired = false)]
        public bool FeatOfStrength
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the name of the event
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets quantity (number of times the boss was killed)
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = false)]
        public int Quantity
        {
            get;
            internal set;
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            switch (FeedItemType)
            {
                case FeedItemType.BossKill:
                    return FeedItemType.ToString() + ": " + Achievement.Description;
                case FeedItemType.Achievement:
                    return FeedItemType.ToString() + ": " + Achievement.Description;
                case FeedItemType.Loot:
                    return FeedItemType.ToString() + ": " + ItemId;
                case FeedItemType.Criteria:
                    return FeedItemType.ToString() + ": " + Criteria.Description;
                default:
                    return FeedItemType.ToString();
            }
        }
    }
}