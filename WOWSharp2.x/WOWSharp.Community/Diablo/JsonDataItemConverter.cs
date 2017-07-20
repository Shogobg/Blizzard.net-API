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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// handles creation of Recipe or Item depending on TooltipParameters value
    /// If tooltip parameter starts with "recipe", creates a Recipe object
    /// If tooltip parameter starts with item, creates an Item object
    /// Otherwise fail
    /// </summary>
    internal class JsonDataItemConverter : JsonConverter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="message">message</param>
        public JsonDataItemConverter()
        {
        }

        /// <summary>
        /// Whether the converter can converts objects of a given type
        /// </summary>
        /// <param name="objectType">object type</param>
        /// <returns>true if the DataItem is assignable from object type</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType != null && typeof(Item).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Deserializes a dataItem object from stream
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="objectType">object type</param>
        /// <param name="existingValue">existing value (ignored)</param>
        /// <param name="serializer">serializer</param>
        /// <returns>Deserialized object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (serializer == null)
                throw new ArgumentNullException("serializer");

            JObject jObject = JObject.Load(reader);
            var tooltipParametersProperty = jObject["tooltipParams"];
            if (tooltipParametersProperty == null)
            {
                var itemProducedProperty = jObject["itemProduced"];
                if (itemProducedProperty != null
                    && itemProducedProperty.Type == JTokenType.Object)
                {
                    var itemProduced = itemProducedProperty.Value<JObject>();
                    tooltipParametersProperty = itemProduced["tooltipParams"];
                }
            }
            if (tooltipParametersProperty != null && tooltipParametersProperty.Type == JTokenType.String)
            {
                var tooltipParameter = tooltipParametersProperty.Value<string>();
                if (!string.IsNullOrEmpty(tooltipParameter))
                {
                    Item item = null;
                    if (tooltipParameter.StartsWith("item/", StringComparison.OrdinalIgnoreCase))
                    {
                        item = new Item();
                    }
                    if (tooltipParameter.StartsWith("recipe/", StringComparison.OrdinalIgnoreCase))
                    {
                        item = new Recipe();
                    }
                    if (item != null)
                    {
                        serializer.Populate(jObject.CreateReader(), item);
                        item.TooltipParameters = tooltipParameter;
                        item.Path = "/api/d3/data/" + tooltipParameter;
                        return item;
                    }
                }
            }
            throw new JsonSerializationException(ErrorMessages.FailedToDeserializeDataItem);
        }

        /// <summary>
        /// Prevent this converter from being used for writing
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Write json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException(ErrorMessages.DataItemConverterCannotWrite);
        }
    }
}
