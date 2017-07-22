using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Diablo Recipe
	/// </summary>
	[DataContract]
    public class Recipe : Item
    {
        /// <summary>
        /// Crafting cost in gold
        /// </summary>
        [DataMember(Name = "cost")]
        public long Cost
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item produced by the recipe
        /// </summary>
        [DataMember(Name = "itemProduced")]
        public Item ItemProduced
        {
            get;
            internal set;
        }

        /// <summary>
        /// Reagents needed to craft the item
        /// </summary>
        [DataMember(Name = "reagents")]
        public IList<RecipeReagent> Reagents
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
            return "Recipe: " + Name;
        }
    }
}
