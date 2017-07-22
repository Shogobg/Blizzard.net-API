
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Item set's information
    /// </summary>
    [DataContract]
    public class ItemSet : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the id of the item set.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the name of the item set.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the bonuses provided by the set.
        /// </summary>
        [DataMember(Name = "setBonuses")]
        public IList<ItemSetBonus> Bonuses
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item ids for items in the set
        /// </summary>
        [DataMember(Name = "items")]
        public IList<int> ItemIds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}