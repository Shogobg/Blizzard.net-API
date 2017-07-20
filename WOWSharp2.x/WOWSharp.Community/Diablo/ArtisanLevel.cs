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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// Artisan level information
    /// </summary>
    [DataContract]
    public class ArtisanLevel
    {
        /// <summary>
        /// Artisan level
        /// </summary>
        [DataMember(Name = "tier")]
        public int Tier
        {
            get;
            internal set;
        }

        /// <summary>
        /// level within the tier
        /// </summary>
        [DataMember(Name = "tierLevel")]
        public int TierLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// progress percent towards the next tier
        /// </summary>
        [DataMember(Name = "percent")]
        public double ProgressPercent
        {
            get;
            internal set;
        }

        /// <summary>
        /// recipes that are trained by upgrading the artisan
        /// </summary>
        [DataMember(Name = "trainedRecipes")]
        public IList<Recipe> TrainedRecipes
        {
            get;
            internal set;
        }

        /// <summary>
        /// recipes that are taught to the artisan by finding recipes/designs and teaching them to the the artisan
        /// </summary>
        [DataMember(Name = "taughtRecipes")]
        public IList<Recipe> TaughtRecipes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Upgrade cost in gold. 
        /// This seems to always return zero even though the  API documentation
        /// example has values for it
        /// </summary>
        [DataMember(Name = "upgradeCost")]
        public long UpdateCost
        {
            get;
            internal set;
        }

        /// <summary>
        /// items required to upgrade. 
        /// This seems to always return zero even though the  API documentation
        /// example has values for it
        /// </summary>
        [DataMember(Name = "upgradeItems")]
        public IList<RecipeReagent> UpgradeItems
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
            return "Level " + this.TierLevel.ToString(CultureInfo.InvariantCulture);
        }
    }
}
