
using System;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Specifies flags that control which fields are retrieved when getting character information.
    /// </summary>
    [Flags]
    public enum CharacterFields
    {
        /// <summary>
        ///   No flags
        /// </summary>
        None = 0x0,

        /// <summary>
        ///   Should get guild information
        /// </summary>
        Guild = 0x1,

        /// <summary>
        ///   Should get stats
        /// </summary>
        Stats = 0x2,

        /// <summary>
        ///   Should get talents
        /// </summary>
        Talents = 0x4,

        /// <summary>
        ///   Should get items
        /// </summary>
        Items = 0x8,

        /// <summary>
        ///   Should get reputation
        /// </summary>
        Reputation = 0x10,

        /// <summary>
        ///   Should get titles
        /// </summary>
        Titles = 0x20,

        /// <summary>
        ///   Should get professions
        /// </summary>
        Professions = 0x40,

        /// <summary>
        ///   Should get appearance
        /// </summary>
        Appearance = 0x80,

        /// <summary>
        ///   Should get companions (battle pets)
        /// </summary>
        Pets = 0x100,

        /// <summary>
        ///   Should get mounts
        /// </summary>
        Mounts = 0x200,

        /// <summary>
        ///   Should get hunter pets
        /// </summary>
        HunterPets = 0x400,

        /// <summary>
        ///   Should get achievements
        /// </summary>
        Achievements = 0x800,

        /// <summary>
        ///   Should get professions
        /// </summary>
        Progression = 0x1000,

        /// <summary>
        ///   Should get Completed quests
        /// </summary>
        Quests = 0x2000,

        /// <summary>
        ///   Should get PVP, Arena and Rated Battleground information
        /// </summary>
        Pvp = 0x4000,

        /// <summary>
        ///   Should get PVP, Arena and Rated Battleground information
        /// </summary>
        Feed = 0x8000,

        /// <summary>
        ///   Should get pet slots
        /// </summary>
        PetSlots = 0x10000,

        /// <summary>
        ///   Should get character career statistics
        /// </summary>
        Statistics = 0x20000,

        /// <summary>
        ///   Should get all fields
        /// </summary>
        All = 0x3FFFF
    }
}