
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A hero's follower
	/// </summary>
	[DataContract]
    public class HeroFollower
    {
        /// <summary>
        /// Follower's equipped items
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower's level (recently this will always return 0, but now heroes always have same level as their followers)
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower's skills
        /// </summary>
        [DataMember(Name = "skills")]
        public IList<CharacterSkill> Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower type
        /// </summary>
        [DataMember(Name = "slug")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FollowerType FollowerType
        {
            get;
            internal set;
        }

        /// <summary>
        /// follower stat's (only adventure status are set which are bonus xp, MF and GF)
        /// </summary>
        [DataMember(Name = "stats")]
        public CharacterStats Stats
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FollowerType.ToString();
        }
    }
}
