
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Challenge mode group member character information (this is the same info as Character class),
    ///   however rather than returning guild member as guild info, this API returns guild as a string containing guild name
    ///   hence the different class
    /// </summary>
    [DataContract]
    public class SimpleCharacter : CharacterBase
    {
        /// <summary>
        ///   Gets or sets the realm name to which the character belongs
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the realm name guild to which the character belongs 
        ///   (can be different from realm in case of connected realms)
        /// </summary>
        [DataMember(Name = "guildRealm", IsRequired = false)]
        public string GuildRealm
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets the character name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character battle group name
        /// </summary>
        [DataMember(Name = "battlegroup", IsRequired = false)]
        public string BattleGroupName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the thumbnail image for the character
        /// </summary>
        [DataMember(Name = "thumbnail", IsRequired = true)]
        public string Thumbnail
        {
            get;
            internal set;
        }

		/// <summary>
		///   Gets or sets the total achievevement points for the character
		/// </summary>
		[DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's gender
        /// </summary>
        [DataMember(Name = "gender", IsRequired = true)]
        public CharacterGender Gender
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the class id of the character
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        public ClassKey Class
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [DataMember(Name = "guild", IsRequired = false)]
        public string Guild
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the spec for the group member
        /// </summary>
        [DataMember(Name = "spec", IsRequired = false)]
        public Specialization Specialization
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
            return string.Format(CultureInfo.CurrentCulture, "{0}@{1} Level {2} {3} {4} {5}",
                                 Name, Realm, Level, Gender, Race, Class);
        }
    }
}