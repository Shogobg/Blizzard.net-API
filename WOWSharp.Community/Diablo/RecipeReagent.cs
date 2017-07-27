using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Recipe regaend
	/// </summary>
	[DataContract]
    public class RecipeReagent
    {
        /// <summary>
        /// Reagent item
        /// </summary>
        [DataMember(Name = "item")]
        public Item Item
        {
            get;
            internal set;
        }

        /// <summary>
        /// The quantity of the item needed to craft
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quantity
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
            return Quantity.ToString(CultureInfo.InvariantCulture) + "x" + Item.Name;
        }
    }
}
