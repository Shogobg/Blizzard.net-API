using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Item set
	/// </summary>
	[DataContract]
    public class ItemSet
    {
		/// <summary>
		/// Item name
		/// </summary>
		[DataMember(Name = "name")]
		public string Name
		{
			get;
			internal set;
		}

		/// <summary>
		/// Item set slug
		/// </summary>
		[DataMember(Name = "slug")]
		public string Slug
		{
			get;
			internal set;
		}

		/// <summary>
		/// List of items in the set
		/// </summary>
		[DataMember(Name = "items")]
        public IList<Item> Items
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item set bonuses
        /// </summary>
        [DataMember(Name = "ranks")]
        public IList<ItemSetBonus> SetBonuses
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
