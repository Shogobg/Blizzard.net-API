
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class PvpZone
    {
        /// <summary>
        ///   Gets or sets the pvp area Id
        /// </summary>
        [DataMember(Name = "area")]
        public int AreaId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Controlling faction
        /// </summary>
        [DataMember(Name = "controlling-faction")]
        public Faction ControllingFaction
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the time for the next battle
        /// </summary>
        [DataMember(Name = "next")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime NextBattleTimeUtc
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current status or the zone
        /// </summary>
        [DataMember(Name = "status")]
        public PvpZoneStatus Status
        {
            get;
            internal set;
        }
    }
}