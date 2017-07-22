using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Information about skills selected by a character
	/// </summary>
	[DataContract]
    public class CharacterSkills
    {
        /// <summary>
        /// active skills
        /// </summary>
        [DataMember(Name = "active")]
        public IList<CharacterSkill> Active
        {
            get;
            internal set;
        }

        /// <summary>
        /// passive skills
        /// </summary>
        [DataMember(Name = "passive")]
        public IList<CharacterSkill> Passive
        {
            get;
            internal set;
        }
    }
}
