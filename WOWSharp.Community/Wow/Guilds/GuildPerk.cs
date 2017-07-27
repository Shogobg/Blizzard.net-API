using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a guild perk
	/// </summary>
	[DataContract]
    public class GuildPerk
    {
        /// <summary>
        ///   Gets or sets the perk's guild level
        /// </summary>
        [DataMember(Name = "guildLevel", IsRequired = true)]
        public int GuildLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the perk's spell
        /// </summary>
        [DataMember(Name = "spell", IsRequired = false)]
        public Spell Spell
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debug purposes
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return Spell == null ? "" : Spell.ToString();
        }
    }
}