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
    ///   Socket types
    /// </summary>
    [Flags]
    [DataContract]
    public enum SocketTypes
    {
        /// <summary>
        ///   None
        /// </summary>
        [EnumMember(Value = "None")]
        None = 0,

        /// <summary>
        ///   red
        /// </summary>
        [EnumMember(Value = "RED")]
        Red = 1,

        /// <summary>
        ///   Yellow
        /// </summary>
        [EnumMember(Value = "YELLOW")]
        Yellow = 2,

        /// <summary>
        ///   Blue
        /// </summary>
        [EnumMember(Value = "BLUE")]
        Blue = 4,

        /// <summary>
        ///   Meta
        /// </summary>
        [EnumMember(Value = "META")]
        Meta = 8,

        /// <summary>
        ///   Cog Wheel
        /// </summary>
        [EnumMember(Value = "COGWHEEL")]
        Cogwheel = 16,

        /// <summary>
        ///   Cog Wheel
        /// </summary>
        [EnumMember(Value = "HYDRAULIC")]
        Hydraulic = 32,

        /// <summary>
        ///   Prismatic
        /// </summary>
        [EnumMember(Value = "PRISMATIC")]
        Prismatic = Blue | Yellow | Red,

        /// <summary>
        ///   Orange
        /// </summary>
        [EnumMember(Value = "ORANGE")]
        Orange = Yellow | Red,

        /// <summary>
        ///   Purple
        /// </summary>
        [EnumMember(Value = "PURPLE")]
        Purple = Blue | Red,

        /// <summary>
        ///   Green
        /// </summary>
        [EnumMember(Value = "GREEN")]
        Green = Blue | Yellow
    }
}