using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Diablo profile progression
	/// </summary>
	[DataContract]
    public class ProfileProgression
    {
        /// <summary>
        /// Whether the player completed act1
        /// </summary>
        [DataMember(Name = "act1", IsRequired = true)]
        public bool Act1
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act2
        /// </summary>
        [DataMember(Name = "act2", IsRequired = true)]
        public bool Act2
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act3
        /// </summary>
        [DataMember(Name = "act3", IsRequired = true)]
        public bool Act3
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act4
        /// </summary>
        [DataMember(Name = "act4", IsRequired = true)]
        public bool Act4
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the player completed act5
        /// </summary>
        [DataMember(Name = "act5", IsRequired = true)]
        public bool Act5
        {
            get;
            set;
        }
    }
}
