using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents the response for the guild perks request
	/// </summary>
	[DataContract]
    public class GuildPerksResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the list of guild perk spells
        /// </summary>
        [DataMember(Name = "perks", IsRequired = true)]
        public IList<GuildPerk> Perks
        {
            get;
            internal set;
        }
    }
}