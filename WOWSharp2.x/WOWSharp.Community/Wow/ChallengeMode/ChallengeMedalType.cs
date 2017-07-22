using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   challenge mode reward type
	/// </summary>
	[DataContract]
    public enum ChallengeMedalType
    {
        /// <summary>
        ///   Consolation
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        ///   Consolation
        /// </summary>
        [EnumMember(Value = "CONSOLATION")]
        Consolation = 1,

        /// <summary>
        ///   Bronze
        /// </summary>
        [EnumMember(Value = "BRONZE")]
        Bronze = 2,

        /// <summary>
        ///   Silver
        /// </summary>
        [EnumMember(Value = "SILVER")]
        Silver = 3,

        /// <summary>
        ///   Gold
        /// </summary>
        [EnumMember(Value = "GOLD")]
        Gold = 4
    }
}