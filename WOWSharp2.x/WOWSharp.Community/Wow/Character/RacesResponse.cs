using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents the response returned when querying the website about character races
	/// </summary>
	[DataContract]
    public class RacesResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets a list or all character races
        /// </summary>
        [DataMember(Name = "races", IsRequired = true)]
        public IList<CharacterRace> Races
        {
            get;
            internal set;
        }
    }
}