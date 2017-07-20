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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// A battle.net account diablo profile
    /// </summary>
    [DataContract]
    public class DiabloProfile : ApiResponse
    {
        /// <summary>
        /// The profiles battle tag. Will have the format of Name#0000, 
        /// where Name is the battle tag and 0000 is the unique number used to differentiate profiles with same name
        /// </summary>
        [DataMember(Name = "battleTag", IsRequired = true)]
        public string BattleTag
        {
            get;
            internal set;
        }

        ///// <summary>
        ///// Profiles softcore mode artisan information
        ///// </summary>
        //[DataMember(Name = "artisans", IsRequired = true)]
        //public IList<ProfileArtisanInfo> Artisans
        //{
        //    get;
        //    internal set;
        //}

        ///// <summary>
        ///// Profiles hardcore mode artisan information
        ///// </summary>
        //[DataMember(Name = "hardcoreArtisans", IsRequired = false)]
        //public IList<ProfileArtisanInfo> HardcoreModeArtisans
        //{
        //    get;
        //    internal set;
        //}

        ///// <summary>
        ///// Profiles softcore mode progression
        ///// </summary>
        //[DataMember(Name = "progression", IsRequired = false)]
        //public Progression Progression
        //{
        //    get;
        //    internal set;
        //}

        ///// <summary>
        ///// Profiles hardcore mode progression
        ///// </summary>
        //[DataMember(Name = "hardcoreProgression", IsRequired = false)]
        //public Progression HardcoreModeProgression
        //{
        //    get;
        //    internal set;
        //}

        /// <summary>
        /// Profiles progression
        /// </summary>
        [DataMember(Name = "progression", IsRequired = false)]
        public ProfileProgression Progression
        {
            get;
            internal set;
        }


        /// <summary>
        /// Profile's fallen hardcore Heroes
        /// </summary>
        [DataMember(Name = "fallenHeroes", IsRequired = false)]
        public IList<Hero> FallenHeroes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Profiles normal mode paragon level
        /// </summary>
        [DataMember(Name = "paragonLevel", IsRequired = true)]
        public int ParagonLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// Profiles hardcore mode paragon level
        /// </summary>
        [DataMember(Name = "paragonLevelHardcore", IsRequired = true)]
        public int ParagonLevelHardcore
        {
            get;
            internal set;
        }

        /// <summary>
        /// Profile's Heroes
        /// </summary>
        [DataMember(Name = "heroes", IsRequired = false)]
        public IList<Hero> Heroes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Profile kill statistics
        /// </summary>
        [DataMember(Name = "kills", IsRequired = false)]
        public KillStatistics Kills
        {
            get;
            internal set;
        }

        /// <summary>
        /// Id of the last hero played
        /// </summary>
        [DataMember(Name = "lastHeroPlayed", IsRequired = false)]
        public long LastHeroPlayedId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Last updated date in UTC
        /// </summary>
        [DataMember(Name = "lastUpdated", IsRequired = false)]
        [JsonConverter(typeof(DateTimeSecondsConverter))]
        public DateTime LastUpdatedUtc
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played statistics
        /// </summary>
        [DataMember(Name = "timePlayed", IsRequired = false)]
        public TimePlayedStatistics TimePlayed
        {
            get;
            internal set;
        }

        /// <summary>
        /// Handle deserialization
        /// </summary>
        /// <param name="context"></param>
        /// <remarks>
        /// This method is marked as internal and CA warning surpressed,
        /// because setting the method as private as CA advises would cause JSON.NET
        /// To fail to call the method, but being internal and internals being visible to 
        /// JSON.NET causes serialization to succeed.
        /// We can run in partial trust environment where JSON.NET cannot have access
        /// to private members.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2238:ImplementSerializationMethodsCorrectly")]
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            OnHeroCollectionDeserialized(Heroes);
            OnHeroCollectionDeserialized(FallenHeroes);
        }

        /// <summary>
        /// Handle deserialization of hero collection
        /// </summary>
        /// <param name="heroCollection">hero collection</param>
        private void OnHeroCollectionDeserialized(IList<Hero> heroCollection)
        {
            if (heroCollection != null)
            {
                foreach (var hero in heroCollection)
                {
                    if (hero != null)
                    {
                        hero.Path = "/api/d3/profile/" + BattleTag.Replace('#', '-') + "/hero/" + hero.Id;
                    }
                }
            }
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns>String representation for debugging purposes</returns>
        public override string ToString()
        {
            return BattleTag;
        }
    }
}
