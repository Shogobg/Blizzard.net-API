using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Follower Skills
	/// </summary>
	[DataContract]
    public class FollowerSkills
    {
        /// <summary>
        /// Active skills
        /// </summary>
        [DataMember(Name = "active")]
        public IList<Skill> Active
        {
            get;
            internal set;
        }

        /// <summary>
        /// Passive skills
        /// </summary>
        [DataMember(Name = "passive")]
        public IList<Skill> Passive
        {
            get;
            internal set;
        }
    }
}
