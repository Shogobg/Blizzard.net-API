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

using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents character's current stats
    /// </summary>
    [DataContract]
    public class CharacterStats
    {
        /// <summary>
        ///   Gets or sets the character's agility
        /// </summary>
        private int _agility;

        /// <summary>
        ///   Gets or sets the character's armor
        /// </summary>
        private int _armor;

        /// <summary>
        ///   Gets or sets the character's block chance
        /// </summary>
        private double _blockChance;

        /// <summary>
        ///   Gets or sets the character's block rating
        /// </summary>
        private int _blockRating;

        /// <summary>
        ///   Gets or sets the character's melee crit rating
        /// </summary>
        private int _critRating;

        /// <summary>
        ///   Gets or sets the character's dodge chance
        /// </summary>
        private double _dodgeChance;

        /// <summary>
        ///   Gets or sets the character's dodge rating
        /// </summary>
        private int _dodgeRating;

        /// <summary>
        ///   Gets or sets the character's expertise rating
        /// </summary>
        private int _expertiseRating;

        /// <summary>
        ///   Gets or sets the character's haste rating
        /// </summary>
        private int _hasteRating;

        /// <summary>
        ///   Gets or sets character's max health points
        /// </summary>
        private int _health;

        /// <summary>
        ///   Gets or sets the character's hit rating
        /// </summary>
        private int _hitRating;

        /// <summary>
        ///   Gets or sets the character's intellect
        /// </summary>
        private int _intellect;

        /// <summary>
        ///   Gets or sets the character's maximum main hand melee weapon damage
        /// </summary>
        private double _mainHandDamageMax;

        /// <summary>
        ///   Gets or sets the character's minimum main hand melee weapon damage
        /// </summary>
        private double _mainHandDamageMin;

        /// <summary>
        ///   Gets or sets the character's main hand weapon damage per second
        /// </summary>
        private double _mainHandDps;

        /// <summary>
        ///   Gets or sets the character's main hand weapon expertise
        /// </summary>
        private double _mainHandExpertise;

        /// <summary>
        ///   Get or sets the character's main hand weapon speed
        /// </summary>
        private double _mainHandSpeed;

        /// <summary>
        ///   Gets or sets the character mana regeneration out of combat
        /// </summary>
        private double _manaPer5;

        /// <summary>
        ///   Gets or sets the character's mana regeneration in combat
        /// </summary>
        private double _manaPer5Combat;

        /// <summary>
        ///   Gets or sets the character's mastery
        /// </summary>
        private double _mastery;

        /// <summary>
        ///   Gets or sets the character's mastery rating
        /// </summary>
        private int _masteryRating;

        /// <summary>
        ///   Gets or sets the character's melee attack power
        /// </summary>
        private int _meleeAttackPower;

        /// <summary>
        ///   Gets or sets the character's melee crit chance
        /// </summary>
        private double _meleeCritChance;

        /// <summary>
        ///   Gets or sets the character's maximum off hand weapon damage
        /// </summary>
        private double _offhandDamageMax;

        /// <summary>
        ///   Gets or sets the character's minimum off hand weapon damage
        /// </summary>
        private double _offhandDamageMin;

        /// <summary>
        ///   Gets or sets the character's off hand weapon damage per second
        /// </summary>
        private double _offhandDps;

        /// <summary>
        ///   Gets or sets the character's off hand weapon expertise
        /// </summary>
        private double _offhandExpertise;

        /// <summary>
        ///   Gets or sets the character's off hand weapon speed
        /// </summary>
        private double _offhandSpeed;

        /// <summary>
        ///   Gets or sets the character's parry chance
        /// </summary>
        private double _parryChance;

        /// <summary>
        ///   Gets or sets the character's parry rating
        /// </summary>
        private int _parryRating;

        /// <summary>
        ///   Gets or sets the character's max power
        /// </summary>
        private int _power;

        /// <summary>
        ///   Gets or sets the character's power type
        /// </summary>
        private PowerType _powerType;

        /// <summary>
        ///   Gets or sets the character's pvp power
        /// </summary>
        private double _pvpPower;

        /// <summary>
        ///   Gets or sets the character's pvp power rating
        /// </summary>
        private int _pvpPowerRating;

        /// <summary>
        ///   Gets or sets the character's pvp resilence
        /// </summary>
        private double _pvpResilience;

        /// <summary>
        ///   Gets or sets the character's pvp resilence rating
        /// </summary>
        private int _pvpResilienceRating;

        /// <summary>
        ///   Gets or sets the character's ranged attack power
        /// </summary>
        private int _rangedAttackPower;

        /// <summary>
        ///   Gets or sets the character's ranged crit chance
        /// </summary>
        private double _rangedCritChance;

        /// <summary>
        ///   Gets or sets the character's ranged crit rating
        /// </summary>
        private int _rangedCritRating;

        /// <summary>
        ///   Gets or sets the character's maximum ranged weapon damage
        /// </summary>
        private double _rangedDamageMax;

        /// <summary>
        ///   Gets or sets the character's minimum ranged weapon damage
        /// </summary>
        private double _rangedDamageMin;

        /// <summary>
        ///   Gets or sets the character's ranged weapon damage per second
        /// </summary>
        private double _rangedDps;

        /// <summary>
        ///   Gets or sets the character's ranged expertise
        /// </summary>
        private double _rangedExpertise;

        /// <summary>
        ///   Gets or sets the character's ranged hit rating
        /// </summary>
        private int _rangedHitRating;

        /// <summary>
        ///   Gets or sets the character's ranged weason speed
        /// </summary>
        private double _rangedSpeed;

        /// <summary>
        ///   Gets or sets the character's spell crit chance
        /// </summary>
        private double _spellCritChance;

        /// <summary>
        ///   Gets or sets the character's spell crit rating
        /// </summary>
        private int _spellCritRating;

        /// <summary>
        ///   Gets or sets the character's spell penetration
        /// </summary>
        private int _spellPenetration;

        /// <summary>
        ///   Gets or sets the character's spell power
        /// </summary>
        private int _spellPower;

        /// <summary>
        ///   Gets or sets the character's spirit
        /// </summary>
        private int _spirit;

        /// <summary>
        ///   Gets or sets the character's stamina
        /// </summary>
        private int _stamina;

        /// <summary>
        ///   Gets or sets the character's strength
        /// </summary>
        private int _strength;

        /// <summary>
        ///   Gets or sets character's max health points
        /// </summary>
        [DataMember(Name = "health", IsRequired = true)]
        public int Health
        {
            get
            {
                return _health;
            }
            internal set
            {
                _health = value;
            }
        }

        /// <summary>
        ///   Gets or sets  the character's power type name
        /// </summary>
        [DataMember(Name = "powerType", IsRequired = true)]
        public string PowerTypeName
        {
            get
            {
                return EnumHelper<PowerType>.EnumToString(PowerType);
            }
            internal set
            {
                PowerType = EnumHelper<PowerType>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   Gets or sets the character's power type
        /// </summary>
        public PowerType PowerType
        {
            get
            {
                return _powerType;
            }
            internal set
            {
                _powerType = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's max power
        /// </summary>
        [DataMember(Name = "power", IsRequired = true)]
        public int Power
        {
            get
            {
                return _power;
            }
            internal set
            {
                _power = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's strength
        /// </summary>
        [DataMember(Name = "str", IsRequired = true)]
        public int Strength
        {
            get
            {
                return _strength;
            }
            internal set
            {
                _strength = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's agility
        /// </summary>
        [DataMember(Name = "agi", IsRequired = true)]
        public int Agility
        {
            get
            {
                return _agility;
            }
            internal set
            {
                _agility = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's stamina
        /// </summary>
        [DataMember(Name = "sta", IsRequired = true)]
        public int Stamina
        {
            get
            {
                return _stamina;
            }
            internal set
            {
                _stamina = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's intellect
        /// </summary>
        [DataMember(Name = "int", IsRequired = true)]
        public int Intellect
        {
            get
            {
                return _intellect;
            }
            internal set
            {
                _intellect = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's spirit
        /// </summary>
        [DataMember(Name = "spr", IsRequired = true)]
        public int Spirit
        {
            get
            {
                return _spirit;
            }
            internal set
            {
                _spirit = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's melee attack power
        /// </summary>
        [DataMember(Name = "attackPower", IsRequired = true)]
        public int MeleeAttackPower
        {
            get
            {
                return _meleeAttackPower;
            }
            internal set
            {
                _meleeAttackPower = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged attack power
        /// </summary>
        [DataMember(Name = "rangedAttackPower", IsRequired = true)]
        public int RangedAttackPower
        {
            get
            {
                return _rangedAttackPower;
            }
            internal set
            {
                _rangedAttackPower = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's mastery
        /// </summary>
        [DataMember(Name = "mastery", IsRequired = false)]
        public double Mastery
        {
            get
            {
                return _mastery;
            }
            internal set
            {
                _mastery = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's mastery rating
        /// </summary>
        [DataMember(Name = "masteryRating", IsRequired = false)]
        public int MasteryRating
        {
            get
            {
                return _masteryRating;
            }
            internal set
            {
                _masteryRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's melee crit chance
        /// </summary>
        [DataMember(Name = "crit", IsRequired = true)]
        public double MeleeCritChance
        {
            get
            {
                return _meleeCritChance;
            }
            internal set
            {
                _meleeCritChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's melee crit rating
        /// </summary>
        [DataMember(Name = "critRating", IsRequired = true)]
        public int CritRating
        {
            get
            {
                return _critRating;
            }
            internal set
            {
                _critRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's hit rating
        /// </summary>
        [DataMember(Name = "hitRating", IsRequired = true)]
        public int HitRating
        {
            get
            {
                return _hitRating;
            }
            internal set
            {
                _hitRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's haste rating
        /// </summary>
        [DataMember(Name = "hasteRating", IsRequired = true)]
        public int HasteRating
        {
            get
            {
                return _hasteRating;
            }
            internal set
            {
                _hasteRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's expertise rating
        /// </summary>
        [DataMember(Name = "expertiseRating", IsRequired = true)]
        public int ExpertiseRating
        {
            get
            {
                return _expertiseRating;
            }
            internal set
            {
                _expertiseRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's spell power
        /// </summary>
        [DataMember(Name = "spellPower", IsRequired = true)]
        public int SpellPower
        {
            get
            {
                return _spellPower;
            }
            internal set
            {
                _spellPower = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's spell penetration
        /// </summary>
        [DataMember(Name = "spellPen", IsRequired = true)]
        public int SpellPenetration
        {
            get
            {
                return _spellPenetration;
            }
            internal set
            {
                _spellPenetration = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's spell crit chance
        /// </summary>
        [DataMember(Name = "spellCrit", IsRequired = true)]
        public double SpellCritChance
        {
            get
            {
                return _spellCritChance;
            }
            internal set
            {
                _spellCritChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's spell crit rating
        /// </summary>
        [DataMember(Name = "spellCritRating", IsRequired = true)]
        public int SpellCritRating
        {
            get
            {
                return _spellCritRating;
            }
            internal set
            {
                _spellCritRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character mana regeneration out of combat
        /// </summary>
        [DataMember(Name = "mana5", IsRequired = true)]
        public double ManaPer5
        {
            get
            {
                return _manaPer5;
            }
            internal set
            {
                _manaPer5 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's mana regeneration in combat
        /// </summary>
        [DataMember(Name = "mana5Combat", IsRequired = true)]
        public double ManaPer5Combat
        {
            get
            {
                return _manaPer5Combat;
            }
            internal set
            {
                _manaPer5Combat = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = true)]
        public int Armor
        {
            get
            {
                return _armor;
            }
            internal set
            {
                _armor = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's dodge chance
        /// </summary>
        [DataMember(Name = "dodge", IsRequired = true)]
        public double DodgeChance
        {
            get
            {
                return _dodgeChance;
            }
            internal set
            {
                _dodgeChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's dodge rating
        /// </summary>
        [DataMember(Name = "dodgeRating", IsRequired = true)]
        public int DodgeRating
        {
            get
            {
                return _dodgeRating;
            }
            internal set
            {
                _dodgeRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's parry chance
        /// </summary>
        [DataMember(Name = "parry", IsRequired = true)]
        public double ParryChance
        {
            get
            {
                return _parryChance;
            }
            internal set
            {
                _parryChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's parry rating
        /// </summary>
        [DataMember(Name = "parryRating", IsRequired = true)]
        public int ParryRating
        {
            get
            {
                return _parryRating;
            }
            internal set
            {
                _parryRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's block chance
        /// </summary>
        [DataMember(Name = "block", IsRequired = true)]
        public double BlockChance
        {
            get
            {
                return _blockChance;
            }
            internal set
            {
                _blockChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's block rating
        /// </summary>
        [DataMember(Name = "blockRating", IsRequired = true)]
        public int BlockRating
        {
            get
            {
                return _blockRating;
            }
            internal set
            {
                _blockRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence
        /// </summary>
        [DataMember(Name = "pvpResilience", IsRequired = true)]
        public double PvpResilience
        {
            get
            {
                return _pvpResilience;
            }
            internal set
            {
                _pvpResilience = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence rating
        /// </summary>
        [DataMember(Name = "pvpResilienceRating", IsRequired = true)]
        public int PvpResilienceRating
        {
            get
            {
                return _pvpResilienceRating;
            }
            internal set
            {
                _pvpResilienceRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's minimum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMin", IsRequired = true)]
        public double MainHandDamageMin
        {
            get
            {
                return _mainHandDamageMin;
            }
            internal set
            {
                _mainHandDamageMin = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's maximum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMax", IsRequired = true)]
        public double MainHandDamageMax
        {
            get
            {
                return _mainHandDamageMax;
            }
            internal set
            {
                _mainHandDamageMax = value;
            }
        }

        /// <summary>
        ///   Get or sets the character's main hand weapon speed
        /// </summary>
        [DataMember(Name = "mainHandSpeed", IsRequired = true)]
        public double MainHandSpeed
        {
            get
            {
                return _mainHandSpeed;
            }
            internal set
            {
                _mainHandSpeed = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon damage per second
        /// </summary>
        [DataMember(Name = "mainHandDps", IsRequired = true)]
        public double MainHandDps
        {
            get
            {
                return _mainHandDps;
            }
            internal set
            {
                _mainHandDps = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon expertise
        /// </summary>
        [DataMember(Name = "mainHandExpertise", IsRequired = true)]
        public double MainHandExpertise
        {
            get
            {
                return _mainHandExpertise;
            }
            internal set
            {
                _mainHandExpertise = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's minimum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMin", IsRequired = true)]
        public double OffhandDamageMin
        {
            get
            {
                return _offhandDamageMin;
            }
            internal set
            {
                _offhandDamageMin = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's maximum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMax", IsRequired = true)]
        public double OffhandDamageMax
        {
            get
            {
                return _offhandDamageMax;
            }
            internal set
            {
                _offhandDamageMax = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon speed
        /// </summary>
        [DataMember(Name = "offHandSpeed", IsRequired = true)]
        public double OffhandSpeed
        {
            get
            {
                return _offhandSpeed;
            }
            internal set
            {
                _offhandSpeed = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon damage per second
        /// </summary>
        [DataMember(Name = "offHandDps", IsRequired = true)]
        public double OffhandDps
        {
            get
            {
                return _offhandDps;
            }
            internal set
            {
                _offhandDps = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon expertise
        /// </summary>
        [DataMember(Name = "offHandExpertise", IsRequired = true)]
        public double OffhandExpertise
        {
            get
            {
                return _offhandExpertise;
            }
            internal set
            {
                _offhandExpertise = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's minimum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMin", IsRequired = true)]
        public double RangedDamageMin
        {
            get
            {
                return _rangedDamageMin;
            }
            internal set
            {
                _rangedDamageMin = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's maximum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMax", IsRequired = true)]
        public double RangedDamageMax
        {
            get
            {
                return _rangedDamageMax;
            }
            internal set
            {
                _rangedDamageMax = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged weason speed
        /// </summary>
        [DataMember(Name = "rangedSpeed", IsRequired = true)]
        public double RangedSpeed
        {
            get
            {
                return _rangedSpeed;
            }
            internal set
            {
                _rangedSpeed = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged weapon damage per second
        /// </summary>
        [DataMember(Name = "rangedDps", IsRequired = true)]
        public double RangedDps
        {
            get
            {
                return _rangedDps;
            }
            internal set
            {
                _rangedDps = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged expertise
        /// </summary>
        [DataMember(Name = "rangedExpertise", IsRequired = true)]
        public double RangedExpertise
        {
            get
            {
                return _rangedExpertise;
            }
            internal set
            {
                _rangedExpertise = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit chance
        /// </summary>
        [DataMember(Name = "rangedCrit", IsRequired = true)]
        public double RangedCritChance
        {
            get
            {
                return _rangedCritChance;
            }
            internal set
            {
                _rangedCritChance = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit rating
        /// </summary>
        [DataMember(Name = "rangedCritRating", IsRequired = true)]
        public int RangedCritRating
        {
            get
            {
                return _rangedCritRating;
            }
            internal set
            {
                _rangedCritRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's ranged hit rating
        /// </summary>
        [DataMember(Name = "rangedHitRating", IsRequired = true)]
        public int RangedHitRating
        {
            get
            {
                return _rangedHitRating;
            }
            internal set
            {
                _rangedHitRating = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's pvp power
        /// </summary>
        [DataMember(Name = "pvpPower", IsRequired = true)]
        public double PvpPower
        {
            get
            {
                return _pvpPower;
            }
            internal set
            {
                _pvpPower = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's pvp power rating
        /// </summary>
        [DataMember(Name = "pvpPowerRating", IsRequired = true)]
        public int PvpPowerRating
        {
            get
            {
                return _pvpPowerRating;
            }
            internal set
            {
                _pvpPowerRating = value;
            }
        }
    }
}