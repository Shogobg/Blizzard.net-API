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
        ///   Gets or sets the major glyphs being used
        /// </summary>
        [DataMember(Name = "major", IsRequired = false)]
        public IList<CharacterGlyph> MajorGlyphs
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the minor glyphs being used
        /// </summary>
        [DataMember(Name = "minor", IsRequired = false)]
        public IList<CharacterGlyph> MinorGlyphs
        {
            get;
            internal set;
        }
    }
}