
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents an item's source
    /// </summary>
    [DataContract]
    public class ItemSource
    {
        /// <summary>
        ///   Gets or sets the item source id
        /// </summary>
        [DataMember(Name = "sourceId", IsRequired = true)]
        public int SourceId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item source type
        /// </summary>
        [DataMember(Name = "sourceType", IsRequired = true)]
        public string SourceType
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
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", SourceType, SourceId);
        }
    }
}