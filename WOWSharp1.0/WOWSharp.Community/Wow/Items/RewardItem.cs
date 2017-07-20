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
    ///   Represents an achievement reward item
    /// </summary>
    [DataContract]
    public class RewardItem
    {
        /// <summary>
        ///   Gets or sets the item icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   Gets or sets the item id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the item's quality
        /// </summary>
        private ItemQuality _quality;

        /// <summary>
        ///   Gets or sets the item parameters
        /// </summary>
        private EquippedItemParameters _tooltipParameters;

        /// <summary>
        ///   Gets or sets the item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
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
        ///   Gets or sets the item's quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality Quality
        {
            get
            {
                return _quality;
            }
            internal set
            {
                _quality = value;
            }
        }

        /// <summary>
        ///   Gets or sets the item parameters
        /// </summary>
        [DataMember(Name = "tooltipParams", IsRequired = false)]
        public EquippedItemParameters TooltipParameters
        {
            get
            {
                return _tooltipParameters;
            }
            internal set
            {
                _tooltipParameters = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}