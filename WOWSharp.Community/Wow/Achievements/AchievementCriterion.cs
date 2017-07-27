using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   An achievement criteria
	/// </summary>
	[DataContract]
    public class AchievementCriterion
    {
        /// <summary>
        ///   Achievement criteria
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Achievement description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Order Index
        /// </summary>
        [DataMember(Name = "orderIndex")]
        public int OrderIndex
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Max
        /// </summary>
        [DataMember(Name = "max")]
        public int Max
        {
            get;
            internal set;
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            return Description;
        }
    }
}