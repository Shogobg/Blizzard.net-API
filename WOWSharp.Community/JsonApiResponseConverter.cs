using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace WOWSharp.Community
{
	/// <summary>
	/// Handles deserialization of ApiResponse object and 
	/// sets the client and lastmodified properties
	/// </summary>
	internal class JsonApiResponseConverter : JsonConverter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="message">message</param>
        public JsonApiResponseConverter(ApiClient client, HttpResponseMessage message)
        {
			ApiClient = client;
			ResponseMessage = message;
        }

        /// <summary>
        /// ApiClient object
        /// </summary>
        public ApiClient ApiClient
        {
            get;
            private set;
        }

        /// <summary>
        /// Http Response message
        /// </summary>
        public HttpResponseMessage ResponseMessage
        {
            get;
            private set;
        }

        /// <summary>
        /// Return false for objects other than ApiResponse classes
        /// </summary>
        /// <param name="objectType">object type</param>
        /// <returns>false for objects other than ApiResponse classes</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType != null && typeof(ApiResponse).IsAssignableFrom(objectType);
        }


        /// <summary>
        /// Parses the object and sets the client and LastModified properties
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">object type</param>
        /// <param name="existingValue">existing value</param>
        /// <param name="serializer">serializer</param>
        /// <returns>Parsed object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}

            ApiResponse response = (ApiResponse)Activator.CreateInstance(objectType);

            serializer.Populate(reader, response);

            SetResponseLastModifiedDate(ResponseMessage, response);

            return response;
        }

        /// <summary>
        /// Sets the response's lastModifiedUtc property
        /// </summary>
        /// <param name="responseMessage">response message</param>
        /// <param name="apiResponseResult">response object</param>
        internal static void SetResponseLastModifiedDate(HttpResponseMessage responseMessage, ApiResponse apiResponseResult)
        {
            if (apiResponseResult.LastModifiedUtc == DateTime.MinValue)
            {
                apiResponseResult.LastModifiedUtc = DateTime.UtcNow;
                IEnumerable<string> lastModifiedHeaders;

                if (responseMessage.Headers.TryGetValues("Last-Modified", out lastModifiedHeaders))
                {
                    if (lastModifiedHeaders != null)
                    {
                        var lastModifiedHeaderString = lastModifiedHeaders.FirstOrDefault();

                        if (!string.IsNullOrWhiteSpace(lastModifiedHeaderString))
                        {
                            DateTime date;
                            if (DateTime.TryParseExact(
								lastModifiedHeaderString,
								"R",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.AdjustToUniversal |
                                DateTimeStyles.AllowInnerWhite |
                                DateTimeStyles.AllowLeadingWhite |
                                DateTimeStyles.AllowTrailingWhite |
                                DateTimeStyles.AssumeUniversal,
                                out date))
                            {
                                apiResponseResult.LastModifiedUtc = date;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Prevent the object from being used for writing
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Throws not supported (this can only be used for reading)
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">value</param>
        /// <param name="serializer">serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException(ErrorMessages.JsonApiResponseConverterCannotWrite);
        }
    }
}
