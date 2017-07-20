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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Gets or sets information about character glyphs used by a talent specialization
    /// </summary>
    [DataContract]
    public class CharacterGlyphs
    {
        /// <summary>
        ///   MajorGlyphs field
        /// </summary>
        private IList<CharacterGlyph> _majorGlyphs;

        /// <summary>
        ///   MinorGlyphs field
        /// </summary>
        private IList<CharacterGlyph> _minorGlyphs;

        /// <summary>
        ///   Gets or sets the major glyphs being used
        /// </summary>
        [DataMember(Name = "major", IsRequired = false)]
        public IList<CharacterGlyph> MajorGlyphs
        {
            get
            {
                return _majorGlyphs;
            }
            internal set
            {
                _majorGlyphs = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minor glyphs being used
        /// </summary>
        [DataMember(Name = "minor", IsRequired = false)]
        public IList<CharacterGlyph> MinorGlyphs
        {
            get
            {
                return _minorGlyphs;
            }
            internal set
            {
                _minorGlyphs = value;
            }
        }
    }
}