using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Charachter roles enumeration
	/// </summary>
	[Flags]
    [DataContract]
    public enum CharacterRoles
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        ///   Tank
        /// </summary>
        [EnumMember(Value = "TANK")]
        Tank = 1,

        /// <summary>
        ///   Healing
        /// </summary>
        [EnumMember(Value = "HEALING")]
        Healing = 2,

        /// <summary>
        ///   Damage dealer
        /// </summary>
        [EnumMember(Value = "DPS")]
        DPS = 4
    }
}