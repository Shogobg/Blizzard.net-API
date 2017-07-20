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
    ///   response for talents API call
    /// </summary>
    [DataContract]
    public class TalentsResponse : ApiResponse
    {
        /// <summary>
        ///   death knight talents
        /// </summary>
        private ClassTalentInfo _deathKnight;

        /// <summary>
        ///   druid talents
        /// </summary>
        private ClassTalentInfo _druid;

        /// <summary>
        ///   hunter talents
        /// </summary>
        private ClassTalentInfo _hunter;

        /// <summary>
        ///   mage talents
        /// </summary>
        private ClassTalentInfo _mage;

        /// <summary>
        ///   monk talents
        /// </summary>
        private ClassTalentInfo _monk;

        /// <summary>
        ///   paladin talents
        /// </summary>
        private ClassTalentInfo _paladin;

        /// <summary>
        ///   priest talents
        /// </summary>
        private ClassTalentInfo _priest;

        /// <summary>
        ///   rogue talents
        /// </summary>
        private ClassTalentInfo _rogue;

        /// <summary>
        ///   shaman talents
        /// </summary>
        private ClassTalentInfo _shaman;

        /// <summary>
        ///   warlock talents
        /// </summary>
        private ClassTalentInfo _warlock;

        /// <summary>
        ///   warrior talents
        /// </summary>
        private ClassTalentInfo _warrior;

        /// <summary>
        ///   gets or sets warrior talents
        /// </summary>
        [DataMember(Name = "1", IsRequired = false)]
        public ClassTalentInfo Warrior
        {
            get
            {
                return _warrior;
            }
            internal set
            {
                _warrior = value;
            }
        }

        /// <summary>
        ///   gets or sets paladin talents
        /// </summary>
        [DataMember(Name = "2", IsRequired = false)]
        public ClassTalentInfo Paladin
        {
            get
            {
                return _paladin;
            }
            internal set
            {
                _paladin = value;
            }
        }

        /// <summary>
        ///   gets or sets hunter talents
        /// </summary>
        [DataMember(Name = "3", IsRequired = false)]
        public ClassTalentInfo Hunter
        {
            get
            {
                return _hunter;
            }
            internal set
            {
                _hunter = value;
            }
        }

        /// <summary>
        ///   gets or sets rogue talents
        /// </summary>
        [DataMember(Name = "4", IsRequired = false)]
        public ClassTalentInfo Rogue
        {
            get
            {
                return _rogue;
            }
            internal set
            {
                _rogue = value;
            }
        }

        /// <summary>
        ///   gets or sets priest talents
        /// </summary>
        [DataMember(Name = "5", IsRequired = false)]
        public ClassTalentInfo Priest
        {
            get
            {
                return _priest;
            }
            internal set
            {
                _priest = value;
            }
        }

        /// <summary>
        ///   gets or sets death knight talents
        /// </summary>
        [DataMember(Name = "6", IsRequired = false)]
        public ClassTalentInfo DeathKnight
        {
            get
            {
                return _deathKnight;
            }
            internal set
            {
                _deathKnight = value;
            }
        }

        /// <summary>
        ///   gets or sets shaman talents
        /// </summary>
        [DataMember(Name = "7", IsRequired = false)]
        public ClassTalentInfo Shaman
        {
            get
            {
                return _shaman;
            }
            internal set
            {
                _shaman = value;
            }
        }

        /// <summary>
        ///   gets or sets mage talents
        /// </summary>
        [DataMember(Name = "8", IsRequired = false)]
        public ClassTalentInfo Mage
        {
            get
            {
                return _mage;
            }
            internal set
            {
                _mage = value;
            }
        }

        /// <summary>
        ///   gets or sets warlock talents
        /// </summary>
        [DataMember(Name = "9", IsRequired = false)]
        public ClassTalentInfo Warlock
        {
            get
            {
                return _warlock;
            }
            internal set
            {
                _warlock = value;
            }
        }

        /// <summary>
        ///   gets or sets monk talents
        /// </summary>
        [DataMember(Name = "10", IsRequired = false)]
        public ClassTalentInfo Monk
        {
            get
            {
                return _monk;
            }
            internal set
            {
                _monk = value;
            }
        }

        /// <summary>
        ///   gets or sets druid talents
        /// </summary>
        [DataMember(Name = "11", IsRequired = false)]
        public ClassTalentInfo Druid
        {
            get
            {
                return _druid;
            }
            internal set
            {
                _druid = value;
            }
        }
    }
}