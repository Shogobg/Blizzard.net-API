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