
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Item subcategory name
    /// </summary>
    [DataContract]
    public class ItemSubcategoryName
    {
        /// <summary>
        ///   Gets or sets the subcategory name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        [DataMember(Name = "subclass", IsRequired = true)]
        public int SubcategoryId
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