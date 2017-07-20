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
using System.Text.RegularExpressions;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents a character's arena team information
    /// </summary>
    [Serializable]
    [DataContract]
    public class CharacterArenaTeam : BaseExtensibleDataObject
    {
        /// <summary>
        /// A regex to parse team size
        /// </summary>
        private static readonly Regex _teamSizeParser = new Regex(@"^(\d)v\1$", RegexOptions.CultureInvariant);
        
        /// <summary>
        /// Gets or sets the battleground name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's personal rating in that team
        /// </summary>
        [DataMember(Name = "personalRating", IsRequired = false)]
        public int PersonalRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the teams rating
        /// </summary>
        [DataMember(Name = "teamRating", IsRequired = false)]
        public int TeamRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the arena team size
        /// </summary>
        [DataMember(Name = "size", IsRequired = false)]
        public string TeamSizeName
        {
            get
            {
                string ts = this.TeamSize.ToString(CultureInfo.InvariantCulture);
                return ts + "v" + ts;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.TeamSize = 0;
                Match m = _teamSizeParser.Match(value);
                if (!m.Success)
                    throw new ArgumentException(ErrorMessages.InvalidArenaTeamSize, "value");
                this.TeamSize = int.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets or set the arena team size
        /// </summary>
        public int TeamSize
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
            return string.Format("Team {0}, Size {1}, Rating {2}, Personal Rating {3}",
                this.Name, this.TeamSizeName, this.TeamRating, this.PersonalRating);
        }
    }
}
