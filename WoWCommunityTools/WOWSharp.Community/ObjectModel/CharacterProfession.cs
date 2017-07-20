﻿/*
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
    /// Represents a character's profession
    /// </summary>
    [Serializable]
    [DataContract]
    public class CharacterProfession : BaseExtensibleDataObject
    {
        /// <summary>
        /// gets or sets profession id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Skill Id
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the profession name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the profession icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the profession rank reached by the character
        /// </summary>
        [DataMember(Name = "rank", IsRequired = true)]
        public int Rank
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the profession's max skill level (the API seems to return zero for that field)
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the list of recipes learned by the character
        /// </summary>
        [DataMember(Name = "recipes", IsRequired = true)]
        public int[] Recipes
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
            return string.Format("{0} {1}/{2} {3} Recipes", this.Name, this.Rank, this.Maximum, this.Recipes == null ? 0 : this.Recipes.Length);
        }
    }
}