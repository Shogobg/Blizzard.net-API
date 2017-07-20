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

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   information about a battle pet species
    /// </summary>
    [DataContract]
    public class BattlePetSpecies : ApiResponse
    {
        /// <summary>
        ///   Abilities
        /// </summary>
        private IList<BattlePetAbility> _abilities;

        /// <summary>
        ///   whether the species can battle
        /// </summary>
        private bool _canBattle;

        /// <summary>
        ///   creature Id
        /// </summary>
        private int _creatureId;

        /// <summary>
        ///   descriptio
        /// </summary>
        private string _description;

        /// <summary>
        ///   the pet's icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   the pet type id
        /// </summary>
        private int _petTypeId;

        /// <summary>
        ///   the pet's source
        /// </summary>
        private string _source;

        /// <summary>
        ///   the pet's species id
        /// </summary>
        private int _speciesId;

        /// <summary>
        ///   Pet species abilities
        /// </summary>
        [DataMember(Name = "abilities", IsRequired = false)]
        public IList<BattlePetAbility> Abilities
        {
            get
            {
                return _abilities;
            }
            internal set
            {
                _abilities = value;
            }
        }

        /// <summary>
        ///   whether the species can battle
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
        ///   whether creature id for the species
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
        ///   description
        /// </summary>
        [DataMember(Name = "description", IsRequired = false)]
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
        ///   Gets or sets the pet's icon
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
        ///   gets or sets the pet type id
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
        ///   gets or sets the pet's source
        /// </summary>
        [DataMember(Name = "source", IsRequired = false)]
        public string Source
        {
            get
            {
                return _source;
            }
            internal set
            {
                _source = value;
            }
        }

        /// <summary>
        ///   gets or sets the pet's species id
        /// </summary>
        [DataMember(Name = "speciesId", IsRequired = false)]
        public int SpeciesId
        {
            get
            {
                return _speciesId;
            }
            internal set
            {
                _speciesId = value;
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Description;
        }
    }
}