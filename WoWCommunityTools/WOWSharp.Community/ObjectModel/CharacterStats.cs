/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents character's current stats
    /// </summary>
    [DataContract]
    [Serializable]
    public class CharacterStats : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets character's max health points
        /// </summary>
        [DataMember(Name="health", IsRequired = true)]
        public int Health
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets  the character's power type name
        /// </summary>
        [DataMember(Name = "powerType", IsRequired = true)]
        public string PowerTypeName
        {
            get
            {
                return EnumHelper<PowerType>.EnumToString(this.PowerType);
            }
            set
            {
                this.PowerType = EnumHelper<PowerType>.ParseEnum(value);
            }
        }

        /// <summary>
        /// Gets or sets the character's power type
        /// </summary>
        public PowerType PowerType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's max power
        /// </summary>
        [DataMember(Name = "power", IsRequired = true)]
        public int Power
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's strength
        /// </summary>
        [DataMember(Name = "str", IsRequired = true)]
        public int Strength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's agility
        /// </summary>
        [DataMember(Name = "agi", IsRequired = true)]
        public int Agility
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's stamina
        /// </summary>
        [DataMember(Name = "sta", IsRequired = true)]
        public int Stamina
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's intellect
        /// </summary>
        [DataMember(Name = "int", IsRequired = true)]
        public int Intellect
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's spirit
        /// </summary>
        [DataMember(Name = "spr", IsRequired = true)]
        public int Spirit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's melee attack power
        /// </summary>
        [DataMember(Name = "attackPower", IsRequired = true)]
        public int MeleeAttackPower
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged attack power
        /// </summary>
        [DataMember(Name = "rangedAttackPower", IsRequired = true)]
        public int RangedAttackPower
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's mastery
        /// </summary>
        [DataMember(Name = "mastery", IsRequired = false)]
        public double Mastery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's mastery rating
        /// </summary>
        [DataMember(Name = "masteryRating", IsRequired = false)]
        public int MasteryRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's melee crit chance
        /// </summary>
        [DataMember(Name = "crit", IsRequired = true)]
        public double MeleeCritChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's melee crit rating
        /// </summary>
        [DataMember(Name = "critRating", IsRequired = true)]
        public int CritRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's hit rating
        /// </summary>
        [DataMember(Name = "hitRating", IsRequired = true)]
        public int HitRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's haste rating
        /// </summary>
        [DataMember(Name = "hasteRating", IsRequired = true)]
        public int HasteRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's expertise rating
        /// </summary>
        [DataMember(Name = "expertiseRating", IsRequired = true)]
        public int ExpertiseRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's spell power
        /// </summary>
        [DataMember(Name = "spellPower", IsRequired = true)]
        public int SpellPower
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's spell penetration
        /// </summary>
        [DataMember(Name = "spellPen", IsRequired = true)]
        public int SpellPenetration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's spell crit chance
        /// </summary>
        [DataMember(Name = "spellCrit", IsRequired = true)]
        public double SpellCritChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's spell crit rating
        /// </summary>
        [DataMember(Name = "spellCritRating", IsRequired = true)]
        public int SpellCritRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character mana regeneration out of combat
        /// </summary>
        [DataMember(Name = "mana5", IsRequired = true)]
        public double ManaPer5
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's mana regeneration in combat
        /// </summary>
        [DataMember(Name = "mana5Combat", IsRequired = true)]
        public double ManaPer5Combat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = true)]
        public int Armor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's dodge chance
        /// </summary>
        [DataMember(Name = "dodge", IsRequired = true)]
        public double DodgeChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's dodge rating
        /// </summary>
        [DataMember(Name = "dodgeRating", IsRequired = true)]
        public int DodgeRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's parry chance
        /// </summary>
        [DataMember(Name = "parry", IsRequired = true)]
        public double ParryChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's parry rating
        /// </summary>
        [DataMember(Name = "parryRating", IsRequired = true)]
        public int ParryRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's block chance
        /// </summary>
        [DataMember(Name = "block", IsRequired = true)]
        public double BlockChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's block rating
        /// </summary>
        [DataMember(Name = "blockRating", IsRequired = true)]
        public int BlockRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's resilence rating
        /// </summary>
        [DataMember(Name = "resil", IsRequired = true)]
        public int Resilience
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's minimum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMin", IsRequired = true)]
        public double MainHandDamageMin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's maximum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMax", IsRequired = true)]
        public double MainHandDamageMax
        {
            get;
            set;
        }

        /// <summary>
        /// Get or sets the character's main hand weapon speed
        /// </summary>
        [DataMember(Name = "mainHandSpeed", IsRequired = true)]
        public double MainHandSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's main hand weapon damage per second
        /// </summary>
        [DataMember(Name = "mainHandDps", IsRequired = true)]
        public double MainHandDps
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's main hand weapon expertise
        /// </summary>
        [DataMember(Name = "mainHandExpertise", IsRequired = true)]
        public int MainHandExpertise
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's minimum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMin", IsRequired = true)]
        public double OffHandDamageMin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's maximum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMax", IsRequired = true)]
        public double OffHandDamageMax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's off hand weapon speed
        /// </summary>
        [DataMember(Name = "offHandSpeed", IsRequired = true)]
        public double OffHandSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's off hand weapon damage per second
        /// </summary>
        [DataMember(Name = "offHandDps", IsRequired = true)]
        public double OffHandDps
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's off hand weapon expertise
        /// </summary>
        [DataMember(Name = "offHandExpertise", IsRequired = true)]
        public int OffHandExpertise
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character's minimum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMin", IsRequired = true)]
        public double RangedDamageMin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's maximum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMax", IsRequired = true)]
        public double RangedDamageMax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged weason speed
        /// </summary>
        [DataMember(Name = "rangedSpeed", IsRequired = true)]
        public double RangedSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged weapon damage per second
        /// </summary>
        [DataMember(Name = "rangedDps", IsRequired = true)]
        public double RangedDps
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged crit chance
        /// </summary>
        [DataMember(Name = "rangedCrit", IsRequired = true)]
        public double RangedCritChance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged crit rating
        /// </summary>
        [DataMember(Name = "rangedCritRating", IsRequired = true)]
        public double RangedCritRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's ranged hit rating
        /// </summary>
        [DataMember(Name = "rangedHitRating", IsRequired = true)]
        public double RangedHitRating
        {
            get;
            set;
        }
    }
}
