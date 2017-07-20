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
using System.Net;
using System.Security.Permissions;

namespace WOWSharp.Community
{
    /// <summary>
    /// Exception thrown when WOW community API website returns an error message
    /// </summary>
    [Serializable]
    public class WoWAPIException : Exception
    {
        /// <summary>
        /// Constructor. Initializes a new instance of WoWAPIException class
        /// </summary>
        /// <param name="error">Api error</param>
        /// <param name="httpStatus">HTTP response status</param>
        /// <param name="inner">Inner exception that triggered the exception</param>
        public WoWAPIException(ApiError error, HttpStatusCode httpStatus, Exception inner) : base(error.Reason, inner)
        {
            this.ApiError = error;
            this.HttpStatus = httpStatus;
        }
        
        /// <summary>
        /// Api status returned by Blizzard's community API website
        /// </summary>
        public string ApiStatus
        {
            get
            {
                return this.ApiError.Status;
            }
        }

        /// <summary>
        /// HTTP response code returned by Blizzard's community API website
        /// </summary>
        public HttpStatusCode HttpStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Deserialized error returned by Blizzard's community API website
        /// </summary>
        public ApiError ApiError
        {
            get;
            set;
        }
#if !SILVERLIGHT
        /// <summary>
        /// Constructor. This constructor is called to deserialize a WoWApiException object
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">context</param>
        protected WoWAPIException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ApiError = (ApiError)info.GetValue("ApiError", typeof(ApiError));
            this.HttpStatus = (HttpStatusCode)info.GetInt32("HttpStatus");
        }

        /// <summary>
        /// Serializes the exception object
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">context</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ApiError", this.ApiError);
            info.AddValue("HttpStatus", (int)this.HttpStatus);
        }
#endif
    }
}
