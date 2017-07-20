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

using Newtonsoft.Json;
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
        ///   Pet species abilities
        /// </summary>
        [DataMember(Name = "abilities", IsRequired = false)]
        public IList<BattlePetAbility> Abilities
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether the species can battle
        /// </summary>
        [DataMember(Name = "canBattle", IsRequired = false)]
        public bool CanBattle
        {
            get;
            internal set;
        }

        /// <summary>
        ///   whether creature id for the species
        /// </summary>
        [DataMember(Name = "creatureId", IsRequired = false)]
        public int CreatureId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [DataMember(Name = "description", IsRequired = false)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the pet's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = false)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet type id
        /// </summary>
        [DataMember(Name = "petTypeId", IsRequired = false)]
        public int PetTypeId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet's source
        /// </summary>
        [DataMember(Name = "source", IsRequired = false)]
        public string Source
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the pet's species id
        /// </summary>
        [DataMember(Name = "speciesId", IsRequired = false)]
        public int SpeciesId
        {
            get;
            internal set;
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