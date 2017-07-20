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
    ///   Represents information about recipe
    /// </summary>
    [DataContract]
    public class RecipeInfo : ApiResponse
    {
        /// <summary>
        ///   Recipe icon
        /// </summary>
        private string _icon;

        /// <summary>
        ///   Recipe id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Recipe name
        /// </summary>
        private string _name;

        /// <summary>
        ///   Profession name
        /// </summary>
        private string _professionName;

        /// <summary>
        ///   Recipe id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        /// <summary>
        ///   Recipe icon
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get
            {
                return _icon;
            }
            internal set
            {
                _icon = value;
            }
        }

        /// <summary>
        ///   Recipe name
        /// </summary>
        [DataMember(Name = "name")]
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
        ///   Profession name
        /// </summary>
        [DataMember(Name = "profession")]
        public string ProfessionName
        {
            get
            {
                return _professionName;
            }
            internal set
            {
                _professionName = value;
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