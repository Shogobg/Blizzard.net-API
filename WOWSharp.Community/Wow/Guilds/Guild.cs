
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents a guild's profile
    /// </summary>
    [DataContract]
    public class Guild : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the guild's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's battlegroup name
        /// </summary>
        [DataMember(Name = "battlegroup", IsRequired = true)]
        public string BattleGroupName
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's realm
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem
        /// </summary>
        [DataMember(Name = "emblem", IsRequired = false)]
        public GuildEmblem Emblem
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the guild's level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the guild's faction
        /// </summary>
        [DataMember(Name = "side", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the guild's total achievement points
        /// </summary>
        [DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets a list of all guild members
        /// </summary>
        [DataMember(Name = "members", IsRequired = false)]
        public IList<GuildMembership> Members
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets information about guild's achievements
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets guild news feed
        /// </summary>
        [DataMember(Name = "news", IsRequired = false)]
        public IList<GuildNewsItem> News
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets information about challenges completed by the guild
        /// </summary>
        [DataMember(Name = "challenge", IsRequired = false)]
        public IList<Challenge> Challenges
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
            return Name;
        }
    }
}