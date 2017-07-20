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
    ///   Represents information about character's combat pets (for classes with pets)
    /// </summary>
    [DataContract]
    public class HunterPet
    {
        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        private string _calculatorSpecialization;

        /// <summary>
        ///   Gets or sets the creature type
        /// </summary>
        private int _creatureId;

        /// <summary>
        ///   Gets or sets whether the character currently has that creature selected
        /// </summary>
        private bool _isSelected;

        /// <summary>
        ///   Gets or sets the pet name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Gets or sets the pet slot (no clue what that is) TODO: Find out what this field does.
        /// </summary>
        private int _slot;

        /// <summary>
        ///   Gets or sets the specialization for the pet
        /// </summary>
        private Specialization _specialization;

        /// <summary>
        ///   Gets or sets the pet name
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
        ///   Gets or sets the creature type
        /// </summary>
        [DataMember(Name = "creature", IsRequired = true)]
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
        ///   Gets or sets whether the character currently has that creature selected
        /// </summary>
        [DataMember(Name = "selected", IsRequired = false)]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            internal set
            {
                _isSelected = value;
            }
        }

        /// <summary>
        ///   Gets or sets the pet slot (no clue what that is) TODO: Find out what this field does.
        /// </summary>
        [DataMember(Name = "slot", IsRequired = true)]
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
        ///   Gets or sets the specialization for the pet
        /// </summary>
        [DataMember(Name = "spec", IsRequired = false)]
        public Specialization Specialization
        {
            get
            {
                return _specialization;
            }
            internal set
            {
                _specialization = value;
            }
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [DataMember(Name = "calcSpec")]
        public string CalculatorSpecialization
        {
            get
            {
                return _calculatorSpecialization;
            }
            internal set
            {
                _calculatorSpecialization = value;
            }
        }
    }
}