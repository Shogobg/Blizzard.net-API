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
        ///   Gets or sets primary professions
        /// </summary>
        [DataMember(Name = "primary", IsRequired = false)]
        public IList<CharacterProfession> PrimaryProfessions
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets secondary professions
        /// </summary>
        [DataMember(Name = "secondary", IsRequired = false)]
        public IList<CharacterProfession> SecondaryProfessions
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
            return PrimaryProfessions == null
                       ? ""
                       : string.Join(" and ", PrimaryProfessions.Select(p => p.Name).ToArray());
        }
    }
}