using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Information about mounts collected by a character
	/// </summary>
	[DataContract]
    public class CharacterMounts
    {
        /// <summary>
        ///   gets or sets the collection of collected mounts
        /// </summary>
        [DataMember(Name = "collected", IsRequired = false)]
        public IList<Mount> Collected
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the number of collected mounts
        /// </summary>
        [DataMember(Name = "numCollected", IsRequired = false)]
        public int CollectedCount
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of not collected mounts
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
            return CollectedCount + " mounts collected";
        }
    }
}