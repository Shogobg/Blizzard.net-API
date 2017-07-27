using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Hero's followers
	/// </summary>
	[DataContract]
    public class HeroFollowers
    {
        /// <summary>
        /// Enchantress
        /// </summary>
        [DataMember(Name = "enchantress")]
        public HeroFollower Enchantress
        {
            get;
            internal set;
        }

        /// <summary>
        /// Scoundrel
        /// </summary>
        [DataMember(Name = "scoundrel")]
        public HeroFollower Scoundrel
        {
            get;
            internal set;
        }

        /// <summary>
        /// Templar
        /// </summary>
        [DataMember(Name = "templar")]
        public HeroFollower Templar
        {
            get;
            internal set;
        }
    }
}
