

using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A diablo hero class
	/// </summary>
	[DataContract]
    public enum HeroClass
    {
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Barbarian
        /// </summary>
        [EnumMember(Value = "barbarian")]
        Barbarian = 1,

        /// <summary>
        /// Demon hunter
        /// </summary>
        [EnumMember(Value = "demon-hunter")]
        DemonHunter = 2,

        /// <summary>
        /// Monk
        /// </summary>
        [EnumMember(Value = "monk")]
        Monk = 3,

        /// <summary>
        /// Witch Doctor
        /// </summary>
        [EnumMember(Value = "witch-doctor")]
        Witchdoctor = 4,
        
        /// <summary>
        /// Wizard
        /// </summary>
        [EnumMember(Value = "wizard")]
        Wizard = 5,

        /// <summary>
        /// Crusader
        /// </summary>
        [EnumMember(Value = "crusader")]
        Crusader = 6,

		/// <summary>
		/// Necromancer
		/// </summary>
		[EnumMember(Value = "necromancer")]
		Necromancer = 7
	}
}
