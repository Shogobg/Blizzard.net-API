using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about character's combat pets (for classes with pets)
	/// </summary>
	[DataContract]
    public class HunterPet
    {
        /// <summary>
        ///   Gets or sets the pet name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the creature type
        /// </summary>
        [DataMember(Name = "creature", IsRequired = true)]
        public int CreatureId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the creature family id
        /// </summary>
        [DataMember(Name = "familyId", IsRequired = true)]
        public int FamilyId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the creature family name
        /// </summary>
        [DataMember(Name = "familyName", IsRequired = true)]
        public string FamilyName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether the character currently has that creature selected
        /// </summary>
        [DataMember(Name = "selected", IsRequired = false)]
        public bool IsSelected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the pet slot (no clue what that is) TODO: Find out what this field does.
        /// </summary>
        [DataMember(Name = "slot", IsRequired = true)]
        public int Slot
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the specialization for the pet
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
        [DataMember(Name = "calcSpec")]
        public string CalculatorSpecialization
        {
            get;
            internal set;
        }
    }
}