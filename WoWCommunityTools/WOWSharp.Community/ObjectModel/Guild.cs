/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents a guild's profile
    /// </summary>
    [Serializable]
    [DataContract]
    public class Guild : ApiResponse
    {
        /// <summary>
        /// Gets or sets the guild's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the guild's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the guild's side name
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        public string SideName
        {
            get
            {
                return EnumHelper<Faction>.EnumToString(this.Side);
            }
            set
            {
                this.Side = EnumHelper<Faction>.ParseEnum(value);
            }
        }

        /// <summary>
        /// gets or sets the guild's faction
        /// </summary>
        public Faction Side
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the guild's total achievement points
        /// </summary>
        [DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a list of all guild members
        /// </summary>
        [DataMember(Name = "members", IsRequired = false)]
        public GuildMembership[] Members
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about guild's achievements
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get;
            set;
        }


        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Performs additional processing after the guild information is deserialized
        /// </summary>
        /// <param name="client"></param>
        protected internal override void OnDeserialized(ApiClient client)
        {
            base.OnDeserialized(client);
            if (this.Members != null)
            {
                //long lastModified = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                for (int i = 0; i < this.Members.Length; i++)
                {
                    Character ch = this.Members[i].Character;
                    ch.LastModifiedUtc = this.LastModifiedUtc;
                    ch.Client = client;
                    ch.Path = "/api/wow/character/" + client.GetRealmSlug(ch.Realm) + "/" + Uri.EscapeUriString(ch.Name);
                    ch.OnDeserialized(client);
                }
            }
        }
    }
}
