using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
                        item.Path = "/d3/data/" + tooltipParameter;
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
