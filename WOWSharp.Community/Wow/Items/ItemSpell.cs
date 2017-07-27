
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Represents information about an item use spell or an item's proc
    /// </summary>
    [DataContract]
    public class ItemSpell
    {
        /// <summary>
        ///   Gets or sets the spell id
        /// </summary>
        [DataMember(Name = "spellId", IsRequired = true)]
        public int SpellId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item spell information
        /// </summary>
        [DataMember(Name = "spell", IsRequired = false)]
        public Spell Spell
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the number of times the spell can be used (0 means unlimited)
        /// </summary>
        [DataMember(Name = "nCharges", IsRequired = true)]
        public int NumberOfCharges
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item is consumed when the spell is used
        /// </summary>
        [DataMember(Name = "consumable", IsRequired = true)]
        public bool Consumable
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets how the item spell is triggered
        /// </summary>
        [DataMember(Name = "trigger", IsRequired = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemSpellTriggers Trigger
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the item's spell cooldown category (used to determine which items share CD with that item)
        /// </summary>
        [DataMember(Name = "categoryId", IsRequired = true)]
        public int CooldownCategoryId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Spell == null ? "" : Spell.ToString();
        }
    }
}