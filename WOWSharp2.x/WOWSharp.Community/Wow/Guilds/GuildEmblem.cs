using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about a guild's emblem
	/// </summary>
	[DataContract]
    public class GuildEmblem
    {
        /// <summary>
        ///   Gets or sets the guild's emblem's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public int Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's icon color
        /// </summary>
        [DataMember(Name = "iconColor", IsRequired = true)]
        public string IconColor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's border style
        /// </summary>
        [DataMember(Name = "border", IsRequired = true)]
        public int Border
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's border color
        /// </summary>
        [DataMember(Name = "borderColor", IsRequired = true)]
        public string BorderColor
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem's background color
        /// </summary>
        [DataMember(Name = "backgroundColor", IsRequired = true)]
        public string BackgroundColor
        {
            get;
            internal set;
        }
    }
}