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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about item's gems, enchants and reforging
    /// </summary>
    [DataContract]
    public class EquippedItemParameters
    {
        /// <summary>
        /// Reforge Ids dictionary. Key is reforgeId, and value is an array with first item being reforge stat and second item being reforged to stat
        /// </summary>
        private static readonly Dictionary<int, ItemStatType[]> _reforgeIds = InitializeReforgeIds();

        /// <summary>
        /// Initialize reforge ids dictionary
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, ItemStatType[]> InitializeReforgeIds()
        {
            var reforgeIds = new Dictionary<int, ItemStatType[]>();
            var statTypes = new ItemStatType[] { 
                ItemStatType.Spirit, 
                ItemStatType.DodgeRating, 
                ItemStatType.ParryRating,
                ItemStatType.HitRating,
                ItemStatType.CritRating,
                ItemStatType.HasteRating,
                ItemStatType.ExpertiseRating,
                ItemStatType.MasteryRating
            };
            var startReforgeId = 113;
            for (int i = 0; i < statTypes.Length; i++)
            {
                for (int j = 0; j < statTypes.Length; j++)
                {
                    if (i != j)
                    {
                        reforgeIds.Add(startReforgeId++, new ItemStatType[] { statTypes[i], statTypes[j] });
                    }
                }
            }
            return reforgeIds;
        }

        /// <summary>
        /// Whether the item has a blacksmithing socket added
        /// </summary>
        [DataMember(Name = "extraSocket", IsRequired = false)]
        public bool ExtraSocket
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the enchant
        /// </summary>
        [DataMember(Name = "enchant", IsRequired = false)]
        public int? Enchant
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the first gem
        /// </summary>
        [DataMember(Name = "gem0", IsRequired = false)]
        public int? Gem0
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the second gem
        /// </summary>
        [DataMember(Name = "gem1", IsRequired = false)]
        public int? Gem1
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the third gem
        /// </summary>
        [DataMember(Name = "gem2", IsRequired = false)]
        public int? Gem2
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the fourth gem
        /// </summary>
        [DataMember(Name = "gem3", IsRequired = false)]
        public int? Gem3
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the items equipped from the same set.
        /// </summary>
        [DataMember(Name = "set", IsRequired = false)]
        public IList<int> SetItems
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of the tinker
        /// </summary>
        [DataMember(Name = "tinker", IsRequired = false)]
        public int? Tinker
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the id of reforge
        /// </summary>
        [DataMember(Name = "reforge", IsRequired = false)]
        public int? Reforge
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item to which this item is transmogrified to look like
        /// </summary>
        [DataMember(Name = "transmogItem", IsRequired = false)]
        public int? TransmogrifyItemId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or set the current equipped item upgrade
        /// </summary>
        [DataMember(Name = "upgrade", IsRequired = false)]
        public EquippedItemUpgrade Upgrade
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the reforged from stat
        /// </summary>
        public ItemStatType? ReforgedFromStat
        {
            get
            {
                if (!Reforge.HasValue)
                    return null;
                return _reforgeIds[Reforge.Value][0];
            }
        }

        /// <summary>
        /// Gets the reforged to stat
        /// </summary>
        public ItemStatType? ReforgedToStat
        {
            get
            {
                if (!Reforge.HasValue)
                    return null;
                return _reforgeIds[Reforge.Value][1];
            }
        }
    }
}