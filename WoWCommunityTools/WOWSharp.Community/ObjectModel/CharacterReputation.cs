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
    /// Represents a character's current standing with a faction
    /// </summary>
    [Serializable]
    [DataContract]
    public class CharacterReputation : BaseExtensibleDataObject
    {
        /// <summary>
        /// gets or sets faction id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets faction name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current standing
        /// </summary>
        [DataMember(Name = "standing", IsRequired = true)]
        public Standing Standing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the progress within the current standing
        /// </summary>
        [DataMember(Name = "value", IsRequired = true)]
        public int Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max value to reach the next standing
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
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
            return string.Format("{0} {1} {2}/{3}", this.Name, this.Standing, this.Value, this.Maximum);
        }
    }
}
