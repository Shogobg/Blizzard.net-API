using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about a glyph being used by a character
	/// </summary>
	[DataContract]
    public class CharacterGlyph
    {
        /// <summary>
        ///   gets or sets glyph id
        /// </summary>
        [DataMember(Name = "glyph", IsRequired = true)]
        public int GlyphId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets item id (of the glyph)
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets glyph name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets glyph's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets glyph type id (no idea what that is)
        /// </summary>
        [DataMember(Name = "typeId", IsRequired = false)]
        public int TypeId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Returns the name of the glyph (for debugging purposes)
        /// </summary>
        /// <returns> Returns the name of the glyph (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}