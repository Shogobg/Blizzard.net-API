/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;


namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents character profile information
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Character : ApiResponse
    {
        /// <summary>
        /// Gets or sets the realm name to which the character belongs
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or set the character name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time stamp at which the character was last modified (typically logout time)
        /// </summary>
        [DataMember(Name = "lastModified", IsRequired = false)]
        public long LastModifiedValue
        {
            get
            {
                return ApiClient.GetUnixTimeFromDate(this.LastModifiedUtc);
            }
            set
            {
                this.LastModifiedUtc = ApiClient.GetUtcDateFromUnixTime(value);
            }
        }

        /// <summary>
        /// Gets or sets the thumbnail image for the character
        /// </summary>
        [DataMember(Name = "thumbnail", IsRequired = true)]
        public string Thumbnail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the race id of the character
        /// </summary>
        [DataMember(Name = "race", IsRequired = true)]
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the character faction
        /// </summary>
        public Faction Faction
        {
            get
            {
                return this.Race == Race.Worgen
                    || this.Race == Race.NightElf
                    || this.Race == Race.Human
                    || this.Race == Race.Gnome
                    || this.Race == Race.Dwarf ? Faction.Alliance : Faction.Horde;
            }
        }

        /// <summary>
        /// Gets or set the total achievevement points for the character
        /// </summary>
        [DataMember(Name = "achievementPoints", IsRequired = true)]
        public int AchievementPoints
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's gender
        /// </summary>
        [DataMember(Name = "gender", IsRequired = true)]
        public CharacterGender Gender
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the class id of the character
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        public Class Class
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [DataMember(Name = "guild", IsRequired = false)]
        public CharacterGuild Guild
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the items currently equipped by the character. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the current character's stats. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public CharacterStats Stats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about the character specialization and talent. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "talents", IsRequired = false)]
        public CharacterTalents[] Talents
        {
            get;
            set;
        }

        /// <summary>
        /// Get or sets information about character's reputation is all factions the character interacted with. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "reputation", IsRequired = false)]
        public CharacterReputation[] Reputations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection or character's titles. %s is replaced by character's name when displaying the title. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "titles", IsRequired = false)]
        public CharacterTitle[] Titles
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about character's current professions and skil level. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "professions", IsRequired = false)]
        public CharacterProfessions Professions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about character's appearance. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "appearance", IsRequired = false)]
        public CharacterAppearance Appearance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of character's companions (The ids of the companions is returned). This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "companions", IsRequired = false)]
        public int[] Companions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of character's mounts (ids of mounts). This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "mounts", IsRequired = false)]
        public int[] Mounts
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of character's combat pets (hunters). This can be null if the field is not requested while requesting the character profile data or if the character is a class not having pets.
        /// </summary>
        [DataMember(Name = "pets", IsRequired = false)]
        public CharacterPet[] Pets
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current character's achievments. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the current character's progression. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public CharacterProgression Progression
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the ids of the quests the character has completed
        /// </summary>
        [DataMember(Name = "quests", IsRequired = false)]
        public int[] CompletedQuestIds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the character Pvp stats
        /// </summary>
        [DataMember(Name = "pvp", IsRequired = false)]
        public CharacterPvpInformation Pvp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns>Gets string representation (for debugging purposes)</returns>
        public override string ToString()
        {
            return string.Format("{0}@{1} Level {2} {3} {4} {5}",
                this.Name, this.Realm, this.Level, this.Gender, this.Race, this.Class);
        }
    }
}

