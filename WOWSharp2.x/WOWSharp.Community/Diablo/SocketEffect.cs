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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// Effect applied when a gem in inserted into an item
    /// </summary>
    [DataContract]
    public class SocketEffect
    {
        /// <summary>
        /// A user readable list of attributes in the locale specified by the client
        /// For a socket gem, the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributes")]
        public IList<string> Attributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attributes in locale independent format
        /// the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributesRaw")]
        public IDictionary<string, AttributeValue> RawAttributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item type
        /// </summary>
        [DataMember(Name = "itemTypeId")]
        public ItemType ItemType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item type name
        /// </summary>
        [DataMember(Name = "itemTypeName")]
        public string ItemTypeName
        {
            get;
            internal set;
        }
    }
}
