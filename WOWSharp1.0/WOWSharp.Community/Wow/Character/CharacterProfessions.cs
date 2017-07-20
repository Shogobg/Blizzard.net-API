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

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents all professions learned by a character
    /// </summary>
    [DataContract]
    public class CharacterProfessions
    {
        /// <summary>
        ///   Primary professions
        /// </summary>
        private IList<CharacterProfession> _primaryProfessions;

        /// <summary>
        ///   Secondary professions
        /// </summary>
        private IList<CharacterProfession> _secondaryProfessions;

        /// <summary>
        ///   Gets or sets primary professions
        /// </summary>
        [DataMember(Name = "primary", IsRequired = false)]
        public IList<CharacterProfession> PrimaryProfessions
        {
            get
            {
                return _primaryProfessions;
            }
            internal set
            {
                _primaryProfessions = value;
            }
        }

        /// <summary>
        ///   Gets or sets secondary professions
        /// </summary>
        [DataMember(Name = "secondary", IsRequired = false)]
        public IList<CharacterProfession> SecondaryProfessions
        {
            get
            {
                return _secondaryProfessions;
            }
            internal set
            {
                _secondaryProfessions = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return PrimaryProfessions == null
                       ? ""
                       : string.Join(" and ", PrimaryProfessions.Select(p => p.Name).ToArray());
        }
    }
}