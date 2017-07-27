
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Information about character class
    /// </summary>
    [DataContract]
    public class CharacterClass
    {
        /// <summary>
        ///   Gets or sets class id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public ClassKey Class
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets class mask (No Idea what that's used for)
        /// </summary>
        [DataMember(Name = "mask", IsRequired = true)]
        public int Mask
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the class' power type
        /// </summary>
        [DataMember(Name = "powerType", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerType PowerType
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the class name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets class name
        /// </summary>
        /// <returns> Gets class name (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}