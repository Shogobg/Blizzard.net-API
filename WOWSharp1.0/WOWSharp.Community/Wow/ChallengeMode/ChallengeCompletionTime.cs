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
        ///   number of hours
        /// </summary>
        private int _hours;

        /// <summary>
        ///   number of milliseconds
        /// </summary>
        private int _milliseconds;

        /// <summary>
        ///   number of minutes
        /// </summary>
        private int _minutes;


        /// <summary>
        ///   number of seconds
        /// </summary>
        private int _seconds;

        /// <summary>
        ///   total time milliseconds
        /// </summary>
        private int _totalMilliseconds;

        /// <summary>
        ///   gets or sets number of hours
        /// </summary>
        [DataMember(Name = "hours", IsRequired = false)]
        public int Hours
        {
            get
            {
                return _hours;
            }
            internal set
            {
                _hours = value;
            }
        }

        /// <summary>
        ///   gets or sets number of minutes
        /// </summary>
        [DataMember(Name = "minutes", IsRequired = false)]
        public int Minutes
        {
            get
            {
                return _minutes;
            }
            internal set
            {
                _minutes = value;
            }
        }

        /// <summary>
        ///   gets or sets number of seconds
        /// </summary>
        [DataMember(Name = "seconds", IsRequired = false)]
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            internal set
            {
                _seconds = value;
            }
        }

        /// <summary>
        ///   gets or sets number of milliseconds
        /// </summary>
        [DataMember(Name = "milliseconds", IsRequired = false)]
        public int Milliseconds
        {
            get
            {
                return _milliseconds;
            }
            internal set
            {
                _milliseconds = value;
            }
        }

        /// <summary>
        ///   gets or sets total time milliseconds
        /// </summary>
        [DataMember(Name = "time", IsRequired = false)]
        public int TotalMilliseconds
        {
            get
            {
                return _totalMilliseconds;
            }
            internal set
            {
                _totalMilliseconds = value;
            }
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