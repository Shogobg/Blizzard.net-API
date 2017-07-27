using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   response to pet types API
	/// </summary>
	[DataContract]
    public class BattlePetTypesResponse : ApiResponse
    {
        /// <summary>
        ///   gets or sets pet types
        /// </summary>
        [DataMember(Name = "petTypes", IsRequired = false)]
        public IList<BattlePetType> PetTypes
        {
            get;
            internal set;
        }
    }
}