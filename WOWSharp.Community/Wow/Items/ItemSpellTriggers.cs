
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Item spell trigger types
    /// </summary>
    [DataContract]
    [Flags]
    public enum ItemSpellTriggers
    {
        /// <summary>
        ///   none
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        ///   on equip
        /// </summary>
        [EnumMember(Value = "ON_EQUIP")]
        Equipped = 1,

        /// <summary>
        ///   on use
        /// </summary>
        [EnumMember(Value = "ON_USE")]
        Use = 2,

        /// <summary>
        ///   Proc
        /// </summary>
        [EnumMember(Value = "ON_PROC")]
        Proc = 4,

        /// <summary>
        ///   On Pickup
        /// </summary>
        [EnumMember(Value = "ON_PICKUP")]
        Pickup = 8,

        /// <summary>
        ///   On learn
        /// </summary>
        [EnumMember(Value = "ON_LEARN")]
        Learn = 16
    }
}