
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Enumeration representing all realm types
	/// </summary>
	[Flags]
    public enum RealmTypes
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        ///   PVE (Normal) Realm
        /// </summary>
        [EnumMember(Value = "pve")]
        Pve = 1,

        /// <summary>
        ///   PVP (Player versus Player) Realm
        /// </summary>
        [EnumMember(Value = "pvp")]
        Pvp = 2,

        /// <summary>
        ///   Role Playing Realm
        /// </summary>
        [EnumMember(Value = "rp")]
        RP = 4,

        /// <summary>
        ///   Role Playing PVP Reaplm
        /// </summary>
        [EnumMember(Value = "rppvp")]
        RPPvp = 6
    }
}