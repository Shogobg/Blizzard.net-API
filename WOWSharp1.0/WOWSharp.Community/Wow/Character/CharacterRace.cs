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
    ///   Represents character's race
    /// </summary>
    [DataContract]
    public class CharacterRace
    {
        /// <summary>
        ///   Mask
        /// </summary>
        private int _mask;

        /// <summary>
        ///   Name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Race
        /// </summary>
        private Race _race;

        /// <summary>
        ///   Side
        /// </summary>
        private Faction _side;

        /// <summary>
        ///   gets or sets race id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Race Race
        {
            get
            {
                return _race;
            }
            internal set
            {
                _race = value;
            }
        }

        /// <summary>
        ///   gets or sets race mask (used to determine which items, quests are available for that race)
        /// </summary>
        [DataMember(Name = "mask", IsRequired = true)]
        public int Mask
        {
            get
            {
                return _mask;
            }
            internal set
            {
                _mask = value;
            }
        }

        /// <summary>
        ///   Gets or sets the name of the faction to which the race belongs
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        public string SideName
        {
            get
            {
                return EnumHelper<Faction>.EnumToString(Side);
            }
            internal set
            {
                Side = EnumHelper<Faction>.ParseEnum(value);
            }
        }

        /// <summary>
        ///   Gets or sets the faction to which the race belongs
        /// </summary>
        public Faction Side
        {
            get
            {
                return _side;
            }
            internal set
            {
                _side = value;
            }
        }

        /// <summary>
        ///   Gets or sets the race name
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
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}