
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Act's progression for a profile or a character
	/// </summary>
	[DataContract]
    public class ActProgression
    {
        /// <summary>
        /// Whether the act is completed
        /// </summary>
        [DataMember(Name = "completed")]
        public bool IsCompleted
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the completed quests
        /// </summary>
        [DataMember(Name = "completedQuests")]
        public IList<Quest> CompletedQuests
        {
            get;
            internal set;
        }

        /// <summary>
        /// String representation for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "IsCompleted = " + IsCompleted;
        }
    }
}
