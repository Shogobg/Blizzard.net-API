using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   represents information about a character's rated battleground and arena ratings
	/// </summary>
	[DataContract]
    public class CharacterPvpInformation
    {
        /// <summary>
        /// Gets or sets Character's PVP bracket information
        /// </summary>
        [DataMember(Name = "brackets", IsRequired = true)]
        public CharacterPvpBrackets Brackets
        {
            get;
            internal set;
        }
    }
}