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
    ///   information about a battle pet ability
    /// </summary>
    [DataContract]
    public class BattlePetAbility : ApiResponse
    {
        /// <summary>
        ///   ability cooldown
        /// </summary>
        private int _coolDown;

        /// <summary>
        ///   ability icon image
        /// </summary>
        private string _icon;

        /// <summary>
        ///   ability id
        /// </summary>
        private int _id;

        /// <summary>
        ///   whether the ability is passive
        /// </summary>
        private bool _isPassive;

        /// <summary>
        ///   ability name
        /// </summary>
        private string _name;

        /// <summary>
        ///   ability order
        /// </summary>
        private int _order;

        /// <summary>
        ///   Id of the pet that can perform this ability
        /// </summary>
        private int _petTypeId;

        /// <summary>
        ///   ability required level
        /// </summary>
        private int _requiredLevel;

        /// <summary>
        ///   ability rounds
        /// </summary>
        private int _rounds;

        /// <summary>
        ///   whether to show hints for ability
        /// </summary>
        private bool _showHints;

        /// <summary>
        ///   ability slot
        /// </summary>
        private int _slot;

        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [DataMember(Name = "cooldown", IsRequired = false)]
        public int CoolDown
        {
            get
            {
                return _coolDown;
            }
            internal set
            {
                _coolDown = value;
            }
        }

        /// <summary>
        ///   Ability icon image
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
        ///   Ability Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
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
        ///   whether the ability is passive
        /// </summary>
        [DataMember(Name = "isPassive", IsRequired = false)]
        public bool IsPassive
        {
            get
            {
                return _isPassive;
            }
            internal set
            {
                _isPassive = value;
            }
        }

        /// <summary>
        ///   Ability name
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
        ///   Id of the pet that can perform this ability
        /// </summary>
        [DataMember(Name = "petTypeId", IsRequired = false)]
        public int PetTypeId
        {
            get
            {
                return _petTypeId;
            }
            internal set
            {
                _petTypeId = value;
            }
        }

        /// <summary>
        ///   Ability rounds
        /// </summary>
        [DataMember(Name = "rounds", IsRequired = false)]
        public int Rounds
        {
            get
            {
                return _rounds;
            }
            internal set
            {
                _rounds = value;
            }
        }

        /// <summary>
        ///   whether to show hints for ability
        /// </summary>
        [DataMember(Name = "showHints", IsRequired = false)]
        public bool ShowHints
        {
            get
            {
                return _showHints;
            }
            internal set
            {
                _showHints = value;
            }
        }

        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [DataMember(Name = "order", IsRequired = false)]
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
        ///   Ability required level
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = false)]
        public int RequiredLevel
        {
            get
            {
                return _requiredLevel;
            }
            internal set
            {
                _requiredLevel = value;
            }
        }

        /// <summary>
        ///   Ability slot
        /// </summary>
        [DataMember(Name = "slot", IsRequired = false)]
        public int Slot
        {
            get
            {
                return _slot;
            }
            internal set
            {
                _slot = value;
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}