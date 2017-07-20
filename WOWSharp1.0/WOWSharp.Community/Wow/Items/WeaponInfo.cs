// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
        private WeaponDamage _damage;

        /// <summary>
        ///   Gets or sets the weapon's DPS (damage per second)
        /// </summary>
        private double _damagePerSecond;

        /// <summary>
        ///   Gets or sets the weapon's speed
        /// </summary>
        private double _speed;

        /// <summary>
        ///   Gets or sets the weapon's damage
        /// </summary>
        [DataMember(Name = "damage", IsRequired = true)]
        public WeaponDamage Damage
        {
            get
            {
                return _damage;
            }
            internal set
            {
                _damage = value;
            }
        }

        /// <summary>
        ///   Gets or sets the weapon's speed
        /// </summary>
        [DataMember(Name = "weaponSpeed", IsRequired = true)]
        public double Speed
        {
            get
            {
                return _speed;
            }
            internal set
            {
                _speed = value;
            }
        }

        /// <summary>
        ///   Gets or sets the weapon's DPS (damage per second)
        /// </summary>
        [DataMember(Name = "dps", IsRequired = true)]
        public double DamagePerSecond
        {
            get
            {
                return _damagePerSecond;
            }
            internal set
            {
                _damagePerSecond = value;
            }
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