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