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
    /// An enumeration representing item quality
    /// </summary>
    public enum ItemQuality
    {
        /// <summary>
        /// Poor (Grey)
        /// </summary>
        Poor = 0,
        /// <summary>
        /// Common (White)
        /// </summary>
        Common = 1,
        /// <summary>
        /// Uncommon (Green)
        /// </summary>
        Uncommon = 2,
        /// <summary>
        /// Rare (Blue)
        /// </summary>
        Rare = 3,
        /// <summary>
        /// Epic (Purple)
        /// </summary>
        Epic = 4,
        /// <summary>
        /// Legendary (Orange)
        /// </summary>
        Legendary = 5,
        /// <summary>
        /// Artifact (Golden)
        /// </summary>
        Artifact = 6,
        /// <summary>
        /// Heirloom (Golden)
        /// </summary>
        Heirloom = 7
    }
}
