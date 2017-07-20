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

using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents character profile information
    /// </summary>
    [DataContract]
    public class Character : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the total achievevement points for the character
        /// </summary>
        private int _achievementPoints;

        /// <summary>
        ///   Gets or sets the current character's achievments. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private Achievements _achievements;

        /// <summary>
        ///   Gets or sets information about character's appearance. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private CharacterAppearance _appearance;

        /// <summary>
        ///   Gets or sets the class id of the character
        /// </summary>
        private ClassKey _class;

        /// <summary>
        ///   ids of completed quests
        /// </summary>
        private IList<int> _completedQuestsIds;

        /// <summary>
        ///   feeds
        /// </summary>
        private IList<FeedItem> _feed;

        /// <summary>
        ///   Gets or sets the character's gender
        /// </summary>
        private CharacterGender _gender;

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        private CharacterGuild _guild;

        /// <summary>
        ///   hunter pets
        /// </summary>
        private IList<HunterPet> _hunterPets;

        /// <summary>
        ///   Gets or sets the items currently equipped by the character. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private CharacterItems _items;

        /// <summary>
        ///   Gets or sets the character level
        /// </summary>
        private int _level;

        /// <summary>
        ///   mounts field
        /// </summary>
        private CharacterMounts _mounts;

        /// <summary>
        ///   Gets or sets the character name
        /// </summary>
        private string _name;

        /// <summary>
        ///   pet slots
        /// </summary>
        private IList<CharacterPetSlot> _petSlots;

        /// <summary>
        ///   Pets field
        /// </summary>
        private CharacterPets _pets;

        /// <summary>
        ///   Gets or sets information about character's current professions and skil level. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private CharacterProfessions _professions;

        /// <summary>
        ///   Gets or sets the current character's progression. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private CharacterProgression _progression;

        /// <summary>
        ///   Gets or sets the character Pvp stats
        /// </summary>
        private CharacterPvpInformation _pvp;

        /// <summary>
        ///   Gets or sets the race id of the character
        /// </summary>
        private Race _race;

        /// <summary>
        ///   Gets or sets the realm name to which the character belongs
        /// </summary>
        private string _realm;

        /// <summary>
        ///   Reputations field
        /// </summary>
        private IList<CharacterReputation> _reputations;

        /// <summary>
        ///   Gets or sets the current character's stats. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        private CharacterStats _stats;

        /// <summary>
        ///   Talents field
        /// </summary>
        private IList<CharacterTalents> _talents;

        /// <summary>
        ///   Gets or sets the thumbnail image for the character
        /// </summary>
        private string _thumbnail;

        /// <summary>
        ///   titles field
        /// </summary>
        private IList<CharacterTitle> _titles;

        /// <summary>
        ///   Gets or sets the character total honorable kills
        /// </summary>
        private int _totalHonorableKills;

        /// <summary>
        ///   Gets or sets the realm name to which the character belongs
        /// </summary>
        [DataMember(Name = "realm", IsRequired = true)]
        public string Realm
        {
            get
            {
                return _realm;
            }
            internal set
            {
                _realm = value;
            }
        }


        /// <summary>
        ///   Gets or sets the character name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                _name = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character level
        /// </summary>
        [DataMember(Name = "level", IsRequired = true)]
        public int Level
        {
            get
            {
                return _level;
            }
            internal set
            {
                _level = value;
            }
        }

        /// <summary>
        ///   Gets or sets the time stamp at which the character was last modified (typically logout time)
        /// </summary>
        [DataMember(Name = "lastModified", IsRequired = false)]
        public long LastModifiedValue
        {
            get
            {
                return ApiClient.GetUnixTimeFromDate(LastModifiedUtc);
            }
            internal set
            {
                LastModifiedUtc = ApiClient.GetUtcDateFromUnixTime(value);
            }
        }

        /// <summary>
        ///   Gets or sets the thumbnail image for the character
        /// </summary>
        [DataMember(Name = "thumbnail", IsRequired = true)]
        public string Thumbnail
        {
            get
            {
                return _thumbnail;
            }
            internal set
            {
                _thumbnail = value;
            }
        }

        /// <summary>
        ///   Gets or sets the race id of the character
        /// </summary>
        [DataMember(Name = "race", IsRequired = true)]
        public Race Race
        {
            get
            {
                return _race;
            }
            internal set
            {
                _race = value;
            }
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
            get
            {
                return _achievementPoints;
            }
            internal set
            {
                _achievementPoints = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's gender
        /// </summary>
        [DataMember(Name = "gender", IsRequired = true)]
        public CharacterGender Gender
        {
            get
            {
                return _gender;
            }
            internal set
            {
                _gender = value;
            }
        }

        /// <summary>
        ///   Gets or sets the class id of the character
        /// </summary>
        [DataMember(Name = "class", IsRequired = true)]
        public ClassKey Class
        {
            get
            {
                return _class;
            }
            internal set
            {
                _class = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [DataMember(Name = "guild", IsRequired = false)]
        public CharacterGuild Guild
        {
            get
            {
                return _guild;
            }
            internal set
            {
                _guild = value;
            }
        }

        /// <summary>
        ///   Gets or sets the items currently equipped by the character. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "items", IsRequired = false)]
        public CharacterItems Items
        {
            get
            {
                return _items;
            }
            internal set
            {
                _items = value;
            }
        }

        /// <summary>
        ///   Gets or sets the current character's stats. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "stats", IsRequired = false)]
        public CharacterStats Stats
        {
            get
            {
                return _stats;
            }
            internal set
            {
                _stats = value;
            }
        }

        /// <summary>
        ///   Gets or sets information about the character specialization and talent. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "talents", IsRequired = false)]
        public IList<CharacterTalents> Talents
        {
            get
            {
                return _talents;
            }
            internal set
            {
                _talents = value;
            }
        }

        /// <summary>
        ///   Get or sets information about character's reputation is all factions the character interacted with. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "reputation", IsRequired = false)]
        public IList<CharacterReputation> Reputations
        {
            get
            {
                return _reputations;
            }
            internal set
            {
                _reputations = value;
            }
        }

        /// <summary>
        ///   Gets or sets a collection or character's titles. %s is replaced by character's name when displaying the title. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "titles", IsRequired = false)]
        public IList<CharacterTitle> Titles
        {
            get
            {
                return _titles;
            }
            internal set
            {
                _titles = value;
            }
        }

        /// <summary>
        ///   Gets or sets information about character's current professions and skil level. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "professions", IsRequired = false)]
        public CharacterProfessions Professions
        {
            get
            {
                return _professions;
            }
            internal set
            {
                _professions = value;
            }
        }

        /// <summary>
        ///   Gets or sets information about character's appearance. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "appearance", IsRequired = false)]
        public CharacterAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            internal set
            {
                _appearance = value;
            }
        }

        /// <summary>
        ///   Gets or sets a collection of character's mounts.  This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "mounts", IsRequired = false)]
        public CharacterMounts Mounts
        {
            get
            {
                return _mounts;
            }
            internal set
            {
                _mounts = value;
            }
        }

        /// <summary>
        ///   Gets or sets a collection of character's pets. This can be null if the field is not requested while requesting the character profile data or if the character is a class not having pets.
        /// </summary>
        [DataMember(Name = "pets", IsRequired = false)]
        public CharacterPets Pets
        {
            get
            {
                return _pets;
            }
            internal set
            {
                _pets = value;
            }
        }

        /// <summary>
        ///   Gets or sets the current character's achievments. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "achievements", IsRequired = false)]
        public Achievements Achievements
        {
            get
            {
                return _achievements;
            }
            internal set
            {
                _achievements = value;
            }
        }

        /// <summary>
        ///   Gets or sets the current character's progression. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public CharacterProgression Progression
        {
            get
            {
                return _progression;
            }
            internal set
            {
                _progression = value;
            }
        }

        /// <summary>
        ///   Gets or sets the ids of the quests the character has completed
        /// </summary>
        [DataMember(Name = "quests", IsRequired = false)]
        public IList<int> CompletedQuestIds
        {
            get
            {
                return _completedQuestsIds;
            }
            internal set
            {
                _completedQuestsIds = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character Pvp stats
        /// </summary>
        [DataMember(Name = "pvp", IsRequired = false)]
        public CharacterPvpInformation Pvp
        {
            get
            {
                return _pvp;
            }
            internal set
            {
                _pvp = value;
            }
        }

        /// <summary>
        ///   gets or sets feeds
        /// </summary>
        [DataMember(Name = "feed", IsRequired = false)]
        public IList<FeedItem> Feed
        {
            get
            {
                return _feed;
            }
            internal set
            {
                _feed = value;
            }
        }

        /// <summary>
        ///   gets or sets hunter pets
        /// </summary>
        [DataMember(Name = "hunterPets", IsRequired = false)]
        public IList<HunterPet> HunterPets
        {
            get
            {
                return _hunterPets;
            }
            internal set
            {
                _hunterPets = value;
            }
        }

        /// <summary>
        ///   gets or sets pet slots
        /// </summary>
        [DataMember(Name = "petSlots", IsRequired = false)]
        public IList<CharacterPetSlot> PetSlots
        {
            get
            {
                return _petSlots;
            }
            internal set
            {
                _petSlots = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character total honorable kills
        /// </summary>
        [DataMember(Name = "totalHonorableKills", IsRequired = false)]
        public int TotalHonorableKills
        {
            get
            {
                return _totalHonorableKills;
            }
            internal set
            {
                _totalHonorableKills = value;
            }
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