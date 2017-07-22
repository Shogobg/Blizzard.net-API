using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about talent points spent in a tree
	/// </summary>
	[DataContract]
    public class CharacterTalent
    {
        /// <summary>
        ///   Gets or sets the tier of the talent (0-5)
        /// </summary>
        [DataMember(Name = "tier", IsRequired = true)]
        public int Tier
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the column of the talent (0-2)
        /// </summary>
        [DataMember(Name = "column", IsRequired = true)]
        public int Column
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell for the talent
        /// </summary>
        [DataMember(Name = "spell", IsRequired = true)]
        public Spell Spell
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
            return Spell.Name;
        }
    }
}