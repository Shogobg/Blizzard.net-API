
using System;
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