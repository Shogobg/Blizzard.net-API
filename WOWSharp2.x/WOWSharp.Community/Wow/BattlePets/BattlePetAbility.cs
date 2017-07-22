using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   information about a battle pet ability
	/// </summary>
	[DataContract]
    public class BattlePetAbility : ApiResponse
    {
        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [DataMember(Name = "cooldown", IsRequired = false)]
        public int Cooldown
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability icon image
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether the ability is passive
        /// </summary>
        [DataMember(Name = "isPassive", IsRequired = false)]
        public bool IsPassive
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability name
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Id of the pet that can perform this ability
        /// </summary>
        [DataMember(Name = "petTypeId", IsRequired = false)]
        public int PetTypeId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability rounds
        /// </summary>
        [DataMember(Name = "rounds", IsRequired = false)]
        public int Rounds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether to show hints for ability
        /// </summary>
        [DataMember(Name = "showHints", IsRequired = false)]
        public bool ShowHints
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [DataMember(Name = "order", IsRequired = false)]
        public int Order
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability required level
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = false)]
        public int RequiredLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Ability slot
        /// </summary>
        [DataMember(Name = "slot", IsRequired = false)]
        public int Slot
        {
            get;
            internal set;
        }

        /// <summary>
        /// Whether to show or hide hints
        /// </summary>
        [DataMember(Name = "hideHints", IsRequired = false)]
        public bool HideHints
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