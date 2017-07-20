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
    ///   A characters specialization
    /// </summary>
    [DataContract]
    public class Specialization
    {
        /// <summary>
        ///   Gets or sets the name of the background image of the spec
        /// </summary>
        private string _backgroundImage;

        /// <summary>
        ///   Gets or sets the description of the spec
        /// </summary>
        private string _description;

        /// <summary>
        ///   Gets or sets the name of the icon image of the spec
        /// </summary>
        private string _icon;

        /// <summary>
        ///   Gets or sets the name of the spec
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the order of the spec within the other specs of the class
        /// </summary>
        private int _order;

        /// <summary>
        ///   Gets or sets the role of the spec
        /// </summary>
        private CharacterRoles _role;

        /// <summary>
        ///   Gets or sets the name of the spec
        /// </summary>
        [DataMember(Name = "name")]
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
        ///   Gets or sets the role of the spec
        /// </summary>
        public CharacterRoles Role
        {
            get
            {
                return _role;
            }
            internal set
            {
                _role = value;
            }
        }


        /// <summary>
        ///   Gets or sets the role of the spec
        /// </summary>
        [DataMember(Name = "role")]
        public string RoleName
        {
            get
            {
                return EnumHelper<CharacterRoles>.EnumToString(Role);
            }
            internal set
            {
                Role = EnumHelper<CharacterRoles>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   Gets or sets the name of the background image of the spec
        /// </summary>
        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
            internal set
            {
                _backgroundImage = value;
            }
        }

        /// <summary>
        ///   Gets or sets the name of the icon image of the spec
        /// </summary>
        [DataMember(Name = "icon")]
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
        ///   Gets or sets the description of the spec
        /// </summary>
        [DataMember(Name = "description")]
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
        ///   Gets or sets the order of the spec within the other specs of the class
        /// </summary>
        [DataMember(Name = "order")]
        public int Order
        {
            get
            {
                return _order;
            }
            internal set
            {
                _order = value;
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