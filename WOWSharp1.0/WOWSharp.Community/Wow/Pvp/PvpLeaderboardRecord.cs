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
        ///  The player character class
        /// </summary>
        private ClassKey _class;

        /// <summary>
        ///  The player character faction
        /// </summary>
        private Faction _faction;

        /// <summary>
        ///  The player character gender
        /// </summary>
        private CharacterGender _gender;

        /// <summary>
        ///  The player character name
        /// </summary>
        private string _name;

        /// <summary>
        ///  The player's character race
        /// </summary>
        private Race _race;

        /// <summary>
        ///  The player's character ranking
        /// </summary>
        private int _ranking;

        /// <summary>
        ///  The player's character rating
        /// </summary>
        private int _rating;

        /// <summary>
        ///  The player's character realm ID (the ID is not used anywhere else in the API afaik)
        /// </summary>
        private int _realmId;

        /// <summary>
        ///  The player's character realm
        /// </summary>
        private string _realmName;

        /// <summary>
        ///  The player's character realm slug
        /// </summary>
        private string _realmSlug;

        /// <summary>
        /// The number of games lost by the player's character during the current PvP season.
        /// </summary>
        private int _seasonLosses;

        /// <summary>
        ///  The number of games won by the player's character during the current PvP season.
        /// </summary>
        private int _seasonWins;

        /// <summary>
        /// The player's character spec Id
        /// </summary>
        private int _specId;

        /// <summary>
        /// The number of games lost by the player's character during the current week.
        /// </summary>
        private int _weeklyLosses;

        /// <summary>
        /// The number of games won by the player's character during the current week.
        /// </summary>
        private int _weeklyWins;

        /// <summary>
        /// Gets or sets the player's character class
        /// </summary>
        [DataMember(Name = "classId", IsRequired = true)]
        public ClassKey Class
        {
            get
            {
                return _class;
            }
            internal set
            {
                _class = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character faction
        /// </summary>
        [DataMember(Name = "factionId", IsRequired = true)]
        public Faction Faction
        {
            get
            {
                return _faction;
            }
            internal set
            {
                _faction = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character gender
        /// </summary>
        [DataMember(Name = "genderId", IsRequired = true)]
        public CharacterGender Gender
        {
            get
            {
                return _gender;
            }
            internal set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character name
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
        /// Gets or sets the player's character race
        /// </summary>
        [DataMember(Name = "raceId", IsRequired = true)]
        public Race Race
        {
            get
            {
                return _race;
            }
            internal set
            {
                _race = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character ranking
        /// </summary>
        [DataMember(Name = "ranking", IsRequired = true)]
        public int Ranking
        {
            get
            {
                return _ranking;
            }
            internal set
            {
                _ranking = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character rating
        /// </summary>
        [DataMember(Name = "rating", IsRequired = true)]
        public int Rating
        {
            get
            {
                return _rating;
            }
            internal set
            {
                _rating = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character realm Id (the Realm ID is not used anywhere else in the APIs AFAIK)
        /// </summary>
        [DataMember(Name = "realmId", IsRequired = true)]
        public int RealmId
        {
            get
            {
                return _realmId;
            }
            internal set
            {
                _realmId = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character realm name
        /// </summary>
        [DataMember(Name = "realmName", IsRequired = true)]
        public string RealmName
        {
            get
            {
                return _realmName;
            }
            internal set
            {
                _realmName = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's character realm slug
        /// </summary>
        [DataMember(Name = "realmSlug", IsRequired = true)]
        public string RealmSlug
        {
            get
            {
                return _realmSlug;
            }
            internal set
            {
                _realmSlug = value;
            }
        }

        /// <summary>
        /// Gets or sets player's character specialization ID
        /// </summary>
        [DataMember(Name = "specId", IsRequired = true)]
        public int SpecId
        {
            get
            {
                return _specId;
            }
            internal set
            {
                _specId = value;
            }
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonLosses", IsRequired = true)]
        public int SeasonLosses
        {
            get
            {
                return _seasonLosses;
            }
            internal set
            {
                _seasonLosses = value;
            }
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonWins", IsRequired = true)]
        public int SeasonWins
        {
            get
            {
                return _seasonWins;
            }
            internal set
            {
                _seasonWins = value;
            }
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyLosses", IsRequired = true)]
        public int WeeklyLosses
        {
            get
            {
                return _weeklyLosses;
            }
            internal set
            {
                _weeklyLosses = value;
            }
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyWins", IsRequired = true)]
        public int WeeklyWins
        {
            get
            {
                return _weeklyWins;
            }
            internal set
            {
                _weeklyWins = value;
            }
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}:{1}@{2}", _ranking, _name, _realmName);
        }
    }
}
