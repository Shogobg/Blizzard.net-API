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
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a character's profession
    /// </summary>
    [DataContract]
    public class CharacterProfession
    {
        /// <summary>
        ///   gets or sets profession id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Skill Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession rank reached by the character
        /// </summary>
        [DataMember(Name = "rank", IsRequired = true)]
        public int Rank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession's max skill level (the API seems to return zero for that field)
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the list of recipes learned by the character
        /// </summary>
        [DataMember(Name = "recipes", IsRequired = true)]
        public IList<int> Recipes
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
            return string.Format(CultureInfo.CurrentCulture, "{0} {1}/{2} {3} Recipes", Name, Rank, Maximum,
                                 Recipes == null ? 0 : Recipes.Count);
        }
    }
}