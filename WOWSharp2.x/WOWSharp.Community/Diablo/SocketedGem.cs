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
    /// Socketed gem
    /// </summary>
    [DataContract]
    public class SocketedGem
    {
        /// <summary>
        /// A user readable list of attributes in the locale specified by the client
        /// For a socket gem, the attributes will vary depending on where the gem is socketed
        /// For exampe, a ruby will list only bonus xp when socketed in a helm
        /// </summary>
        [DataMember(Name = "attributes")]
        public ItemAttributes Attributes
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
        /// The gem item
        /// </summary>
        [DataMember(Name = "item", IsRequired = false)]
        public Item Item
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Item == null ? "" : Item.ToString();
        }
    }
}
