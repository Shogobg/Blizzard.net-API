using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Information about material obtained by salvaging the item
	/// </summary>
	[DataContract]
    public class ItemSalvageMaterial
    {
        /// <summary>
        /// Chance of getting this material
        /// </summary>
        [DataMember(Name = "chance", IsRequired = true)]
        public double Chance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Quantity obtained
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item obtained by salvaging
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public Item Item
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}% chance of getting {1} {2}", Chance * 100, Quantity, Item);
        }
    }
}
