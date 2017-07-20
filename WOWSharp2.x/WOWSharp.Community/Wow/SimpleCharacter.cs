// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
    public class SimpleCharacter
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
        ///   Gets or sets the race id of the character
        /// </summary>
        [DataMember(Name = "race", IsRequired = true)]
        public Race Race
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets the character faction
        /// </summary>
        public Faction Faction
        {
            get
            {
                if (Race == Race.NeutralPandaren)
                    return Faction.Neutral;
                return Race == Race.Worgen
                       || Race == Race.NightElf
                       || Race == Race.Human
                       || Race == Race.Gnome
                       || Race == Race.Dwarf
                       || Race == Race.Draenei
                       || Race == Race.AlliancePandaren
                           ? Faction.Alliance
                           : Faction.Horde;
            }
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