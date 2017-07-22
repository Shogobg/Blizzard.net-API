using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents the response returned when querying the website about character classes
	/// </summary>
	[DataContract]
    public class ClassesResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets a list or all character classes
        /// </summary>
        [DataMember(Name = "classes", IsRequired = true)]
        public IList<CharacterClass> Classes
        {
            get;
            internal set;
        }
    }
}