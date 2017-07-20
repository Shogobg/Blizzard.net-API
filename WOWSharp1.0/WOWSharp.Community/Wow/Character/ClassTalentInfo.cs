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
    [DataContract]
    public class ClassTalentInfo
    {
        /// <summary>
        ///   the class
        /// </summary>
        private ClassKey _classKey;

        /// <summary>
        ///   glyphs that this class can learn
        /// </summary>
        private IList<CharacterGlyph> _glyphs;

        /// <summary>
        ///   specializations that this class can learn
        /// </summary>
        private IList<Specialization> _specializations;

        /// <summary>
        ///   talents
        /// </summary>
        private IList<IList<CharacterTalent>> _talents;

        /// <summary>
        ///   gets or sets name of the class
        /// </summary>
        [DataMember(Name = "class", IsRequired = false)]
        public string ClassKeyName
        {
            get
            {
                return EnumHelper<ClassKey>.EnumToString(_classKey);
            }
            internal set
            {
                _classKey = EnumHelper<ClassKey>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   gets or sets name of the class
        /// </summary>
        public ClassKey ClassKey
        {
            get
            {
                return _classKey;
            }
        }


        /// <summary>
        ///   gets or sets glyphs that this class can learn
        /// </summary>
        [DataMember(Name = "glyphs", IsRequired = false)]
        public IList<CharacterGlyph> Glyphs
        {
            get
            {
                return _glyphs;
            }
            internal set
            {
                _glyphs = value;
            }
        }

        /// <summary>
        ///   gets or sets specializations that this class can learn
        /// </summary>
        [DataMember(Name = "specs", IsRequired = false)]
        public IList<Specialization> Specializations
        {
            get
            {
                return _specializations;
            }
            internal set
            {
                _specializations = value;
            }
        }

        /// <summary>
        ///   gets or sets talents
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures"), DataMember(Name = "talents", IsRequired = false)]
        public IList<IList<CharacterTalent>> Talents
        {
            get
            {
                return _talents;
            }
            internal set
            {
                _talents = value;
            }
        }
    }
}