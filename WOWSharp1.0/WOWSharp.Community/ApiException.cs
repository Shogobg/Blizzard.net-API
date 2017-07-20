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
using System.Net;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Exception thrown when battle.net community API website returns an error message
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///   Deserialized error returned by Blizzard's community API website
        /// </summary>
        private ApiError _apiError;

        /// <summary>
        ///   HTTP response code returned by Blizzard's community API website
        /// </summary>
        private HttpStatusCode _httpStatus;

        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        /// <param name="message"> message </param>
        public ApiException(string message) : base(message)
        {
        }

        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        /// <param name="message"> message </param>
        /// <param name="inner"> exception that cause this </param>
        public ApiException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of ApiException class
        /// </summary>
        /// <param name="error"> Api error </param>
        /// <param name="httpStatus"> HTTP response status </param>
        /// <param name="inner"> Inner exception that triggered the exception </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public ApiException(ApiError error, HttpStatusCode httpStatus, Exception inner)
            : base(error != null ? error.Reason : null, inner)
        {
            ApiError = error;
            HttpStatus = httpStatus;
        }

        /// <summary>
        ///   Api status returned by Blizzard's community API website
        /// </summary>
        public string ApiStatus
        {
            get
            {
                return ApiError.Status;
            }
        }

        /// <summary>
        ///   HTTP response code returned by Blizzard's community API website
        /// </summary>
        public HttpStatusCode HttpStatus
        {
            get
            {
                return _httpStatus;
            }
            internal set
            {
                _httpStatus = value;
            }
        }

        /// <summary>
        ///   Deserialized error returned by Blizzard's community API website
        /// </summary>
        public ApiError ApiError
        {
            get
            {
                return _apiError;
            }
            internal set
            {
                _apiError = value;
            }
        }
    }
}