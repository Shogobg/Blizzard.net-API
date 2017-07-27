
using System;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Challenge mode completion time
    /// </summary>
    [DataContract]
    public class ChallengeCompletionTime
    {
        /// <summary>
        /// Returned by Blizzard, seems to be always true. No idea what this property stands for. I don't see a way the completion time would be negative!!
        /// </summary>
        [DataMember(Name = "isPositive", IsRequired = false)]
        public bool IsPositive
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of hours
        /// </summary>
        [DataMember(Name = "hours", IsRequired = false)]
        public int Hours
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of minutes
        /// </summary>
        [DataMember(Name = "minutes", IsRequired = false)]
        public int Minutes
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of seconds
        /// </summary>
        [DataMember(Name = "seconds", IsRequired = false)]
        public int Seconds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets number of milliseconds
        /// </summary>
        [DataMember(Name = "milliseconds", IsRequired = false)]
        public int Milliseconds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets total time milliseconds
        /// </summary>
        [DataMember(Name = "time", IsRequired = false)]
        public int TotalMilliseconds
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets the time
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                return TimeSpan.FromMilliseconds(TotalMilliseconds);
            }
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Time.ToString();
        }
    }
}