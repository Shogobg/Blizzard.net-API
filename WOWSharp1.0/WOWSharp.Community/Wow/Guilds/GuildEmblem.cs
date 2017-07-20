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

using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about a guild's emblem
    /// </summary>
    [DataContract]
    public class GuildEmblem
    {
        /// <summary>
        ///   Gets or sets the guild's emblem's background color
        /// </summary>
        private string _backgroundColor;

        /// <summary>
        ///   Gets or sets the guild's emblem's border style
        /// </summary>
        private int _border;

        /// <summary>
        ///   Gets or sets the guild's emblem's border color
        /// </summary>
        private string _borderColor;

        /// <summary>
        ///   Gets or sets the guild's emblem's icon
        /// </summary>
        private int _icon;

        /// <summary>
        ///   Gets or sets the guild's emblem's icon color
        /// </summary>
        private string _iconColor;

        /// <summary>
        ///   Gets or sets the guild's emblem's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public int Icon
        {
            get
            {
                return _icon;
            }
            internal set
            {
                _icon = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's icon color
        /// </summary>
        [DataMember(Name = "iconColor", IsRequired = true)]
        public string IconColor
        {
            get
            {
                return _iconColor;
            }
            internal set
            {
                _iconColor = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's border style
        /// </summary>
        [DataMember(Name = "border", IsRequired = true)]
        public int Border
        {
            get
            {
                return _border;
            }
            internal set
            {
                _border = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's border color
        /// </summary>
        [DataMember(Name = "borderColor", IsRequired = true)]
        public string BorderColor
        {
            get
            {
                return _borderColor;
            }
            internal set
            {
                _borderColor = value;
            }
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's background color
        /// </summary>
        [DataMember(Name = "backgroundColor", IsRequired = true)]
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            internal set
            {
                _backgroundColor = value;
            }
        }
    }
}