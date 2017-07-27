
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Follower infromation
	/// </summary>
	[DataContract]
    public class Follower : ApiResponse
    {
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
        /// Follower name (in client's locale)
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Follower real name (d3.follower.templar.realName)
        /// </summary>
        [DataMember(Name = "realName")]
        public string RealName
        {
            get;
            internal set;
        }

        /// <summary>
        /// follower portrait
        /// To get the image use the following format string
        /// {0} is size (Available sizes that I know of are 42 and 64)
        /// {1} is the property value returned by this property
        /// http://media.blizzard.com/d3/icons/portraits/{0}/{1}.png
        /// </summary>
        [DataMember(Name = "portrait")]
        public string Portrait
        {
            get;
            internal set;
        }

        /// <summary>
        /// The skills that the follower can learn skills
        /// </summary>
        [DataMember(Name = "skills")]
        public FollowerSkills Skills
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FollowerType.ToString();
        }
    }
}
