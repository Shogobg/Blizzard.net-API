using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   represents an item category name (using the client's locale)
	/// </summary>
	[DataContract]
    public class ItemCategoryName
    {
        /// <summary>
        ///   Gets or sets the category
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        public ItemCategory Category
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the category name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the subcategories for this category
        /// </summary>
        [DataMember(Name = "subclasses")]
        public IList<ItemSubcategoryName> Subcategories
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