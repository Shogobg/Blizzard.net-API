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
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// Information about a character's performance in different PVP brackets
    /// </summary>
    [DataContract]
    public class CharacterPvpBrackets
    {
        /// <summary>
        /// Character's arena 2v2 bracket information
        /// </summary>
        private CharacterPvpBracketInformation _arena2v2;

        /// <summary>
        /// Character's arena 3v3 bracket information
        /// </summary>
        private CharacterPvpBracketInformation _arena3v3;

        /// <summary>
        /// Character's arena 5v5 bracket information
        /// </summary>
        private CharacterPvpBracketInformation _arena5v5;

        /// <summary>
        /// Character's rated battle ground bracket information
        /// </summary>
        private CharacterPvpBracketInformation _ratedBattleground;

        /// <summary>
        /// Gets or sets characters PVP 2v2 bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_2v2", IsRequired = true)]
        public CharacterPvpBracketInformation Arena2v2
        {
            get
            {
                return _arena2v2;
            }
            internal set
            {
                _arena2v2 = value;
            }
        }

        /// <summary>
        /// Gets or sets characters PVP 3v3 bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_3v3", IsRequired = true)]
        public CharacterPvpBracketInformation Arena3v3
        {
            get
            {
                return _arena3v3;
            }
            internal set
            {
                _arena3v3 = value;
            }
        }

        /// <summary>
        /// Gets or sets characters PVP 5v5 bracket information
        /// </summary>
        /// <remarks>It is spelt incorrectly in Blizzar's API (BRACKED instead of BRACKET)</remarks>
        [DataMember(Name = "ARENA_BRACKED_5v5", IsRequired = true)]
        public CharacterPvpBracketInformation Arena5v5
        {
            get
            {
                return _arena5v5;
            }
            internal set
            {
                _arena5v5 = value;
            }
        }

        /// <summary>
        /// Gets or sets characters PVP Rated battle ground bracket information
        /// </summary>
        [DataMember(Name = "ARENA_BRACKET_RBG", IsRequired = true)]
        public CharacterPvpBracketInformation RatedBattleground
        {
            get
            {
                return _ratedBattleground;
            }
            internal set
            {
                _ratedBattleground = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}, {1}, {2}, {3}", Arena2v2, Arena3v3, Arena5v5, RatedBattleground);
        }
    }
}
