
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   A characters specialization
    /// </summary>
    [DataContract]
    public class Specialization
    {
        /// <summary>
        ///   Gets or sets the name of the spec
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the role of the spec
        /// </summary>
        [DataMember(Name = "role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CharacterRoles Role
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the name of the background image of the spec
        /// </summary>
        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the name of the icon image of the spec
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the description of the spec
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the order of the spec within the other specs of the class
        /// </summary>
        [DataMember(Name = "order")]
        public int Order
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}