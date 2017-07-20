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

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a guild's profile
    /// </summary>
    [DataContract]
    public class Guild : ApiResponse
    {
        /// <summary>
        ///   gets or sets the guild's total achievement points
        /// </summary>
        private int _achievementPoints;

        /// <summary>
        ///   Gets or sets information about guild's achievements
        /// </summary>
        private Achievements _achievements;

        /// <summary>
        ///   Gets or sets the guild's battlegroup name
        /// </summary>
        private string _battleGroupName;

        /// <summary>
        ///   information about challenges completed by the guild
        /// </summary>
        private IList<Challenge> _challenges;

        /// <summary>
        ///   Gets or sets the guild's emblem
        /// </summary>
        private GuildEmblem _emblem;

        /// <summary>
        ///   Gets or sets the guild's level
        /// </summary>
        private int _level;

        /// <summary>
        ///   Members field
        /// </summary>
        private IList<GuildMembership> _members;

        /// <summary>
        ///   Gets or sets the guild's name
        /// </summary>
        private string _name;

        /// <summary>
        ///   guild news feed
        /// </summary>
        private IList<GuildNewsItem> _news;

        /// <summary>
        ///   Gets or sets the guild's realm
        /// </summary>
        private string _realm;

        /// <summary>
        ///   gets or sets the guild's faction
        /// </summary>
        private Faction _side;

        /// <summary>
        ///   Gets or sets the guild's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's battlegroup name
        /// </summary>
        [DataMember(Name = "battlegroup", IsRequired = true)]
        public string BattleGroupName
        {
            get
            {
                return _battleGroupName;
            }
            internal set
            {
                _battleGroupName = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's realm
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get
            {
                return _realm;
            }
            internal set
            {
                _realm = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's emblem
        /// </summary>
        [DataMember(Name = "emblem", IsRequired = false)]
        public GuildEmblem Emblem
        {
            get
            {
                return _emblem;
            }
            internal set
            {
                _emblem = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get
            {
                return _level;
            }
            internal set
            {
                _level = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's side name
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        public string SideName
        {
            get
            {
                return EnumHelper<Faction>.EnumToString(Side);
            }
            internal set
            {
                Side = EnumHelper<Faction>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   gets or sets the guild's faction
        /// </summary>
        public Faction Side
        {
            get
            {
                return _side;
            }
            internal set
            {
                _side = value;
            }
        }

        /// <summary>
        ///   gets or sets the guild's total achievement points
        /// </summary>
        [DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get
            {
                return _achievementPoints;
            }
            internal set
            {
                _achievementPoints = value;
            }
        }

        /// <summary>
        ///   Gets or sets a list of all guild members
        /// </summary>
        [DataMember(Name = "members", IsRequired = false)]
        public IList<GuildMembership> Members
        {
            get
            {
                return _members;
            }
            internal set
            {
                _members = value;
            }
        }

        /// <summary>
        ///   Gets or sets information about guild's achievements
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get
            {
                return _achievements;
            }
            internal set
            {
                _achievements = value;
            }
        }

        /// <summary>
        ///   gets or sets guild news feed
        /// </summary>
        [DataMember(Name = "news", IsRequired = false)]
        public IList<GuildNewsItem> News
        {
            get
            {
                return _news;
            }
            internal set
            {
                _news = value;
            }
        }

        /// <summary>
        ///   gets or sets information about challenges completed by the guild
        /// </summary>
        [DataMember(Name = "challenge", IsRequired = false)]
        public IList<Challenge> Challenges
        {
            get
            {
                return _challenges;
            }
            internal set
            {
                _challenges = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }

        ///// <summary>
        /////   Performs additional processing after the guild information is deserialized
        ///// </summary>
        ///// <param name="client"> </param>
        //protected internal override void OnDeserialized(ApiClient client)
        //{
        //    base.OnDeserialized(client);
        //    if (Members != null)
        //    {
        //        //long lastModified = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        //        for (int i = 0; i < Members.Count; i++)
        //        {
        //            Character ch = Members[i].Character;
        //            ch.LastModifiedUtc = LastModifiedUtc;
        //            ch.Client = client;
        //            ch.Path = "/api/wow/character/" + WowClient.GetRealmSlug(ch.Realm) + "/" +
        //                      Uri.EscapeUriString(ch.Name);
        //            ch.OnDeserialized(client);
        //        }
        //    }
        //}
    }
}