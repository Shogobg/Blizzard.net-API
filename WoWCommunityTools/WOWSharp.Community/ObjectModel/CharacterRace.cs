/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents character's race
    /// </summary>
    [DataContract]
    [Serializable]
    public class CharacterRace : BaseExtensibleDataObject
    {
        /// <summary>
        /// Race
        /// </summary>
        private Race _race;

        /// <summary>
        /// gets or sets race id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Race Race
        {
            get
            {
                return _race;
            }
            set
            {
                CheckReadonly();
                _race = value;
            }
        }

        /// <summary>
        /// Mask
        /// </summary>
        private int _mask;
        
        /// <summary>
        /// gets or sets race mask (used to determine which items, quests are available for that race)
        /// </summary>
        [DataMember(Name = "mask", IsRequired = true)]
        public int Mask
        {
            get
            {
                return _mask;
            }
            set
            {
                CheckReadonly();
                _mask = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the faction to which the race belongs
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        public string SideName
        {
            get
            {
                return EnumHelper<Faction>.EnumToString(this.Side);
            }
            set
            {
                CheckReadonly();
                this.Side = EnumHelper<Faction>.ParseEnum(value);
            }
        }

        /// <summary>
        /// Side
        /// </summary>
        private Faction _side;
        /// <summary>
        /// Gets or sets the faction to which the race belongs
        /// </summary>
        public Faction Side
        {
            get
            {
                return _side;
            }
            set
            {
                CheckReadonly();
                _side = value;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets or sets the race name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                CheckReadonly();
                _name = value;
            }
        }

        /// <summary>
        /// Whether the object is readonly
        /// </summary>
        private int _isReadonly;

        /// <summary>
        /// Mark the object as readonly
        /// </summary>
        internal void MakeReadOnly()
        {
            _isReadonly = 1;
        }

        /// <summary>
        /// If the object is readonly, throw an exception
        /// </summary>
        internal void CheckReadonly()
        {
            if (_isReadonly == 1)
                throw new InvalidOperationException(ErrorMessages.ObjectIsReadOnly);
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
