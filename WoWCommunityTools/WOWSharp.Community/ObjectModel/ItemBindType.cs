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
    /// An enumeration for item bind types
    /// </summary>
    [Serializable]
    [DataContract]
    public enum ItemBindType
    {
        /// <summary>
        /// Item does not bind
        /// </summary>
        Unbound = 0,
        /// <summary>
        /// Item becomes soulbound when it's picked up
        /// </summary>
        BindOnPickup = 1,
        /// <summary>
        /// Item becomes soulbound when equipped for the first time
        /// </summary>
        BindOnEquipped = 2,
        /// <summary>
        /// Item becomes soulbound when used for the first time
        /// </summary>
        BindOnUse = 3,
        /// <summary>
        /// Item is bound to the owner's battle.net account
        /// </summary>
        BindToAccount = 4
    }
}
