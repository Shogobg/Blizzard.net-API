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
    ///   Represents a guild perk
    /// </summary>
    [DataContract]
    public class GuildPerk
    {
        /// <summary>
        ///   Gets or sets the perk's guild level
        /// </summary>
        private int _guildLevel;

        /// <summary>
        ///   Gets or sets the perk's spell
        /// </summary>
        private Spell _spell;

        /// <summary>
        ///   Gets or sets the perk's guild level
        /// </summary>
        [DataMember(Name = "guildLevel", IsRequired = true)]
        public int GuildLevel
        {
            get
            {
                return _guildLevel;
            }
            internal set
            {
                _guildLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the perk's spell
        /// </summary>
        [DataMember(Name = "spell", IsRequired = false)]
        public Spell Spell
        {
            get
            {
                return _spell;
            }
            internal set
            {
                _spell = value;
            }
        }

        /// <summary>
        ///   String representation for debug purposes
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return Spell == null ? "" : Spell.ToString();
        }
    }
}