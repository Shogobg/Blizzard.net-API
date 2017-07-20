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

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Enumeration representing the character current progress in the instance
    /// </summary>
    public enum CharacterInstanceStatus
    {
        /// <summary>
        ///   Not started. Either the character never sets foot in the instance, or entered the instance and never killed any bosses, or this mode is not available (for example heroic progression status for instances that don't have heroic modes).
        /// </summary>
        NotStarted = 0,

        /// <summary>
        ///   Progressions. The character has killed at least 1 boss in the instance in that mode.
        /// </summary>
        Progressing = 1,

        /// <summary>
        ///   Completed. The character has killed all the non optional bosses in the instance in that mode.
        /// </summary>
        Completed = 2
    }
}