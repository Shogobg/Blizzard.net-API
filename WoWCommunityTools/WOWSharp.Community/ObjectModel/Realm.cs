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

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents a realm
    /// </summary>
    [DataContract]
    [Serializable]
    public class Realm : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the realm type name
        /// </summary>
        [DataMember(IsRequired = false, Name="type")]
        public string TypeName
        {
            get
            {
                return EnumHelper<RealmType>.EnumToString(this.Type);
            }
            set
            {
                this.Type = EnumHelper<RealmType>.ParseEnum(value);
            }
        }

        /// <summary>
        /// Gets or sets the realm type
        /// </summary>
        public RealmType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether the realm is PVP enabled
        /// </summary>
        public bool IsPVP
        {
            get
            {
                return (Type & RealmType.PVP) != 0;
            }
        }

        /// <summary>
        /// Gets whether the realm has Role Play rule
        /// </summary>
        public bool IsRP
        {
            get
            {
                return (Type & RealmType.RP) != 0;
            }
        }

        /// <summary>
        /// Gets or sets whether the realm is currently experiencing queues
        /// </summary>
        [DataMember(IsRequired = false, Name = "queue")]
        public bool Queue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the realm is up
        /// </summary>
        [DataMember(IsRequired = false, Name = "status")]
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the realm name
        /// </summary>
        [DataMember(IsRequired = true, Name = "name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the realm id used in urls and query strings
        /// </summary>
        [DataMember(IsRequired = true, Name = "slug")]
        public string Slug
        {
            get;
            set;
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("Realm = {0}, Type= {1}, Status = {2}", this.Name,
                this.Type, this.Status);
        }
    }
}
