using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Challenges response
	/// </summary>
	[DataContract]
    public class ChallengesResponse : ApiResponse
    {
        /// <summary>
        ///   gets or sets challenges
        /// </summary>
        [DataMember(Name = "challenge", IsRequired = false)]
        public IList<Challenge> Challenges
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
            return Challenges == null ? "" : Challenges.Count + " Challenges";
        }
    }
}