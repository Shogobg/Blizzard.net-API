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
    /// Represents the response returned when querying the website about character races
    /// </summary>
    [DataContract]
    [Serializable]
    public class RacesResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets a list or all character races
        /// </summary>
        [DataMember(Name = "races", IsRequired = true)]
        public CharacterRace[] Races
        {
            get;
            set;
        }

        /// <summary>
        /// Make the race objects readonly
        /// </summary>
        /// <param name="client"></param>
        protected internal override void OnDeserialized(ApiClient client)
        {
            base.OnDeserialized(client);
            if (Races != null)
            {
                for (int i = 0; i < this.Races.Length; i++)
                {
                    if (this.Races[i] == null)
                        continue;
                    this.Races[i].MakeReadOnly();
                }
            }
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("Race Count = {0}", Races == null ? 0 : Races.Length);
        }
    }
}
