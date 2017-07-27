
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents quest information
    /// </summary>
    [DataContract]
    public class Quest : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        [DataMember(Name = "title", IsRequired = true)]
        public string Title
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the required level
        /// </summary>
        [DataMember(Name = "reqLevel", IsRequired = false)]
        public int RequiredLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the number of suggested party members
        /// </summary>
        [DataMember(Name = "suggestedPartyMembers", IsRequired = false)]
        public int SuggestedPartyMembers
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the quest's category
        /// </summary>
        [DataMember(Name = "category", IsRequired = false)]
        public string Category
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the quest's level (I am guessing that's the recommended level?)
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
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
            return Title;
        }
    }
}