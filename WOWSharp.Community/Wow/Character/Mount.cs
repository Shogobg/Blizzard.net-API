using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   information about a mount
	/// </summary>
	[DataContract]
    public class Mount
    {
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
        ///   gets or sets icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the mount is aquatic
        /// </summary>
        [DataMember(Name = "isAquatic", IsRequired = false)]
        public bool IsAquatic
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the mount can fly
        /// </summary>
        [DataMember(Name = "isFlying", IsRequired = false)]
        public bool IsFlying
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the mount is a ground mount
        /// </summary>
        [DataMember(Name = "isGround", IsRequired = false)]
        public bool IsGround
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets whether the mount can jump
        /// </summary>
        [DataMember(Name = "isJumping", IsRequired = false)]
        public bool IsJumping
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets item id to learn the mount
        /// </summary>
        [DataMember(Name = "itemId", IsRequired = false)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of the mount
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets quality
        /// </summary>
        [DataMember(Name = "qualityId", IsRequired = false)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets spell id to summon the mount
        /// </summary>
        [DataMember(Name = "spellId", IsRequired = false)]
        public int SpellId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   name of the mount (For debugging purposes)
        /// </summary>
        /// <returns> string representation </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}