using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about a character's equipped item
	/// </summary>
	[DataContract]
    public class EquippedItem
    {
        /// <summary>
        ///   Gets or sets the item's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int ItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's level 
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = true)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the item name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item quality
        /// </summary>
        [DataMember(Name = "quality", IsRequired = true)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about gems, enchants, reforging and tinkers
        /// </summary>
        [DataMember(Name = "tooltipParams", IsRequired = false)]
        public EquippedItemParameters Parameters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the equipped item stats
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public IList<ItemStat> Stats
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        [DataMember(Name = "weaponInfo", IsRequired = false)]
        public WeaponInfo WeaponInfo
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = false)]
        public int Armor
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