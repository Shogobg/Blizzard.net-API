using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents an achievement category
	/// </summary>
	[DataContract]
    public class AchievementCategory
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
        ///   Gets or sets the achievement category name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the subcategories of this category
        /// </summary>
        [DataMember(Name = "categories", IsRequired = false)]
        public IList<AchievementCategory> Categories
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the achievements under this category
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public IList<Achievement> Achievements
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