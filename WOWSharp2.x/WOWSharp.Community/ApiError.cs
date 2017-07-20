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
using System.Runtime.Serialization;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Represents an error returned in the content of a failed request by the battle.net community API
    /// </summary>
    [DataContract]
    public class ApiError : ApiResponse
    {
        /// <summary>
        ///   Error reason as returned by the Blizzard's battle.net community API
        /// </summary>
        private string _reason;

        /// <summary>
        ///   Error status as returned by the Blizzard's battle.net community API
        /// </summary>
        private string _status;

        /// <summary>
        ///   Default constructor
        /// </summary>
        public ApiError()
        {
        }

        /// <summary>
        ///   constructor
        /// </summary>
        /// <param name="status"> error status </param>
        /// <param name="reason"> error reason </param>
        public ApiError(string status, string reason)
        {
            Status = status;
            Reason = reason;
        }

        /// <summary>
        ///   Error status as returned by the Blizzard's battle.net community API
        /// </summary>
        [DataMember(IsRequired = true, Name = "status")]
        public string Status
        {
            get
            {
                return _status;
            }
            internal set
            {
                _status = value;
            }
        }

        /// <summary>
        ///   Error reason as returned by the Blizzard's battle.net community API
        /// </summary>
        [DataMember(IsRequired = true, Name = "reason")]
        public string Reason
        {
            get
            {
                return _reason;
            }
            internal set
            {
                _reason = value;
            }
        }
    }
}