using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents gem's bonus
	/// </summary>
	[DataContract]
    public class GemBonus
    {
        /// <summary>
        ///   The socket bonus description (e.g. "+20 Agility and +20 Hit Rating")
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets source item id. This is the same as item id for the gem
        /// </summary>
        [DataMember(Name = "srcItemId", IsRequired = true)]
        public int SourceItemId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets The required skill
        /// </summary>
        [DataMember(Name = "requiredSkillId", IsRequired = true)]
        public Skill RequiredSkillId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required skill rank
        /// </summary>
        [DataMember(Name = "requiredSkillRank", IsRequired = true)]
        public int RequiredSkillRank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required gem's item level
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = true)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the required level for the gem
        /// </summary>
        [DataMember(Name = "minLevel", IsRequired = false)]
        public int MinimumLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}