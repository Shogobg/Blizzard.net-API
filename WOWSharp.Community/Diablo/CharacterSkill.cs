using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Character skill
	/// </summary>
	[DataContract]
    public class CharacterSkill
    {
        /// <summary>
        /// Skill 
        /// </summary>
        [DataMember(Name = "skill")]
        public Skill Skill
        {
            get;
            internal set;
        }

        /// <summary>
        /// Rune (will be null for passive skills)
        /// </summary>
        [DataMember(Name = "rune", IsRequired = false)]
        public Rune Rune
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Skill.Name + (Rune == null ? "" : "/" + Rune.Name);
        }
    }
}
