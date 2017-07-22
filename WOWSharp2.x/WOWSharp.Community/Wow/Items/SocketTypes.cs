
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Socket types
    /// </summary>
    [Flags]
    [DataContract]
    public enum SocketTypes
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "None")]
        None = 0,

        /// <summary>
        ///   red
        /// </summary>
        [EnumMember(Value = "RED")]
        Red = 1,

        /// <summary>
        ///   Yellow
        /// </summary>
        [EnumMember(Value = "YELLOW")]
        Yellow = 2,

        /// <summary>
        ///   Blue
        /// </summary>
        [EnumMember(Value = "BLUE")]
        Blue = 4,

        /// <summary>
        ///   Meta
        /// </summary>
        [EnumMember(Value = "META")]
        Meta = 8,

        /// <summary>
        ///   Cog Wheel
        /// </summary>
        [EnumMember(Value = "COGWHEEL")]
        Cogwheel = 16,

        /// <summary>
        ///   Cog Wheel
        /// </summary>
        [EnumMember(Value = "HYDRAULIC")]
        Hydraulic = 32,

        /// <summary>
        ///   Prismatic
        /// </summary>
        [EnumMember(Value = "PRISMATIC")]
        Prismatic = Blue | Yellow | Red,

        /// <summary>
        ///   Orange
        /// </summary>
        [EnumMember(Value = "ORANGE")]
        Orange = Yellow | Red,

        /// <summary>
        ///   Purple
        /// </summary>
        [EnumMember(Value = "PURPLE")]
        Purple = Blue | Red,

        /// <summary>
        ///   Green
        /// </summary>
        [EnumMember(Value = "GREEN")]
        Green = Blue | Yellow
    }
}