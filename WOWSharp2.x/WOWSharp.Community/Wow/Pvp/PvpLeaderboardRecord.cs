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

using System.Runtime.Serialization;
using System.Globalization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///  PVP Leader board entry (Arena or Battleground)
    /// </summary>
    [DataContract]
    public class PvpLeaderboardRecord
    {
        /// <summary>
        /// Gets or sets the player's character class
        /// </summary>
        [DataMember(Name = "classId", IsRequired = true)]
        public ClassKey Class
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character faction
        /// </summary>
        [DataMember(Name = "factionId", IsRequired = true)]
        public Faction Faction
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character gender
        /// </summary>
        [DataMember(Name = "genderId", IsRequired = true)]
        public CharacterGender Gender
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character race
        /// </summary>
        [DataMember(Name = "raceId", IsRequired = true)]
        public Race Race
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character ranking
        /// </summary>
        [DataMember(Name = "ranking", IsRequired = true)]
        public int Ranking
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character rating
        /// </summary>
        [DataMember(Name = "rating", IsRequired = true)]
        public int Rating
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character realm Id (the Realm ID is not used anywhere else in the APIs AFAIK)
        /// </summary>
        [DataMember(Name = "realmId", IsRequired = true)]
        public int RealmId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character realm name
        /// </summary>
        [DataMember(Name = "realmName", IsRequired = true)]
        public string RealmName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the player's character realm slug
        /// </summary>
        [DataMember(Name = "realmSlug", IsRequired = true)]
        public string RealmSlug
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets player's character specialization ID
        /// </summary>
        [DataMember(Name = "specId", IsRequired = true)]
        public int SpecId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonLosses", IsRequired = true)]
        public int SeasonLosses
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonWins", IsRequired = true)]
        public int SeasonWins
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyLosses", IsRequired = true)]
        public int WeeklyLosses
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyWins", IsRequired = true)]
        public int WeeklyWins
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}:{1}@{2}", Ranking, Name, RealmName);
        }
    }
}
