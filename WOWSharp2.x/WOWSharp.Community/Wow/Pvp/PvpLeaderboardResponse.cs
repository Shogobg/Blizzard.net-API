using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Globalization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	/// Represents response to the Leader board API
	/// </summary>
	[DataContract]
    public class PvpLeaderboardResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the leader board returned by APIs
        /// </summary>
        [DataMember(Name = "rows", IsRequired = true)]
        public IList<PvpLeaderboardRecord> Leaderboard
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return (Leaderboard == null ? "0" : Leaderboard.Count.ToString(CultureInfo.InvariantCulture)) + " Records";
        }
    }
}
