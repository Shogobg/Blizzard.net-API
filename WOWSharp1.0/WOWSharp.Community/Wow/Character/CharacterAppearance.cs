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

using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Character's appeance information
    /// </summary>
    [DataContract]
    public class CharacterAppearance
    {
        /// <summary>
        ///   Gets or sets character's face variation (race dependent)
        /// </summary>
        private int _faceVariation;

        /// <summary>
        ///   Gets or sets character's feature variation (race dependent)
        /// </summary>
        private int _featureVariation;

        /// <summary>
        ///   hair color for the character
        /// </summary>
        private int _hairColor;

        /// <summary>
        ///   Gets or sets character's hair variation (race dependent)
        /// </summary>
        private int _hairVariation;

        /// <summary>
        ///   Gets or sets whether the character's cloak should be shown.
        /// </summary>
        private bool _showCloak;

        /// <summary>
        ///   Gets or sets whether the character's helm should be shown.
        /// </summary>
        private bool _showHelm;

        /// <summary>
        ///   Gets or sets character's skin color (race dependent)
        /// </summary>
        private int _skinColor;

        /// <summary>
        ///   Gets or sets character's face variation (race dependent)
        /// </summary>
        [DataMember(Name = "faceVariation", IsRequired = true)]
        public int FaceVariation
        {
            get
            {
                return _faceVariation;
            }
            internal set
            {
                _faceVariation = value;
            }
        }

        /// <summary>
        ///   Gets or sets character's skin color (race dependent)
        /// </summary>
        [DataMember(Name = "skinColor", IsRequired = true)]
        public int SkinColor
        {
            get
            {
                return _skinColor;
            }
            internal set
            {
                _skinColor = value;
            }
        }

        /// <summary>
        ///   Gets or sets character's hair variation (race dependent)
        /// </summary>
        [DataMember(Name = "hairVariation", IsRequired = true)]
        public int HairVariation
        {
            get
            {
                return _hairVariation;
            }
            internal set
            {
                _hairVariation = value;
            }
        }

        /// <summary>
        ///   Gets or sets character's feature variation (race dependent)
        /// </summary>
        [DataMember(Name = "featureVariation", IsRequired = true)]
        public int FeatureVariation
        {
            get
            {
                return _featureVariation;
            }
            internal set
            {
                _featureVariation = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the character's helm should be shown.
        /// </summary>
        [DataMember(Name = "showHelm", IsRequired = false)]
        public bool ShowHelm
        {
            get
            {
                return _showHelm;
            }
            internal set
            {
                _showHelm = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the character's cloak should be shown.
        /// </summary>
        [DataMember(Name = "showCloak", IsRequired = false)]
        public bool ShowCloak
        {
            get
            {
                return _showCloak;
            }
            internal set
            {
                _showCloak = value;
            }
        }

        /// <summary>
        ///   gets or sets hair color for the character
        /// </summary>
        [DataMember(Name = "hairColor", IsRequired = false)]
        public int HairColor
        {
            get
            {
                return _hairColor;
            }
            internal set
            {
                _hairColor = value;
            }
        }
    }
}