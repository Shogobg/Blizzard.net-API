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
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about a spell
    /// </summary>
    [DataContract]
    public class Spell : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the spell's id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's sub text (typically the spell rank)
        /// </summary>
        [DataMember(Name = "subtext", IsRequired = false)]
        public string Subtext
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's range
        /// </summary>
        [DataMember(Name = "range", IsRequired = false)]
        public string Range
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's cast time
        /// </summary>
        [DataMember(Name = "castTime", IsRequired = false)]
        public string CastTime
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets power cost
        /// </summary>
        [DataMember(Name = "powerCost", IsRequired = false)]
        public string PowerCost
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets cool down
        /// </summary>
        [DataMember(Name = "cooldown", IsRequired = false)]
        public string Cooldown
        {
            get;
            internal set;
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