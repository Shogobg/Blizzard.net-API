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
    ///   Represents quest information
    /// </summary>
    [DataContract]
    public class Quest : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the quest's category
        /// </summary>
        private string _category;

        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        private int _id;

        /// <summary>
        ///   Gets or sets the quest's level (I am guessing that's the recommended level?)
        /// </summary>
        private int _level;

        /// <summary>
        ///   Gets or sets the required level
        /// </summary>
        private int _requiredLevel;

        /// <summary>
        ///   Gets or sets the number of suggested party members
        /// </summary>
        private int _suggestedPartyMembers;

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        private string _title;

        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
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
        ///   Gets or sets the achievement title
        /// </summary>
        [DataMember(Name = "title", IsRequired = true)]
        public string Title
        {
            get
            {
                return _title;
            }
            internal set
            {
                _title = value;
            }
        }

        /// <summary>
        ///   Gets or sets the required level
        /// </summary>
        [DataMember(Name = "reqLevel", IsRequired = false)]
        public int RequiredLevel
        {
            get
            {
                return _requiredLevel;
            }
            internal set
            {
                _requiredLevel = value;
            }
        }

        /// <summary>
        ///   Gets or sets the number of suggested party members
        /// </summary>
        [DataMember(Name = "suggestedPartyMembers", IsRequired = false)]
        public int SuggestedPartyMembers
        {
            get
            {
                return _suggestedPartyMembers;
            }
            internal set
            {
                _suggestedPartyMembers = value;
            }
        }

        /// <summary>
        ///   Gets or sets the quest's category
        /// </summary>
        [DataMember(Name = "category", IsRequired = false)]
        public string Category
        {
            get
            {
                return _category;
            }
            internal set
            {
                _category = value;
            }
        }

        /// <summary>
        ///   Gets or sets the quest's level (I am guessing that's the recommended level?)
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
        {
            get
            {
                return _level;
            }
            internal set
            {
                _level = value;
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Title;
        }
    }
}