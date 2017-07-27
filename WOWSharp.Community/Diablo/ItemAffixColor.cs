using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item affix color
	/// </summary>
	[DataContract]
    public enum ItemAffixColor
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        /// Blue (magical affix)
        /// </summary>
        [EnumMember(Value = "none")]
        Blue = 1,

        /// <summary>
        /// Orange (legendary)
        /// </summary>
        [EnumMember(Value = "orange")]
        Orange = 2
    }
}
