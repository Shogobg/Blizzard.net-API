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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Globalization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// Represents information about a character's PVP performance
    /// </summary>
    [DataContract]
    public class CharacterPvpBracketInformation
    {
        /// <summary>
        ///  The player's character rating
        /// </summary>
        private int _rating;

        /// <summary>
        /// The number of games lost by the player's character during the current PvP season.
        /// </summary>
        private int _seasonLosses;

        /// <summary>
        ///  The number of games won by the player's character during the current PvP season.
        /// </summary>
        private int _seasonWins;

        /// <summary>
        ///  The number of games played by the player's character during the current PvP season.
        /// </summary>
        private int _seasonPlayed;

        /// <summary>
        /// The number of games lost by the player's character during the current week.
        /// </summary>
        private int _weeklyLosses;

        /// <summary>
        /// The number of games won by the player's character during the current week.
        /// </summary>
        private int _weeklyWins;

        /// <summary>
        /// The number of games played by the player's character during the current week.
        /// </summary>
        private int _weeklyPlayed;

        /// <summary>
        ///  The slug for the bracket
        /// </summary>
        private string _slug;

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
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonLost", IsRequired = true)]
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
        [DataMember(Name = "seasonWon", IsRequired = true)]
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
        /// Gets or sets number of games played by the player's character during the current PVP season
        /// </summary>
        [DataMember(Name = "seasonPlayed", IsRequired = true)]
        public int SeasonPlayed
        {
            get
            {
                return _seasonPlayed;
            }
            internal set
            {
                _seasonPlayed = value;
            }
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyLost", IsRequired = true)]
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
        [DataMember(Name = "weeklyWon", IsRequired = true)]
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
        /// Gets or sets number of games played by the player's character during the current week
        /// </summary>
        [DataMember(Name = "weeklyPlayed", IsRequired = true)]
        public int WeeklyPlayed
        {
            get
            {
                return _weeklyPlayed;
            }
            internal set
            {
                _weeklyPlayed = value;
            }
        }

        /// <summary>
        /// Gets or sets the slug of the PVP bracket
        /// </summary>
        [DataMember(Name = "slug", IsRequired = true)]
        public string Slug
        {
            get
            {
                return _slug;
            }
            internal set
            {
                _slug = value;
            }
        }

        /// <summary>
        /// Gets or sets the PvP bracket type
        /// </summary>
        public PvpBracket PvpBracket
        {
            get
            {
                return EnumHelper<PvpBracket>.ParseEnum(_slug);
            }
            internal set
            {
                _slug = EnumHelper<PvpBracket>.EnumToString(value);
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} rating: {1}", PvpBracket, Rating);
        }
    }
}
