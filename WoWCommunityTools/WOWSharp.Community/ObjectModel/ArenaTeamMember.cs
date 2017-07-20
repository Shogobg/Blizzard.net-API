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
    /// Represents an arena team member
    /// </summary>
    [DataContract]
    [Serializable]
    public class ArenaTeamMember : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the team member's character profile (note that only basic information is returned)
        /// A character profile request should be made to retrieve the rest of the information
        /// </summary>
        [DataMember(Name = "character", IsRequired = true)]
        public Character Character
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's games played this week
        /// </summary>
        [DataMember(Name = "gamesPlayed", IsRequired = true)]
        public int WeekGamesPlayed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's games won this week
        /// </summary>
        [DataMember(Name = "gamesWon", IsRequired = true)]
        public int WeekGamesWon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's games lost this week
        /// </summary>
        [DataMember(Name = "gamesLost", IsRequired = true)]
        public int WeekGamesLost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's season games played
        /// </summary>
        [DataMember(Name = "sessionGamesPlayed", IsRequired = true)]
        public int SeasonGamesPlayed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's season games won
        /// </summary>
        [DataMember(Name = "sessionGamesWon", IsRequired = true)]
        public int SeasonGamesWon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's season games lost
        /// </summary>
        [DataMember(Name = "sessionGamesLost", IsRequired = true)]
        public int SeasonGamesLost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the team member's personal rating
        /// </summary>
        [DataMember(Name = "personalRating", IsRequired = true)]
        public int PersonalRating
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
            return this.Character.ToString();
        }
    }
}
