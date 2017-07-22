using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Challenge group member
	/// </summary>
	[DataContract]
    public class ChallengeGroupMember
    {
        /// <summary>
        ///   gets or sets the character information for the group member
        /// </summary>
        [DataMember(Name = "character", IsRequired = false)]
        public SimpleCharacter Character
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the spec for the group member
        /// </summary>
        [DataMember(Name = "spec", IsRequired = false)]
        public Specialization Specialization
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
            return Character == null ? "" : Character.ToString();
        }
    }
}