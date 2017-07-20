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
    ///   Represents gem's bonus
    /// </summary>
    [DataContract]
    public class GemBonus
    {
        /// <summary>
        ///   gets or sets the required gem's item level
        /// </summary>
        private int _itemLevel;

        /// <summary>
        ///   gets or sets the required level for the gem
        /// </summary>
        private int _minimumLevel;

        /// <summary>
        ///   The socket bonus description (e.g. "+20 Agility and +20 Hit Rating")
        /// </summary>
        private string _name;

        /// <summary>
        ///   gets or sets The required skill
        /// </summary>
        private Skill _requiredSkillId;

        /// <summary>
        ///   gets or sets the required skill rank
        /// </summary>
        private int _requiredSkillRank;

        /// <summary>
        ///   Gets source item id. This is the same as item id for the gem
        /// </summary>
        private int _sourceItemId;

        /// <summary>
        ///   The socket bonus description (e.g. "+20 Agility and +20 Hit Rating")
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
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
        ///   Gets source item id. This is the same as item id for the gem
        /// </summary>
        [DataMember(Name = "srcItemId", IsRequired = true)]
        public int SourceItemId
        {
            get
            {
                return _sourceItemId;
            }
            internal set
            {
                _sourceItemId = value;
            }
        }

        /// <summary>
        ///   gets or sets The required skill
        /// </summary>
        [DataMember(Name = "requiredSkillId", IsRequired = true)]
        public Skill RequiredSkillId
        {
            get
            {
                return _requiredSkillId;
            }
            internal set
            {
                _requiredSkillId = value;
            }
        }

        /// <summary>
        ///   gets or sets the required skill rank
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredSkillRank
        {
            get
            {
                return _requiredSkillRank;
            }
            internal set
            {
                _requiredSkillRank = value;
            }
        }

        /// <summary>
        ///   gets or sets the required gem's item level
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = true)]
        public int ItemLevel
        {
            get
            {
                return _itemLevel;
            }
            internal set
            {
                _itemLevel = value;
            }
        }

        /// <summary>
        ///   gets or sets the required level for the gem
        /// </summary>
        [DataMember(Name = "minLevel", IsRequired = false)]
        public int MinimumLevel
        {
            get
            {
                return _minimumLevel;
            }
            internal set
            {
                _minimumLevel = value;
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