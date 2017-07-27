using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   information about a battle pet species
	/// </summary>
	[DataContract]
    public class BattlePetSpecies : ApiResponse
    {
        /// <summary>
        ///   Pet species abilities
        /// </summary>
        [DataMember(Name = "abilities", IsRequired = false)]
        public IList<BattlePetAbility> Abilities
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether the species can battle
        /// </summary>
        [DataMember(Name = "canBattle", IsRequired = false)]
        public bool CanBattle
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether creature id for the species
        /// </summary>
        [DataMember(Name = "creatureId", IsRequired = false)]
        public int CreatureId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [DataMember(Name = "description", IsRequired = false)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the pet's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet type id
        /// </summary>
        [DataMember(Name = "petTypeId", IsRequired = false)]
        public int PetTypeId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet's source
        /// </summary>
        [DataMember(Name = "source", IsRequired = false)]
        public string Source
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet's species id
        /// </summary>
        [DataMember(Name = "speciesId", IsRequired = false)]
        public int SpeciesId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Description;
        }
    }
}