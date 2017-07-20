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
using System.Collections.ObjectModel;

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents the response returned when querying the website about character classes
    /// </summary>
    [DataContract]
    [Serializable]
    public class ClassesResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets a list or all character classes
        /// </summary>
        [DataMember(Name = "classes", IsRequired = true)]
        public CharacterClass[] Classes
        {
            get;
            set;
        }

        /// <summary>
        /// Make the class objects readonly
        /// </summary>
        /// <param name="client"></param>
        protected internal override void OnDeserialized(ApiClient client)
        {
            base.OnDeserialized(client);
            if (Classes != null)
            {
                for (int i = 0; i < this.Classes.Length; i++)
                {
                    if (this.Classes[i] == null)
                        continue;
                    this.Classes[i].MakeReadOnly();
                }
            }
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("Class Count = {0}", Classes == null ? 0 : Classes.Length);
        }
    }
}