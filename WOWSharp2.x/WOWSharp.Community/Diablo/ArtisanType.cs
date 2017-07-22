using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Artisan types
	/// </summary>
	[DataContract]
    public enum ArtisanType
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Blacksmith
        /// </summary>
        [EnumMember(Value = "blacksmith")]
        Blacksmith = 1,

        /// <summary>
        /// Jeweler
        /// </summary>
        [EnumMember(Value = "jeweler")]
        Jeweler = 2,

        /// <summary>
        /// Mystic.
        /// </summary>
        /// <remarks>
        /// This will be used in Reaper Of Souls
        /// </remarks>
        [EnumMember(Value = "mystic")]
        Mystic = 3
    }
}
