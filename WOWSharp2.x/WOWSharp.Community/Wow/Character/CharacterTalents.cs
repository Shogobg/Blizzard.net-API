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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a character's talent specialization
    /// </summary>
    [DataContract]
    public class CharacterTalents
    {
        /// <summary>
        ///   Gets or sets whether this talent specialization is the currently selected specialization
        /// </summary>
        [DataMember(Name = "selected", IsRequired = false)]
        public bool IsSelected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   The characters talent build
        /// </summary>
        [DataMember(Name = "talents")]
        public IList<CharacterTalent> Build
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about the glyphs used in this specialization
        /// </summary>
        [DataMember(Name = "glyphs", IsRequired = false)]
        public CharacterGlyphs Glyphs
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the specialization for the character
        /// </summary>
        [DataMember(Name = "spec", IsRequired = false)]
        public Specialization Specialization
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [DataMember(Name = "calcTalent")]
        public string CalculatorTalent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [DataMember(Name = "calcSpec")]
        public string CalculatorSpecialization
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [DataMember(Name = "calcGlyph")]
        public string CalculatorGlyphs
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}", Specialization == null ? "" : Specialization.Name);
        }
    }
}