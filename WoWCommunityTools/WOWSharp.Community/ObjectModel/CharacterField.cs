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

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Specifies flags that control which fields are retrieved when getting character information.
    /// </summary>
    [Flags]
    public enum CharacterField
    {
        /// <summary>
        /// No flags
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Should get guild information
        /// </summary>
        Guild = 0x1,
        /// <summary>
        /// Should get stats
        /// </summary>
        Stats = 0x2,
        /// <summary>
        /// Should get talents
        /// </summary>
        Talents = 0x4,
        /// <summary>
        /// Should get items
        /// </summary>
        Items = 0x8,
        /// <summary>
        /// Should get reputation
        /// </summary>
        Reputation = 0x10,
        /// <summary>
        /// Should get titles
        /// </summary>
        Titles = 0x20,
        /// <summary>
        /// Should get professions
        /// </summary>
        Professions = 0x40,
        /// <summary>
        /// Should get appearance
        /// </summary>
        Appearance = 0x80,
        /// <summary>
        /// Should get companions
        /// </summary>
        Companions = 0x100,
        /// <summary>
        /// Should get mounts
        /// </summary>
        Mounts = 0x200,
        /// <summary>
        /// Should get pets
        /// </summary>
        Pets = 0x400,
        /// <summary>
        /// Should get achievements
        /// </summary>
        Achievements = 0x800,
        /// <summary>
        /// Should get professions
        /// </summary>
        Progression = 0x1000,
        /// <summary>
        /// Should get Completed quests
        /// </summary>
        Quests = 0x2000,
        /// <summary>
        /// Should get PVP, Arena and Rated Battleground information
        /// </summary>
        Pvp = 0x4000,
        /// <summary>
        /// Should get all fields
        /// </summary>
        All = 0x7FFF
    }
}
