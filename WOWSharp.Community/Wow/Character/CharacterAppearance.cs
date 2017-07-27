using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Character's appeance information
	/// </summary>
	[DataContract]
    public class CharacterAppearance
    {
        /// <summary>
        ///   Gets or sets character's face variation (race dependent)
        /// </summary>
        [DataMember(Name = "faceVariation", IsRequired = true)]
        public int FaceVariation
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets character's skin color (race dependent)
        /// </summary>
        [DataMember(Name = "skinColor", IsRequired = true)]
        public int SkinColor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets character's hair variation (race dependent)
        /// </summary>
        [DataMember(Name = "hairVariation", IsRequired = true)]
        public int HairVariation
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets character's feature variation (race dependent)
        /// </summary>
        [DataMember(Name = "featureVariation", IsRequired = true)]
        public int FeatureVariation
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the character's helm should be shown.
        /// </summary>
        [DataMember(Name = "showHelm", IsRequired = false)]
        public bool ShowHelm
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the character's cloak should be shown.
        /// </summary>
        [DataMember(Name = "showCloak", IsRequired = false)]
        public bool ShowCloak
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets hair color for the character
        /// </summary>
        [DataMember(Name = "hairColor", IsRequired = false)]
        public int HairColor
        {
            get;
            internal set;
        }
    }
}