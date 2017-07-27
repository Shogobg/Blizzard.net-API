using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// PvP leader board type
	/// </summary>
	[DataContract]
    public enum PvpBracket
    {
        /// <summary>
        ///  None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        ///  Arena 2v2 bracker
        /// </summary>
        [EnumMember(Value = "2v2")]
        Arena2v2,

        /// <summary>
        /// Arena 3v3 bracket
        /// </summary>
        [EnumMember(Value = "3v3")]
        Arena3v3,

        /// <summary>
        /// Arena 5v5 bracket
        /// </summary>
        [EnumMember(Value = "5v5")]
        Arena5v5,

        /// <summary>
        /// Rated battle grounds
        /// </summary>
        [EnumMember(Value = "rbg")]
        RatedBattleground
    }
}
