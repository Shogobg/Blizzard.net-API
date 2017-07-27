
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a weapon's damage
    /// </summary>
    [DataContract]
    public class WeaponDamage
    {
        /// <summary>
        ///   Gets or sets the maximum weapon damage
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int MaximumDamage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the minimum weapon damage
        /// </summary>
        [DataMember(Name = "min", IsRequired = true)]
        public int MinimumDamage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the exact maximum weapon damage
        /// </summary>
        [DataMember(Name = "exactMax", IsRequired = true)]
        public double ExactMaximumDamage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the exact minimum weapon damage
        /// </summary>
        [DataMember(Name = "exactMin", IsRequired = true)]
        public double ExactMinimumDamage
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
            return string.Format(CultureInfo.CurrentCulture, "{0} - {1}", MinimumDamage, MaximumDamage);
        }
    }
}