using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents character progression
	/// </summary>
	[DataContract]
    public class CharacterProgression
    {
        /// <summary>
        ///   Gets or sets character's raid progression
        /// </summary>
        [DataMember(Name = "raids", IsRequired = false)]
        public IList<CharacterInstanceProgression> Raids
        {
            get;
            internal set;
        }
    }
}