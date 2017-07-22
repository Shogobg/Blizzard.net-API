
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item type information
	/// </summary>
	[DataContract]
    public class ItemTypeInfo
    {
        /// <summary>
        /// Item type
        /// </summary>
        [DataMember(Name="id", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType ItemType
        {
            get;
            internal set;
        }

        /// <summary>
        /// For weapons, whether the item is two handed
        /// </summary>
        [DataMember(Name = "twoHanded", IsRequired = true)]
        public bool IsTwoHanded
        {
            get;
            internal set;
        }
    }
}
