using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   represents a guild member
	/// </summary>
	[DataContract]
    public class GuildMembership
    {
        /// <summary>
        ///   Gets or sets Character profile of the guild member (note that all optional character profile fields are not retrieved when getting guild's profile)
        /// </summary>
        [DataMember(Name = "character", IsRequired = true)]
        public SimpleCharacter Character
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's rank in the guild. 0 is the highest rank (the guild master).
        /// </summary>
        [DataMember(Name = "rank", IsRequired = true)]
        public int Rank
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
            return Character == null ? "" : Character.ToString();
        }
    }
}