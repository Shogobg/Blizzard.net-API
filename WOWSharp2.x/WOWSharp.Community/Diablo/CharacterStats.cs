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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// Character statistics
    /// </summary>
    [DataContract]
    public class CharacterStats
    {
        /// <summary>
        /// Experience bonus
        /// </summary>
        [DataMember(Name = "experienceBonus")]
        public double ExperienceBonus
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gold find
        /// </summary>
        [DataMember(Name = "goldFind")]
        public double GoldFind
        {
            get;
            internal set;
        }

        /// <summary>
        /// Magic find
        /// </summary>
        [DataMember(Name = "magicFind")]
        public double MagicFind
        {
            get;
            internal set;
        }

        /// <summary>
        /// Arcane resistance
        /// </summary>
        [DataMember(Name = "arcaneResist")]
        public double ArcaneResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Armor
        /// </summary>
        [DataMember(Name = "armor")]
        public double Armor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attack speed
        /// </summary>
        [DataMember(Name = "attackSpeed")]
        public double AttackSpeed
        {
            get;
            internal set;
        }

        /// <summary>
        /// Maximum block amount
        /// </summary>
        [DataMember(Name = "blockAmountMax")]
        public double MaximumBlockAmount
        {
            get;
            internal set;
        }

        /// <summary>
        /// minimum block amount
        /// </summary>
        [DataMember(Name = "blockAmountMin")]
        public double MinimumBlockAmount
        {
            get;
            internal set;
        }

        /// <summary>
        /// block chance
        /// </summary>
        [DataMember(Name = "blockChance")]
        public double BlockChance
        {
            get;
            internal set;
        }

        /// <summary>
        /// cold resistance
        /// </summary>
        [DataMember(Name = "coldResist")]
        public double ColdResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// critical hit chance
        /// </summary>
        [DataMember(Name = "critChance")]
        public double CriticalHitChance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Critical hit damage bonux
        /// </summary>
        [DataMember(Name = "critDamage")]
        public double CriticalHitDamageBonus
        {
            get;
            internal set;
        }

        /// <summary>
        /// Weapon's damage per second taking passive skills, follower buffs,
        /// buffs active when logged out, strength, haste, crit chance, dual weild bonus
        /// and critical hit damage
        /// </summary>
        [DataMember(Name = "damage")]
        public double Damage
        {
            get;
            internal set;
        }

        /// <summary>
        /// damage increase from main stat
        /// </summary>
        [DataMember(Name = "damageIncrease")]
        public double DamageIncrease
        {
            get;
            internal set;
        }

        /// <summary>
        /// Damage reduction from armor
        /// </summary>
        [DataMember(Name = "damageReduction")]
        public double DamageReductionFromArmor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Dexterity
        /// </summary>
        [DataMember(Name = "dexterity")]
        public double Dexterity
        {
            get;
            internal set;
        }

        /// <summary>
        /// Fire resistance
        /// </summary>
        [DataMember(Name = "fireResist")]
        public double FireResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Intelligence
        /// </summary>
        [DataMember(Name = "intelligence")]
        public double Intelligence
        {
            get;
            internal set;
        }

        /// <summary>
        /// Maximum health points
        /// </summary>
        [DataMember(Name = "life")]
        public double MaximumHealthPoints
        {
            get;
            internal set;
        }

        /// <summary>
        /// Life on Hit (amount healed after each hit)
        /// AOE counts as a single hit
        /// Amount is multiplied by a skill coefficient
        /// </summary>
        [DataMember(Name = "lifeOnHit")]
        public double LifeOnHit
        {
            get;
            internal set;
        }

        /// <summary>
        /// Life healed after each kille
        /// </summary>
        [DataMember(Name = "lifePerKill")]
        public double LifePerKill
        {
            get;
            internal set;
        }

        /// <summary>
        /// Amount healed per damage dealt
        /// This is reduced in inferno by 80%
        /// In hell by 60%
        /// In Nightmare by 30%
        /// </summary>
        [DataMember(Name = "lifeSteal")]
        public double LifeSteal
        {
            get;
            internal set;
        }

        /// <summary>
        /// Lightning Resistance
        /// </summary>
        [DataMember(Name = "lightningResist")]
        public double LightningResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Physical Resistance
        /// </summary>
        [DataMember(Name = "physicalResist")]
        public double PhysicalResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Poison resist
        /// </summary>
        [DataMember(Name = "poisonResist")]
        public double PoisonResistance
        {
            get;
            internal set;
        }

        /// <summary>
        /// The maximum primary resource amount
        /// </summary>
        [DataMember(Name = "primaryResource")]
        public double PrimaryResourceMaximum
        {
            get;
            internal set;
        }

        /// <summary>
        /// the maximum secondary resource amount 
        /// (applies for demon hunter only for decipline)
        /// </summary>
        [DataMember(Name = "secondaryResource")]
        public double SecondaryResourceMaximum
        {
            get;
            internal set;
        }

        /// <summary>
        /// Strength
        /// </summary>
        [DataMember(Name = "strength")]
        public double Strength
        {
            get;
            internal set;
        }

        /// <summary>
        /// Thorns
        /// </summary>
        [DataMember(Name = "thorns")]
        public double Thorns
        {
            get;
            internal set;
        }

        /// <summary>
        /// Vitality
        /// </summary>
        [DataMember(Name = "vitality")]
        public double Vitality
        {
            get;
            internal set;
        }
    }
}
