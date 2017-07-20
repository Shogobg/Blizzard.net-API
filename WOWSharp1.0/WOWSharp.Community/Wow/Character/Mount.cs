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
    ///   information about a mount
    /// </summary>
    [DataContract]
    public class Mount
    {
        /// <summary>
        ///   creature id
        /// </summary>
        private int _creatureId;

        /// <summary>
        ///   icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   whether the mount is aquatic
        /// </summary>
        private bool _isAquatic;

        /// <summary>
        ///   whether the mount can fly
        /// </summary>
        private bool _isFlying;

        /// <summary>
        ///   whether the mount is a ground mount
        /// </summary>
        private bool _isGround;

        /// <summary>
        ///   whether the mount can jump
        /// </summary>
        private bool _isJumping;

        /// <summary>
        ///   item id to learn the mount
        /// </summary>
        private int _itemId;

        /// <summary>
        ///   name of the mount
        /// </summary>
        private string _name;

        /// <summary>
        ///   quality
        /// </summary>
        private ItemQuality _quality;

        /// <summary>
        ///   spell id to summon the mount
        /// </summary>
        private int _spellId;

        /// <summary>
        ///   gets or sets creature id
        /// </summary>
        [DataMember(Name = "creatureId", IsRequired = false)]
        public int CreatureId
        {
            get
            {
                return _creatureId;
            }
            internal set
            {
                _creatureId = value;
            }
        }

        /// <summary>
        ///   gets or sets icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
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
        ///   gets or sets whether the mount is aquatic
        /// </summary>
        [DataMember(Name = "isAquatic", IsRequired = false)]
        public bool IsAquatic
        {
            get
            {
                return _isAquatic;
            }
            internal set
            {
                _isAquatic = value;
            }
        }

        /// <summary>
        ///   gets or sets whether the mount can fly
        /// </summary>
        [DataMember(Name = "isFlying", IsRequired = false)]
        public bool IsFlying
        {
            get
            {
                return _isFlying;
            }
            internal set
            {
                _isFlying = value;
            }
        }

        /// <summary>
        ///   gets or sets whether the mount is a ground mount
        /// </summary>
        [DataMember(Name = "isGround", IsRequired = false)]
        public bool IsGround
        {
            get
            {
                return _isGround;
            }
            internal set
            {
                _isGround = value;
            }
        }

        /// <summary>
        ///   gets or sets whether the mount can jump
        /// </summary>
        [DataMember(Name = "isJumping", IsRequired = false)]
        public bool IsJumping
        {
            get
            {
                return _isJumping;
            }
            internal set
            {
                _isJumping = value;
            }
        }

        /// <summary>
        ///   gets or sets item id to learn the mount
        /// </summary>
        [DataMember(Name = "itemId", IsRequired = false)]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            internal set
            {
                _itemId = value;
            }
        }

        /// <summary>
        ///   gets or sets name of the mount
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
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
        ///   gets or sets quality
        /// </summary>
        [DataMember(Name = "qualityId", IsRequired = false)]
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
        ///   gets or sets spell id to summon the mount
        /// </summary>
        [DataMember(Name = "spellId", IsRequired = false)]
        public int SpellId
        {
            get
            {
                return _spellId;
            }
            internal set
            {
                _spellId = value;
            }
        }

        /// <summary>
        ///   name of the mount (For debugging purposes)
        /// </summary>
        /// <returns> string representation </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}