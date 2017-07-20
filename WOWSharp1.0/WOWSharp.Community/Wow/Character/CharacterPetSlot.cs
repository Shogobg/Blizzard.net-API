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
    ///   character pet slot
    /// </summary>
    [DataContract]
    public class CharacterPetSlot
    {
        /// <summary>
        ///   ability ids
        /// </summary>
        private IList<int> _abilities;

        /// <summary>
        ///   battle pet id
        /// </summary>
        private int _battlePetId;

        /// <summary>
        ///   whether the slot is empty
        /// </summary>
        private bool _isEmpty;

        /// <summary>
        ///   whether the slot is locked
        /// </summary>
        private bool _isLocked;

        /// <summary>
        ///   slot number
        /// </summary>
        private int _slot;

        /// <summary>
        ///   gets or sets ability ids
        /// </summary>
        [DataMember(Name = "abilities", IsRequired = false)]
        public IList<int> Abilities
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
        ///   gets or sets battle pet id
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
        ///   gets or sets whether the slot is empty
        /// </summary>
        [DataMember(Name = "isEmpty", IsRequired = false)]
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            internal set
            {
                _isEmpty = value;
            }
        }

        /// <summary>
        ///   gets or sets whether the slot is locked
        /// </summary>
        [DataMember(Name = "isLocked", IsRequired = false)]
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            internal set
            {
                _isLocked = value;
            }
        }

        /// <summary>
        ///   gets or sets slot number
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
    }
}