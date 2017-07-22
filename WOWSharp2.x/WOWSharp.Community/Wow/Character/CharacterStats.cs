
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        ///   Gets or sets character's max health points
        /// </summary>
        [DataMember(Name = "health", IsRequired = true)]
        public int Health
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's power type
        /// </summary>
        [DataMember(Name = "powerType", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerType PowerType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's max power
        /// </summary>
        [DataMember(Name = "power", IsRequired = true)]
        public int Power
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's strength
        /// </summary>
        [DataMember(Name = "str", IsRequired = true)]
        public int Strength
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's agility
        /// </summary>
        [DataMember(Name = "agi", IsRequired = true)]
        public int Agility
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's stamina
        /// </summary>
        [DataMember(Name = "sta", IsRequired = true)]
        public int Stamina
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's intellect
        /// </summary>
        [DataMember(Name = "int", IsRequired = true)]
        public int Intellect
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spirit
        /// </summary>
        [DataMember(Name = "spr", IsRequired = true)]
        public int Spirit
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's melee attack power
        /// </summary>
        [DataMember(Name = "attackPower", IsRequired = true)]
        public int MeleeAttackPower
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged attack power
        /// </summary>
        [DataMember(Name = "rangedAttackPower", IsRequired = true)]
        public int RangedAttackPower
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's mastery
        /// </summary>
        [DataMember(Name = "mastery", IsRequired = false)]
        public double Mastery
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's mastery rating
        /// </summary>
        [DataMember(Name = "masteryRating", IsRequired = false)]
        public int MasteryRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's melee crit chance
        /// </summary>
        [DataMember(Name = "crit", IsRequired = true)]
        public double MeleeCritChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's melee crit rating
        /// </summary>
        [DataMember(Name = "critRating", IsRequired = true)]
        public int CritRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's hit rating
        /// </summary>
        [DataMember(Name = "hitRating", IsRequired = true)]
        public int HitRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's hit percentage
        /// </summary>
        [DataMember(Name = "hitPercent", IsRequired = true)]
        public double HitPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's haste rating
        /// </summary>
        [DataMember(Name = "hasteRating", IsRequired = true)]
        public int HasteRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's melee haste percentage from haste rating
        /// </summary>
        [DataMember(Name = "hasteRatingPercent", IsRequired = true)]
        public double HasteRatingPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's total melee haste percentage
        /// </summary>
        [DataMember(Name = "haste", IsRequired = true)]
        public double HastePercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's expertise rating
        /// </summary>
        [DataMember(Name = "expertiseRating", IsRequired = true)]
        public int ExpertiseRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell power
        /// </summary>
        [DataMember(Name = "spellPower", IsRequired = true)]
        public int SpellPower
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell penetration
        /// </summary>
        [DataMember(Name = "spellPen", IsRequired = true)]
        public int SpellPenetration
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell crit chance
        /// </summary>
        [DataMember(Name = "spellCrit", IsRequired = true)]
        public double SpellCritChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell crit rating
        /// </summary>
        [DataMember(Name = "spellCritRating", IsRequired = true)]
        public int SpellCritRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell hit percentage
        /// </summary>
        [DataMember(Name = "spellHitPercent", IsRequired = true)]
        public double SpellHitPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell hit rating
        /// </summary>
        [DataMember(Name = "spellHitRating", IsRequired = true)]
        public int SpellHitRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell haste rating
        /// </summary>
        [DataMember(Name = "spellHasteRating", IsRequired = true)]
        public int SpellHasteRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's spell haste percentage from haste rating
        /// </summary>
        [DataMember(Name = "spellHasteRatingPercent", IsRequired = true)]
        public double SpellHasteRatingPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's total spell haste 
        /// </summary>
        [DataMember(Name = "spellHaste", IsRequired = true)]
        public double SpellHastePercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character mana regeneration out of combat
        /// </summary>
        [DataMember(Name = "mana5", IsRequired = true)]
        public double ManaPer5
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's mana regeneration in combat
        /// </summary>
        [DataMember(Name = "mana5Combat", IsRequired = true)]
        public double ManaPer5Combat
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = true)]
        public int Armor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's dodge chance
        /// </summary>
        [DataMember(Name = "dodge", IsRequired = true)]
        public double DodgeChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's dodge rating
        /// </summary>
        [DataMember(Name = "dodgeRating", IsRequired = true)]
        public int DodgeRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's parry chance
        /// </summary>
        [DataMember(Name = "parry", IsRequired = true)]
        public double ParryChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's parry rating
        /// </summary>
        [DataMember(Name = "parryRating", IsRequired = true)]
        public int ParryRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's block chance
        /// </summary>
        [DataMember(Name = "block", IsRequired = true)]
        public double BlockChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's block rating
        /// </summary>
        [DataMember(Name = "blockRating", IsRequired = true)]
        public int BlockRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence
        /// </summary>
        [DataMember(Name = "pvpResilience", IsRequired = true)]
        public double PvpResilience
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence rating
        /// </summary>
        [DataMember(Name = "pvpResilienceRating", IsRequired = true)]
        public int PvpResilienceRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence bonus
        /// </summary>
        [DataMember(Name = "pvpResilienceBonus", IsRequired = true)]
        public double PvpResilienceBonus
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMin", IsRequired = true)]
        public double MainHandDamageMin
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum main hand melee weapon damage
        /// </summary>
        [DataMember(Name = "mainHandDmgMax", IsRequired = true)]
        public double MainHandDamageMax
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Get or sets the character's main hand weapon speed
        /// </summary>
        [DataMember(Name = "mainHandSpeed", IsRequired = true)]
        public double MainHandSpeed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon damage per second
        /// </summary>
        [DataMember(Name = "mainHandDps", IsRequired = true)]
        public double MainHandDps
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon expertise
        /// </summary>
        [DataMember(Name = "mainHandExpertise", IsRequired = true)]
        public double MainHandExpertise
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMin", IsRequired = true)]
        public double OffhandDamageMin
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum off hand weapon damage
        /// </summary>
        [DataMember(Name = "offHandDmgMax", IsRequired = true)]
        public double OffhandDamageMax
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon speed
        /// </summary>
        [DataMember(Name = "offHandSpeed", IsRequired = true)]
        public double OffhandSpeed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon damage per second
        /// </summary>
        [DataMember(Name = "offHandDps", IsRequired = true)]
        public double OffhandDps
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon expertise
        /// </summary>
        [DataMember(Name = "offHandExpertise", IsRequired = true)]
        public double OffhandExpertise
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMin", IsRequired = true)]
        public double RangedDamageMin
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum ranged weapon damage
        /// </summary>
        [DataMember(Name = "rangedDmgMax", IsRequired = true)]
        public double RangedDamageMax
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged weason speed
        /// </summary>
        [DataMember(Name = "rangedSpeed", IsRequired = true)]
        public double RangedSpeed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged haste percentage from haste rating
        /// </summary>
        [DataMember(Name = "rangedHasteRatingPercent", IsRequired = true)]
        public double RangedHasteRatingPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's total ranged haste percentage
        /// </summary>
        [DataMember(Name = "rangedHaste", IsRequired = true)]
        public double RangedHastePercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged haste percentage
        /// </summary>
        [DataMember(Name = "rangedHasteRating", IsRequired = true)]
        public int RangedHasteRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged weapon damage per second
        /// </summary>
        [DataMember(Name = "rangedDps", IsRequired = true)]
        public double RangedDps
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged expertise
        /// </summary>
        [DataMember(Name = "rangedExpertise", IsRequired = true)]
        public double RangedExpertise
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit chance
        /// </summary>
        [DataMember(Name = "rangedCrit", IsRequired = true)]
        public double RangedCritChance
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit rating
        /// </summary>
        [DataMember(Name = "rangedCritRating", IsRequired = true)]
        public int RangedCritRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged hit rating
        /// </summary>
        [DataMember(Name = "rangedHitRating", IsRequired = true)]
        public int RangedHitRating
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's hit percentage
        /// </summary>
        [DataMember(Name = "rangedHitPercent", IsRequired = true)]
        public double RangedHitPercent
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power
        /// </summary>
        [DataMember(Name = "pvpPower", IsRequired = true)]
        public double PvpPower
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power damage bonus
        /// </summary>
        [DataMember(Name = "pvpPowerDamage", IsRequired = true)]
        public double PvpPowerDamage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp healing bonus
        /// </summary>
        [DataMember(Name = "pvpPowerHealing", IsRequired = true)]
        public double PvpPowerHealing
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power rating
        /// </summary>
        [DataMember(Name = "pvpPowerRating", IsRequired = true)]
        public int PvpPowerRating
        {
            get;
            internal set;
        }
    }
}