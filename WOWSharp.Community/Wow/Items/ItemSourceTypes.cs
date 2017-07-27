
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Item source types
    /// </summary>
    [Flags]
    [DataContract]
    public enum ItemSourceTypes
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        ///   Creature Drop
        /// </summary>
        [EnumMember(Value = "CREATURE_DROP")]
        CreatureDrop = 1,

        /// <summary>
        ///   Game object drop
        /// </summary>
        [EnumMember(Value = "GAME_OBJECT_DROP")]
        GameObjectDrop = 2,

        /// <summary>
        ///   Quest Reward
        /// </summary>
        [EnumMember(Value = "REWARD_FOR_QUEST")]
        QuestReward = 4,

        /// <summary>
        ///   Faction Reward
        /// </summary>
        [EnumMember(Value = "FACTION_REWARD")]
        FactionReward = 8,

        /// <summary>
        ///   crafted
        /// </summary>
        [EnumMember(Value = "CREATED_BY_SPELL")]
        Crafted = 16,

        /// <summary>
        ///   achievement
        /// </summary>
        [EnumMember(Value = "ACHIEVEMENT_REWARD")]
        Achievement = 32
    }
}