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
    ///   Represents information about a spell
    /// </summary>
    [DataContract]
    public class Spell : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the spell's cast time
        /// </summary>
        private string _castTime;

        /// <summary>
        ///   cool down
        /// </summary>
        private string _cooldown;

        /// <summary>
        ///   Gets or sets the spell's description
        /// </summary>
        private string _description;

        /// <summary>
        ///   Gets or sets the spell's icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   Gets or sets the spell's id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the spell's name
        /// </summary>
        private string _name;

        /// <summary>
        ///   power cost
        /// </summary>
        private string _powerCost;

        /// <summary>
        ///   Gets or sets the spell's range
        /// </summary>
        private string _range;

        /// <summary>
        ///   Gets or sets the spell's sub text (typically the spell rank)
        /// </summary>
        private string _subtext;

        /// <summary>
        ///   Gets or sets the spell's id
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
        ///   Gets or sets the spell's name
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
        ///   Gets or sets the spell's sub text (typically the spell rank)
        /// </summary>
        [DataMember(Name = "subtext", IsRequired = false)]
        public string Subtext
        {
            get
            {
                return _subtext;
            }
            internal set
            {
                _subtext = value;
            }
        }

        /// <summary>
        ///   Gets or sets the spell's icon
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
        ///   Gets or sets the spell's description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get
            {
                return _description;
            }
            internal set
            {
                _description = value;
            }
        }

        /// <summary>
        ///   Gets or sets the spell's range
        /// </summary>
        [DataMember(Name = "range", IsRequired = false)]
        public string Range
        {
            get
            {
                return _range;
            }
            internal set
            {
                _range = value;
            }
        }

        /// <summary>
        ///   Gets or sets the spell's cast time
        /// </summary>
        [DataMember(Name = "castTime", IsRequired = false)]
        public string CastTime
        {
            get
            {
                return _castTime;
            }
            internal set
            {
                _castTime = value;
            }
        }

        /// <summary>
        ///   gets or sets power cost
        /// </summary>
        [DataMember(Name = "powerCost", IsRequired = false)]
        public string PowerCost
        {
            get
            {
                return _powerCost;
            }
            internal set
            {
                _powerCost = value;
            }
        }

        /// <summary>
        ///   gets or sets cool down
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cooldown"), DataMember(Name = "cooldown", IsRequired = false)]
        public string Cooldown
        {
            get
            {
                return _cooldown;
            }
            internal set
            {
                _cooldown = value;
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