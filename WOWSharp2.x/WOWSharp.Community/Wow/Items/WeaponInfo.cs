
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about a weapon
    /// </summary>
    [DataContract]
    public class WeaponInfo
    {
        /// <summary>
        ///   Gets or sets the weapon's damage
        /// </summary>
        [DataMember(Name = "damage", IsRequired = true)]
        public WeaponDamage Damage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the weapon's speed
        /// </summary>
        [DataMember(Name = "weaponSpeed", IsRequired = true)]
        public double Speed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the weapon's DPS (damage per second)
        /// </summary>
        [DataMember(Name = "dps", IsRequired = true)]
        public double DamagePerSecond
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} {1}s ({2} dps)", Damage, Speed, DamagePerSecond);
        }
    }
}