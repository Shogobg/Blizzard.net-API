using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents the response of guild or character achievements request
	/// </summary>
	[DataContract]
    public class AchievementsResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the achievements categories. 
        ///   Note that the property name in JSON response from battle.net is called achievements, but it actually returns categories.
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = true)]
        public IList<AchievementCategory> Categories
        {
            get;
            internal set;
        }
    }
}