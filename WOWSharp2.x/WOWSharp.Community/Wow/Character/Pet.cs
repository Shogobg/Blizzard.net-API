using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// A battle pet
	/// </summary>
	[DataContract]
    public class Pet
    {
        /// <summary>
        ///   gets or sets battlePet guid
        /// </summary>
        [DataMember(Name = "battlePetGuid", IsRequired = false)]
        public string BattlePetGuid
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the pet can battle
        /// </summary>
        [DataMember(Name = "canBattle", IsRequired = false)]
        public bool CanBattle
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets creature id
        /// </summary>
        [DataMember(Name = "creatureId", IsRequired = false)]
        public int CreatureId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets creature name
        /// </summary>
        [DataMember(Name = "creatureName", IsRequired = false)]
        public string CreatureName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether this pet is player's favourite
        /// </summary>
        [DataMember(Name = "isFavorite", IsRequired = false)]
        public bool IsFavorite
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets item id
        /// </summary>
        [DataMember(Name = "itemId", IsRequired = false)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets quality of the pet
        /// </summary>
        [DataMember(Name = "qualityId", IsRequired = false)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets spell id
        /// </summary>
        [DataMember(Name = "spellId", IsRequired = false)]
        public int SpellId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's status
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public PetStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether first ability slot is selected
        /// </summary>
        [DataMember(Name = "isFirstAbilitySlotSelected", IsRequired = false)]
        public bool IsFirstAbilitySlotSelected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether second ability slot is selected
        /// </summary>
        [DataMember(Name = "isSecondAbilitySlotSelected", IsRequired = false)]
        public bool IsSecondAbilitySlotSelected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether first ability slot is selected
        /// </summary>
        [DataMember(Name = "isThirdAbilitySlotSelected", IsRequired = false)]
        public bool IsThirdAbilitySlotSelected
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
            return Name;
        }
    }
}