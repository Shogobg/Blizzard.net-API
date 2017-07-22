using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   challenge map
	/// </summary>
	[DataContract]
    public class ChallengeMap
    {
        /// <summary>
        ///   gets or sets whether the map has a challenge mode
        /// </summary>
        [DataMember(Name = "hasChallengeMode", IsRequired = false)]
        public bool HasChallengeMode
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets id of the map
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name of the map
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets slug for the map
        /// </summary>
        [DataMember(Name = "slug", IsRequired = false)]
        public string Slug
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets bronze criteria
        /// </summary>
        [DataMember(Name = "bronzeCriteria", IsRequired = false)]
        public ChallengeCompletionTime BronzeCriteria
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets silver criteria
        /// </summary>
        [DataMember(Name = "silverCriteria", IsRequired = false)]
        public ChallengeCompletionTime SilverCriteria
        {
            get;
            internal set;
        }


        /// <summary>
        ///   gets or sets gold criteria
        /// </summary>
        [DataMember(Name = "goldCriteria", IsRequired = false)]
        public ChallengeCompletionTime GoldCriteria
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
            return Name;
        }
    }
}