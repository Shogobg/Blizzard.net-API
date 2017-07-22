using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   response for talents API call
	/// </summary>
	[DataContract]
    public class TalentsResponse : ApiResponse
    {
        /// <summary>
        ///   gets or sets warrior talents
        /// </summary>
        [DataMember(Name = "1", IsRequired = false)]
        public ClassTalentInfo Warrior
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets paladin talents
        /// </summary>
        [DataMember(Name = "2", IsRequired = false)]
        public ClassTalentInfo Paladin
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets hunter talents
        /// </summary>
        [DataMember(Name = "3", IsRequired = false)]
        public ClassTalentInfo Hunter
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets rogue talents
        /// </summary>
        [DataMember(Name = "4", IsRequired = false)]
        public ClassTalentInfo Rogue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets priest talents
        /// </summary>
        [DataMember(Name = "5", IsRequired = false)]
        public ClassTalentInfo Priest
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets death knight talents
        /// </summary>
        [DataMember(Name = "6", IsRequired = false)]
        public ClassTalentInfo DeathKnight
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets shaman talents
        /// </summary>
        [DataMember(Name = "7", IsRequired = false)]
        public ClassTalentInfo Shaman
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets mage talents
        /// </summary>
        [DataMember(Name = "8", IsRequired = false)]
        public ClassTalentInfo Mage
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets warlock talents
        /// </summary>
        [DataMember(Name = "9", IsRequired = false)]
        public ClassTalentInfo Warlock
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets monk talents
        /// </summary>
        [DataMember(Name = "10", IsRequired = false)]
        public ClassTalentInfo Monk
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets druid talents
        /// </summary>
        [DataMember(Name = "11", IsRequired = false)]
        public ClassTalentInfo Druid
        {
            get;
            internal set;
        }
    }
}