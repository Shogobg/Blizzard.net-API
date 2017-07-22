using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Character class enumeration
	/// </summary>
	[DataContract]
    public enum ClassKey
    {
        /// <summary>
        ///   None
        /// </summary>
        None = 0,

        /// <summary>
        ///   Warrior
        /// </summary>
        [EnumMember(Value = "warrior")]
        Warrior = 1,

        /// <summary>
        ///   Paladin
        /// </summary>
        [EnumMember(Value = "paladin")]
        Paladin = 2,

        /// <summary>
        ///   Hunter
        /// </summary>
        [EnumMember(Value = "hunter")]
        Hunter = 3,

        /// <summary>
        ///   Rogue
        /// </summary>
        [EnumMember(Value = "rogue")]
        Rogue = 4,

        /// <summary>
        ///   Priest
        /// </summary>
        [EnumMember(Value = "priest")]
        Priest = 5,

        /// <summary>
        ///   Death Knight
        /// </summary>
        [EnumMember(Value = "death-knight")]
        DeathKnight = 6,

        /// <summary>
        ///   Shaman
        /// </summary>
        [EnumMember(Value = "shaman")]
        Shaman = 7,

        /// <summary>
        ///   Mage
        /// </summary>
        [EnumMember(Value = "mage")]
        Mage = 8,

        /// <summary>
        ///   Warlock
        /// </summary>
        [EnumMember(Value = "warlock")]
        Warlock = 9,

        /// <summary>
        ///   Monk
        /// </summary>
        [EnumMember(Value = "monk")]
        Monk = 10,

        /// <summary>
        ///   Druid
        /// </summary>
        [EnumMember(Value = "druid")]
        Druid = 11
    }
}