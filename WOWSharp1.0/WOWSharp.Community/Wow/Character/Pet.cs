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
    [DataContract]
    public class Pet
    {
        /// <summary>
        ///   battlePetId
        /// </summary>
        private int _battlePetId;

        /// <summary>
        ///   whether the pet can battle
        /// </summary>
        private bool _canBattle;

        /// <summary>
        ///   creature id
        /// </summary>
        private int _creatureId;

        /// <summary>
        ///   icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   whether this pet is player's favourite
        /// </summary>
        private bool _isFavorite;

        /// <summary>
        ///   item id
        /// </summary>
        private int _itemId;

        /// <summary>
        ///   pet's name
        /// </summary>
        private string _name;

        /// <summary>
        ///   quality of the pet
        /// </summary>
        private ItemQuality _quality;

        /// <summary>
        ///   spell id
        /// </summary>
        private int _spellId;

        /// <summary>
        ///   pet's status
        /// </summary>
        private PetStats _stats;

        /// <summary>
        ///   gets or sets battlePetId
        /// </summary>
        [DataMember(Name = "battlePetId", IsRequired = false)]
        public int BattlePetId
        {
            get
            {
                return _battlePetId;
            }
            internal set
            {
                _battlePetId = value;
            }
        }

        /// <summary>
        ///   gets or sets whether the pet can battle
        /// </summary>
        [DataMember(Name = "canBattle", IsRequired = false)]
        public bool CanBattle
        {
            get
            {
                return _canBattle;
            }
            internal set
            {
                _canBattle = value;
            }
        }

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
        ///   gets or sets whether this pet is player's favourite
        /// </summary>
        [DataMember(Name = "isFavorite", IsRequired = false)]
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            internal set
            {
                _isFavorite = value;
            }
        }

        /// <summary>
        ///   gets or sets item id
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
        ///   gets or sets pet's name
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
        ///   gets or sets quality of the pet
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
        ///   gets or sets spell id
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
        ///   gets or sets pet's status
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public PetStats Stats
        {
            get
            {
                return _stats;
            }
            internal set
            {
                _stats = value;
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