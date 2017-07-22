using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   information about a challenge
	/// </summary>
	[DataContract]
    public class Challenge
    {
        /// <summary>
        ///   gets or sets groups that completed the challenge
        /// </summary>
        [DataMember(Name = "groups", IsRequired = false)]
        public IList<ChallengeGroup> Groups
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets map
        /// </summary>
        [DataMember(Name = "map", IsRequired = false)]
        public ChallengeMap Map
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets realm
        /// </summary>
        [DataMember(Name = "realm", IsRequired = false)]
        public Realm Realm
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
            return string.Format(CultureInfo.InvariantCulture, "{0} - {1}", Map, Realm);
        }
    }
}