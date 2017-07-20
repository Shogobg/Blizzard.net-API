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