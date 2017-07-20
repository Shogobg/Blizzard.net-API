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

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   represents a guild member
    /// </summary>
    [DataContract]
    public class GuildMembership
    {
        /// <summary>
        ///   Gets or sets Character profile of the guild member (note that all optional character profile fields are not retrieved when getting guild's profile)
        /// </summary>
        private SimpleCharacter _character;

        /// <summary>
        ///   Gets or sets the character's rank in the guild. 0 is the highest rank (the guild master).
        /// </summary>
        private int _rank;

        /// <summary>
        ///   Gets or sets Character profile of the guild member (note that all optional character profile fields are not retrieved when getting guild's profile)
        /// </summary>
        [DataMember(Name = "character", IsRequired = true)]
        public SimpleCharacter Character
        {
            get
            {
                return _character;
            }
            internal set
            {
                _character = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's rank in the guild. 0 is the highest rank (the guild master).
        /// </summary>
        [DataMember(Name = "rank", IsRequired = true)]
        public int Rank
        {
            get
            {
                return _rank;
            }
            internal set
            {
                _rank = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Character == null ? "" : Character.ToString();
        }
    }
}