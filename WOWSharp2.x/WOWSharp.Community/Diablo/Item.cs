﻿// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WOWSharp.Community.Diablo
{
    /// <summary>
    /// Character's equipped item
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonDataItemConverter))]
    public class Item : ApiResponse 
    {
        /// <summary>
        /// Display color
        /// </summary>
        [DataMember(Name = "displayColor")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemDisplayColor DisplayColor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Icon URL
        /// Icon. Use the following format string to download the image.
        /// Where {0} is the Icon property returned by this property
        /// And {1} is the size (Available sizes that I know of are large and small)
        /// http://media.blizzard.com/d3/icons/items/{1}/{0}.png
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item id
        /// </summary>
        [DataMember(Name = "id")]
        public string Id
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        /// Tooltip parameters
        /// </summary>
        [DataMember(Name = "tooltipParams")]
        public string TooltipParameters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Locale independent identifier
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug
        {
            get;
            internal set;
        }

        /// <summary>
        /// Recipes that craft the items 
        /// (this seems wrong as it can return more than one item while Recipe property is correct)
        /// Anyway, this is returned as returned by Blizzard's API
        /// </summary>
        [DataMember(Name = "craftedBy")]
        public IList<Recipe> CraftedBy
        {
            get;
            internal set;
        }

        /// <summary>
        /// Recipe that craft the items 
        /// </summary>
        [DataMember(Name = "recipe")]
        public Recipe Recipe
        {
            get;
            internal set;
        }

        /// <summary>
        /// Whether the item is account bound
        /// </summary>
        [DataMember(Name = "accountBound")]
        public bool IsAccountBound
        {
            get;
            internal set;
        }

        /// <summary>
        /// A user readable list of attributes in the locale specified by the client
        /// </summary>
        [DataMember(Name = "attributes")]
        public ItemAttributes Attributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Random affixes the item can roll
        /// </summary>
        [DataMember(Name = "randomAffixes")]
        public IList<ItemAffix> RandomAffixes
        {
            get;
            internal set;
        }

        /// <summary>
        /// The item to which the current item is transmogrified to
        /// </summary>
        [DataMember(Name = "transmogItem")]
        public Item TransmogrificationItem
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attributes in locale independent format
        /// </summary>
        [DataMember(Name = "attributesRaw")]
        public IDictionary<string, AttributeValue> RawAttributes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item type information
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public ItemTypeInfo ItemType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Type name
        /// </summary>
        [DataMember(Name = "typeName", IsRequired = false)]
        public string TypeName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Minimum level required to equip the item
        /// </summary>
        [DataMember(Name = "requiredLevel", IsRequired = false)]
        public int RequiredLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item level of the item
        /// </summary>
        [DataMember(Name = "itemLevel", IsRequired = false)]
        public int ItemLevel
        {
            get;
            internal set;
        }

        /// <summary>
        /// For recipe items, and items not equipped by any character the number of random magical properties
        /// </summary>
        [DataMember(Name = "bonusAffixes", IsRequired = false)]
        public int BonusAffixes
        {
            get;
            internal set;
        }

        /// <summary>
        /// For recipe items, and items not equipped by any character, the maximum number of random magical properties
        /// </summary>
        [DataMember(Name = "bonusAffixesMax", IsRequired = false)]
        public int MaximumBonusAffixes
        {
            get;
            internal set;
        }

        /// <summary>
        /// For flavor text
        /// </summary>
        [DataMember(Name = "flavorText", IsRequired = false)]
        public string FlavorText
        {
            get;
            internal set;
        }

        /// <summary>
        /// Socketed gems
        /// </summary>
        [DataMember(Name = "gems", IsRequired = false)]
        public IList<SocketedGem> Gems
        {
            get;
            internal set;
        }

        /// <summary>
        /// Item set (if any)
        /// </summary>
        [DataMember(Name = "set", IsRequired = false)]
        public ItemSet Set
        {
            get;
            internal set;
        }

        /// <summary>
        /// Socket effects. Applies for gems only (effect that the gem applies to different types of items)
        /// </summary>
        [DataMember(Name = "socketEffects", IsRequired = false)]
        public IList<SocketEffect> SocketEffects
        {
            get;
            internal set;
        }

        /// <summary>
        /// list of items obtained by salvaging the item
        /// </summary>
        [DataMember(Name = "salvage", IsRequired = false)]
        public IList<ItemSalvageMaterial> Salvage
        {
            get;
            internal set;
        }

        /// <summary>
        /// Armor
        /// </summary>
        [DataMember(Name = "armor", IsRequired = false)]
        public AttributeValue Armor
        {
            get;
            internal set;
        }


        /// <summary>
        /// damage per second
        /// </summary>
        [DataMember(Name = "dps", IsRequired = false)]
        public AttributeValue DamagePerSecond
        {
            get;
            internal set;
        }


        /// <summary>
        /// Minumum damage
        /// </summary>
        [DataMember(Name = "minDamage", IsRequired = false)]
        public AttributeValue MinimumDamage
        {
            get;
            internal set;
        }


        /// <summary>
        /// Maximum damage
        /// </summary>
        [DataMember(Name = "maxDamage", IsRequired = false)]
        public AttributeValue MaximumDamage
        {
            get;
            internal set;
        }


        /// <summary>
        /// Attacks per second
        /// </summary>
        [DataMember(Name = "attacksPerSecond", IsRequired = false)]
        public AttributeValue AttacksPerSecond
        {
            get;
            internal set;
        }

        /// <summary>
        /// Block chance
        /// </summary>
        [DataMember(Name = "blockChance", IsRequired = false)]
        public AttributeValue BlockChance
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
            return Name;
        }
    }
}
