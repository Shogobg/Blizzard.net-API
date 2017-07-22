using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about character's instance progression
	/// </summary>
	[DataContract]
    public class CharacterInstanceProgression
    {
        /// <summary>
        ///   Gets or sets the instance name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the instance
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's current progression status in the normal mode for the instance
        /// </summary>
        [DataMember(Name = "normal", IsRequired = false)]
        public CharacterInstanceStatus NormalProgress
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's current progression status in the heroic mode for the instance
        /// </summary>
        [DataMember(Name = "heroic", IsRequired = false)]
        public CharacterInstanceStatus HeroicProgress
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about character individual boss kills in the instance
        /// </summary>
        [DataMember(Name = "bosses", IsRequired = false)]
        public IList<CharacterBossKills> Bosses
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} Normal:{1} Heroic:{2}", Name, NormalProgress,
                                 HeroicProgress);
        }
    }
}