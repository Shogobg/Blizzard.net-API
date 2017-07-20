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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents an auction house dump file
    /// </summary>
    [DataContract]
    public class AuctionFile
    {
        /// <summary>
        ///   Gets the last modified date in UTC
        /// </summary>
        private DateTime _lastModifiedUtc;

        /// <summary>
        ///   Gets or sets the dump file url
        /// </summary>
        private string _url;

        /// <summary>
        ///   Gets or sets the dump file url
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings"),
         DataMember(Name = "url", IsRequired = true)]
        public string Url
        {
            get
            {
                return _url;
            }
            internal set
            {
                _url = value;
            }
        }

        /// <summary>
        ///   Gets or sets the last modified value
        /// </summary>
        [DataMember(Name = "lastModified", IsRequired = true)]
        public long LastModifiedValue
        {
            get
            {
                return ApiClient.GetUnixTimeFromDate(LastModifiedUtc);
            }
            internal set
            {
                LastModifiedUtc = ApiClient.GetUtcDateFromUnixTime(value);
            }
        }

        /// <summary>
        ///   Gets the last modified date in UTC
        /// </summary>
        public DateTime LastModifiedUtc
        {
            get
            {
                return _lastModifiedUtc;
            }
            private set
            {
                _lastModifiedUtc = value;
            }
        }
    }
}