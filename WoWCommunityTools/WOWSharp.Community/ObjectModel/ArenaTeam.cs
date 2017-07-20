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
using System.Globalization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents arena team information
    /// </summary>
    [DataContract]
    [Serializable]
    public class ArenaTeam : ApiResponse
    {
        /// <summary>
        /// Gets or sets the team's realm
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's ranking
        /// </summary>
        [DataMember(Name = "ranking", IsRequired = true)]
        public string Ranking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's rating
        /// </summary>
        [DataMember(Name = "rating", IsRequired = true)]
        public string Rating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's size
        /// </summary>
        [DataMember(Name = "teamsize", IsRequired = true)]
        public int TeamSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's creation date (format yyyy-MM-dd)
        /// </summary>
        [DataMember(Name = "created", IsRequired = true)]
        public string CreateDateString
        {
            get
            {
                return this.CreateDate.ToString("yyyy-MM-dd");
            }
            set
            {
                this.CreateDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets or sets the team's creation date
        /// </summary>
        public DateTime CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's games played this week
        /// </summary>
        [DataMember(Name = "gamesPlayed", IsRequired = true)]
        public int WeekGamesPlayed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's games won this week
        /// </summary>
        [DataMember(Name = "gamesWon", IsRequired = true)]
        public int WeekGamesWon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's games lost this week
        /// </summary>
        [DataMember(Name = "gamesLost", IsRequired = true)]
        public int WeekGamesLost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's seaon games played
        /// </summary>
        [DataMember(Name = "sessionGamesPlayed", IsRequired = true)]
        public int SeasonGamesPlayed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's season games won
        /// </summary>
        [DataMember(Name = "sessionGamesWon", IsRequired = true)]
        public int SeasonGamesWon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's season games lost
        /// </summary>
        [DataMember(Name = "sessionGamesLost", IsRequired = true)]
        public int SeasonGamesLost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's last session ranking
        /// </summary>
        [DataMember(Name = "lastSessionRanking", IsRequired = true)]
        public int LastSessionRanking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's side name
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
        /// gets or sets the team's faction
        /// </summary>
        public Faction Side
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's current week ranking
        /// </summary>
        [DataMember(Name = "currentWeekRanking", IsRequired = true)]
        public int CurrentWeekRanking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team's members
        /// </summary>
        [DataMember(Name = "members", IsRequired = true)]
        public ArenaTeamMember[] Members
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
            return string.Format("{1}vs{1} Team: {0}@{2}", this.Name, this.TeamSize, this.Realm);
        }
    }
}
