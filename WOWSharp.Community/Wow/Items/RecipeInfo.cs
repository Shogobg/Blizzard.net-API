
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about recipe
    /// </summary>
    [DataContract]
    public class RecipeInfo : ApiResponse
    {
        /// <summary>
        ///   Recipe id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Recipe icon
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Recipe name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Profession name
        /// </summary>
        [DataMember(Name = "profession")]
        public string ProfessionName
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