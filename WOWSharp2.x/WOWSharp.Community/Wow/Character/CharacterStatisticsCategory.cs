using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Character career statistics category
	/// </summary>
	[DataContract]
    public class CharacterStatisticsCategory
    {
        /// <summary>
        /// Get or sets Category id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the category name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or set the SubCategories of the category
        /// </summary>
        [DataMember(Name = "subCategories", IsRequired = false)]
        public IList<CharacterStatisticsCategory> Subcategories
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the statistics in this category
        /// </summary>
        [DataMember(Name = "statistics", IsRequired = false)]
        public IList<CharacterStatistic> Statistics
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
            return Name;
        }
    }
}
