
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Realm population enumeration
    /// </summary>
    [DataContract]
    public enum RealmPopulation
    {
        /// <summary>
        ///   Low
        /// </summary>
        [EnumMember(Value = "n/a")]
        Unknown,

        /// <summary>
        ///   Low
        /// </summary>
        [EnumMember(Value = "low")]
        Low,

        /// <summary>
        ///   Medium
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,

        /// <summary>
        ///   High
        /// </summary>
        [EnumMember(Value = "high")]
        High,

        /// <summary>
        ///   High
        /// </summary>
        [EnumMember(Value = "full")]
        Full
    }
}