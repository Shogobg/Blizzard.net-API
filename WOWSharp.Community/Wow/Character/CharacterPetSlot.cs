using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   character pet slot
	/// </summary>
	[DataContract]
    public class CharacterPetSlot
    {
        /// <summary>
        ///   gets or sets ability ids
        /// </summary>
        [DataMember(Name = "abilities", IsRequired = false)]
        public IList<int> Abilities
        {
            get;
            internal set;
        }
        
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
        ///   gets or sets whether the slot is empty
        /// </summary>
        [DataMember(Name = "isEmpty", IsRequired = false)]
        public bool IsEmpty
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the slot is locked
        /// </summary>
        [DataMember(Name = "isLocked", IsRequired = false)]
        public bool IsLocked
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets slot number
        /// </summary>
        [DataMember(Name = "slot", IsRequired = false)]
        public int Slot
        {
            get;
            internal set;
        }
    }
}