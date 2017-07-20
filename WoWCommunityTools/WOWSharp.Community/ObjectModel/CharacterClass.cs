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
    /// Information about character class
    /// </summary>
    [Serializable]
    [DataContract]
    public class CharacterClass : BaseExtensibleDataObject
    {
        /// <summary>
        /// class
        /// </summary>
        private Class _class;
        
        /// <summary>
        /// Gets or sets class id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Class Class
        {
            get
            {
                return _class;
            }
            set
            {
                CheckReadonly();
                _class = value;
            }
        }

        /// <summary>
        /// Mask
        /// </summary>
        private int _mask;
        /// <summary>
        /// Gets or sets class mask (No Idea what that's used for)
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
                this._mask = value;
            }
        }

        /// <summary>
        /// Gets or sets the power type name (mana, rage, etc)
        /// </summary>
        [DataMember(Name = "powerType", IsRequired = true)]
        public string PowerTypeName
        {
            get
            {
                return EnumHelper<PowerType>.EnumToString(this.PowerType);
            }
            set
            {
                CheckReadonly();
                this.PowerType = EnumHelper<PowerType>.ParseEnum(value);
            }
        }

        /// <summary>
        /// Power Type
        /// </summary>
        private PowerType _powerType;

        /// <summary>
        /// Gets or sets the class' power type
        /// </summary>
        public PowerType PowerType
        {
            get
            {
                return _powerType;
            }
            set
            {
                CheckReadonly();
                _powerType = value;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets or sets the class name
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
        private volatile int _isReadonly;
        
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
        /// Gets class name
        /// </summary>
        /// <returns>Gets class name (for debugging purposes)</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
