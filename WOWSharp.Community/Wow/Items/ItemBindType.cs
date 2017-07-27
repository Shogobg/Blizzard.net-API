using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   An enumeration for item bind types
	/// </summary>
	[DataContract]
    public enum ItemBindType
    {
        /// <summary>
        ///   Item does not bind
        /// </summary>
        [EnumMember(Value = "Unbound")]
        Unbound = 0,

        /// <summary>
        ///   Item becomes soulbound when it's picked up
        /// </summary>
        [EnumMember(Value = "BindOnPickup")]
        BindOnPickup = 1,

        /// <summary>
        ///   Item becomes soulbound when equipped for the first time
        /// </summary>
        [EnumMember(Value = "BindOnEquipped")]
        BindOnEquipped = 2,

        /// <summary>
        ///   Item becomes soulbound when used for the first time
        /// </summary>
        [EnumMember(Value = "BindOnUse")]
        BindOnUse = 3,

        /// <summary>
        ///   Item is bound to the owner's battle.net account
        /// </summary>
        [EnumMember(Value = "BindToAccount")]
        BindToAccount = 4
    }
}