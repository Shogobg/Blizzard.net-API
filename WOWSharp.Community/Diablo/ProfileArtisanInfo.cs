
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A character's artisan information
	/// </summary>
	[DataContract]
    public class ProfileArtisanInfo
    {
        /// <summary>
        /// Gets or sets Artisan's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
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
        /// Gets or sets the current step in the progress to the next level
        /// </summary>
        [DataMember(Name = "stepCurrent", IsRequired = true)]
        public int CurrentStep
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the maximum step (i.e. the total number of steps) required to reach the next level
        /// </summary>
        [DataMember(Name = "stepMax", IsRequired = true)]
        public int MaximumStep
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} Level {1}", ArtisanType, Level);
        }
    }
}
