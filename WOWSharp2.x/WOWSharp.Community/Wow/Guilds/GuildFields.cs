
using System;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   An enumeration to control the guild profile fields to retrieve
    /// </summary>
    [Flags]
    public enum GuildFields
    {
        /// <summary>
        ///   None
        /// </summary>
        None = 0,

        /// <summary>
        ///   Members
        /// </summary>
        Members = 0x1,

        /// <summary>
        ///   Achievements
        /// </summary>
        Achievements = 0x2,

        /// <summary>
        ///   Feed
        /// </summary>
        News = 0x4,

        /// <summary>
        ///   Challenge
        /// </summary>
        Challenge = 0x8,

        /// <summary>
        ///   All fields
        /// </summary>
        All = 0xF
    }
}