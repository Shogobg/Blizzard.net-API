
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Artisan's information
	/// </summary>
	[DataContract]
    public class ArtisanInfo : ApiResponse
    {
        // <summary>
        /// Gets or sets artisan's type
        /// </summary>
        [DataMember(Name = "slug", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ArtisanType ArtisanType
        {
            get;
            internal set;
        }

        /// <summary>
        /// artisan name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// artisan portrait
        /// To get the image use the following format string
        /// {0} is size (Available sizes that I know of are 42 and 64)
        /// {1} is the property value returned by this property
        /// http://media.blizzard.com/d3/icons/portraits/{0}/{1}.png
        /// </summary>
        [DataMember(Name = "portrait")]
        public string Portrait
        {
            get;
            internal set;
        }

        /// <summary>
        /// Artisan's training information
        /// </summary>
        [DataMember(Name = "training")]
        public ArtisanTraining Training
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
