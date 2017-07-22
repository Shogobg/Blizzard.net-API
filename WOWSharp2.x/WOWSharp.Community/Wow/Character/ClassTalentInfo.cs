
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// Class talent information
    /// </summary>
    [DataContract]
    public class ClassTalentInfo
    {
        /// <summary>
        ///   gets or sets name of the class
        /// </summary>
        [DataMember(Name = "class", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassKey ClassKey
        {
            get;
            internal set;
        }


        /// <summary>
        ///   gets or sets glyphs that this class can learn
        /// </summary>
        [DataMember(Name = "glyphs", IsRequired = false)]
        public IList<CharacterGlyph> Glyphs
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet specializations that a hunter pet can learn
        ///   Will be null for classes other than hunter.
        /// </summary>
        [DataMember(Name = "petSpecs", IsRequired = false)]
        public IList<Specialization> PetSpecializations
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets specializations that this class can learn
        /// </summary>
        [DataMember(Name = "specs", IsRequired = false)]
        public IList<Specialization> Specializations
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets talents
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<IList<CharacterTalent>> Talents
        {
            get;
            internal set;
        }
    }
}