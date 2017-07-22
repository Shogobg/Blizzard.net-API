using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item display color
	/// </summary>
	[DataContract]
    public enum ItemDisplayColor
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Gray (inferior)
        /// </summary>
        [EnumMember(Value = "gray")]
        Grey = 1,
        /// <summary>
        /// White (superior)
        /// </summary>
        [EnumMember(Value = "white")]
        White = 2,
        /// <summary>
        /// Blue (Magic)
        /// </summary>
        [EnumMember(Value = "blue")]
        Blue = 3,
        /// <summary>
        /// Yellow (Rare)
        /// </summary>
        [EnumMember(Value = "yellow")]
        Yellow = 4,
        /// <summary>
        /// Orange (Legendary)
        /// </summary>
        [EnumMember(Value = "orange")]
        Orange = 5,
        /// <summary>
        /// Green (Set)
        /// </summary>
        [EnumMember(Value = "green")]
        Green = 6
    }
}
