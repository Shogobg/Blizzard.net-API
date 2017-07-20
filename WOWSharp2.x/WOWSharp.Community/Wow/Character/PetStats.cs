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
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Pets stats
    /// </summary>
    [DataContract]
    public class PetStats
    {
        /// <summary>
        ///   gets or sets breed id
        /// </summary>
        [DataMember(Name = "breedId", IsRequired = false)]
        public int BreedId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets health points
        /// </summary>
        [DataMember(Name = "health", IsRequired = false)]
        public int Health
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets level
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's quality
        /// </summary>
        [DataMember(Name = "petQualityId", IsRequired = false)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets power
        /// </summary>
        [DataMember(Name = "power", IsRequired = false)]
        public int Power
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets species id
        /// </summary>
        [DataMember(Name = "speciesId", IsRequired = false)]
        public int SpeciesId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's speed
        /// </summary>
        [DataMember(Name = "speed", IsRequired = false)]
        public int Speed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return "Level " + Level.ToString(CultureInfo.InvariantCulture);
        }
    }
}