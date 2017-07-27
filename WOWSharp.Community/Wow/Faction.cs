using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a character's or guild's faction
	/// </summary>
	[DataContract]
    public enum Faction
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "none")]
        None = -1,

        /// <summary>
        ///   Neutral
        /// </summary>
        [EnumMember(Value = "neutral")]
        Neutral = -1,

        /// <summary>
        ///   Alliance
        /// </summary>
        [EnumMember(Value = "alliance")]
        Alliance = 0,

        /// <summary>
        ///   Horde (Loktar Ogar! Victory or Death! For the Horde!)
        /// </summary>
        [EnumMember(Value = "horde")]
        Horde = 1,
    }
}