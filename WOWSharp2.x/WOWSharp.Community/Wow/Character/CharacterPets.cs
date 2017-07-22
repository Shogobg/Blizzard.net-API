using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Information about character's collected pets
	/// </summary>
	[DataContract]
    public class CharacterPets
    {
        /// <summary>
        ///   gets or sets a collection of collected pets
        /// </summary>
        [DataMember(Name = "collected", IsRequired = false)]
        public IList<Pet> Collected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of collected pets
        /// </summary>
        [DataMember(Name = "numCollected", IsRequired = false)]
        public int CollectedCount
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of non collected pets
        /// </summary>
        [DataMember(Name = "numNotCollected", IsRequired = false)]
        public int NotCollectedCount
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return CollectedCount + " pets collected";
        }
    }
}