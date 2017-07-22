using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Information about an equipped item upgrade
	/// </summary>
	[DataContract]
    public class EquippedItemUpgrade
    {
        /// <summary>
        /// Gets or sets the current number of upgrades made on the item
        /// </summary>
        [DataMember(Name = "current", IsRequired = false)]
        public int Current
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the total number of upgrades possible on the item
        /// </summary>
        [DataMember(Name = "total", IsRequired = false)]
        public int Total
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the item level increment of the upgraded item
        /// </summary>
        [DataMember(Name = "itemLevelIncrement", IsRequired = false)]
        public int ItemLevelIncrement
        {
            get;
            internal set;
        }
    }
}
