using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   An enurmation representing a character's power type
	/// </summary>
	[DataContract]
    public enum PowerType
    {
        /// <summary>
        ///   Mana
        /// </summary>
        [EnumMember(Value = "mana")]
        Mana,

        /// <summary>
        ///   Energy
        /// </summary>
        [EnumMember(Value = "energy")]
        Energy,

        /// <summary>
        ///   Rage
        /// </summary>
        [EnumMember(Value = "rage")]
        Rage,

        /// <summary>
        ///   Runic power
        /// </summary>
        [EnumMember(Value = "runic-power")]
        RunicPower,

        /// <summary>
        ///   Focus
        /// </summary>
        [EnumMember(Value = "focus")]
        Focus
    }
}