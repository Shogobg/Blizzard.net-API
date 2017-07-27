using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	[DataContract]
    public class ItemAffix
    {
        /// <summary>
        /// Affix text description
        /// </summary>
        [DataMember(Name = "text")]
        public string Text
        {
            get;
            set;
        }


        /// <summary>
        /// Affix type
        /// </summary>
        [DataMember(Name = "affixType")]
        public ItemAffixType Type
        {
            get;
            internal set;
        }

        /// <summary>
        /// Text color
        /// </summary>
        [DataMember(Name = "color")]
        public ItemAffixColor TextColor
        {
            get;
            internal set;
        }

        /// <summary>
        /// If the affix is a random affix that can roll one of several affix choices
        /// </summary>
        [DataMember(Name = "oneOf")]
        public IList<RandomAffixAttributes> OneOf
        {
            get;
            internal set;
        }

        
        /// <summary>
        /// String value for debug purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
