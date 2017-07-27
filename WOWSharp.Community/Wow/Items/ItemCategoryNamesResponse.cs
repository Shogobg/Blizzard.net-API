
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Responses response for item category names (item classes) response
    /// </summary>
    [DataContract]
    public class ItemCategoryNamesResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets item category (class) list
        /// </summary>
        [DataMember(Name = "classes", IsRequired = true)]
        public IList<ItemCategoryName> CategoryNames
        {
            get;
            internal set;
        }
    }
}