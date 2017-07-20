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

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Character's appeance information
    /// </summary>
    [Serializable]
    [DataContract]
    public class CharacterAppearance : BaseExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets character's face variation (race dependent)
        /// </summary>
        [DataMember(Name = "faceVariation", IsRequired = true)]
        public int FaceVariation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets character's skin color (race dependent)
        /// </summary>
        [DataMember(Name = "skinColor", IsRequired = true)]
        public int SkinColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets character's hair variation (race dependent)
        /// </summary>
        [DataMember(Name = "hairVariation", IsRequired = true)]
        public int HairVariation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets character's feature variation (race dependent)
        /// </summary>
        [DataMember(Name = "featureVariation", IsRequired = true)]
        public int FeatureVariation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the character's helm should be shown.
        /// </summary>
        [DataMember(Name = "showHelm", IsRequired = false)]
        public bool ShowHelm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the character's cloak should be shown.
        /// </summary>
        [DataMember(Name = "showCloak", IsRequired = false)]
        public bool ShowCloak
        {
            get;
            set;
        }
    }
}
