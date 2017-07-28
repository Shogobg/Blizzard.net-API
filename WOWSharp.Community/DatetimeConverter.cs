
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace WOWSharp.Community
{
	/// <summary>
	/// Converts a unix time to date and vice versa
	/// </summary>
	internal abstract class DatetimeConverter : JsonConverter
    {
        /// <summary>
        /// Whether the timestamp value is in milliseconds
        /// </summary>
        private readonly bool _isMilliseconds;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isMilliseconds">Whether the timestamp value is in milliseconds</param>
        protected DatetimeConverter(bool isMilliseconds)
        {
            _isMilliseconds = isMilliseconds;
        }

        /// <summary>
        /// Whether the converter can convert a type or not
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(DateTime);
        }

        /// <summary>
        /// Read the value from Json reader and converts it to datetime
        /// </summary>
        /// <param name="reader">Json reader</param>
        /// <param name="objectType">object type (should always be datetime)</param>
        /// <param name="existingValue">existing value Ignored. (should always be DateTime.MinValue).</param>
        /// <param name="serializer">serializer object (used to read settings)</param>
        /// <returns>Deserialized object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(IList<DateTime>) || objectType == typeof(IList<DateTime?>))
            {
                var elementType = objectType.GetGenericArguments()[0];

				if (reader.TokenType == JsonToken.Null)
				{
					return null;
				}
				else if (reader.TokenType == JsonToken.StartArray)
				{
					IList list;

					if (elementType == typeof(DateTime))
					{
						list = new List<DateTime>();
					}
					else
					{
						list = new List<DateTime?>();
					}

					while (reader.Read())
					{
						if (reader.TokenType == JsonToken.EndArray)
						{
							break;
						}

						list.Add(ReadDateToken(reader, elementType));
					}
					return list;
				}
				else
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
						ErrorMessages.UnexpectedTokenType, reader.TokenType, JsonToken.StartArray));
				}
            }
            else if (objectType != typeof(DateTime) && objectType != typeof(DateTime?))
            {
                throw new ArgumentException(
                   string.Format(CultureInfo.CurrentCulture,
                   ErrorMessages.UnsupportedConversionType, objectType.FullName));
            }

            return ReadDateToken(reader, objectType);
        }

        /// <summary>
        /// Reads a date token from a JSON reader
        /// </summary>
        /// <param name="reader">json reader</param>
        /// <param name="objectType">object type</param>
        /// <returns>date object</returns>
        private object ReadDateToken(JsonReader reader, Type objectType)
        {
			if (objectType == typeof(DateTime?) && reader.TokenType == JsonToken.Null)
			{
				return null;
			}

            if (reader.TokenType == JsonToken.Date)
            {
                return reader.ReadAsDateTime();
            }

            if (reader.TokenType != JsonToken.Integer)
            {
                throw new ArgumentException(
                   string.Format(CultureInfo.CurrentCulture,
                   ErrorMessages.UnexpectedTokenType, reader.TokenType, JsonToken.Integer));
            }

			var value = Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture);

			if (_isMilliseconds)
            {
                return ApiClient.GetUtcDateFromUnixTimeMilliseconds(value);
            }
            else
            {
                return ApiClient.GetUtcDateFromUnixTimeSeconds(value);
            }
        }

        /// <summary>
        /// Writes a value to json stream
        /// </summary>
        /// <param name="writer">json writer</param>
        /// <param name="value">value to write</param>
        /// <param name="serializer">serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			if (value == null)
			{
				writer.WriteNull();
			}
			else if (value is DateTime)
			{
				var date = (DateTime)value;
				if (_isMilliseconds)
				{
					writer.WriteValue(ApiClient.GetUnixTimeFromDateMilliseconds(date));
				}
				else
				{
					writer.WriteValue(ApiClient.GetUnixTimeFromDateSeconds(date));
				}
			}
			else if (value is long)
			{
				writer.WriteValue((long)value);
			}
			else
			{
				var dateTimeList = value as IList<DateTime>;
				if (dateTimeList != null)
				{
					writer.WriteStartArray();
					foreach (var date in dateTimeList)
					{
						if (_isMilliseconds)
						{
							writer.WriteValue(ApiClient.GetUnixTimeFromDateMilliseconds(date));
						}
						else
						{
							writer.WriteValue(ApiClient.GetUnixTimeFromDateSeconds(date));
						}
					}
					writer.WriteEndArray();
				}
				else
				{
					var nullableDateTimeList = value as IList<DateTime?>;

					if (nullableDateTimeList != null)
					{
						writer.WriteStartArray();

						foreach (var date in nullableDateTimeList)
						{
							if (!date.HasValue)
							{
								writer.WriteNull();
							}
							else if (_isMilliseconds)
							{
								writer.WriteValue(ApiClient.GetUnixTimeFromDateMilliseconds(date.GetValueOrDefault()));
							}
							else
							{
								writer.WriteValue(ApiClient.GetUnixTimeFromDateSeconds(date.GetValueOrDefault()));
							}
						}

						writer.WriteEndArray();
					}
					else
					{
						throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture,
						   ErrorMessages.UnsupportedConversionType, value.GetType().FullName));
					}
				}
			}
        }
    }
}