using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A diablo skill rune
	/// </summary>
	[DataContract]
    public class Rune
    {
        /// <summary>
        /// Slug (locale independent identifier)
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug
        {
            get;
            internal set;
        }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// The level at which the rune is unlocked
        /// </summary>
        [DataMember(Name = "level")]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        /// The order of the rune relative to other runes for the skill
        /// </summary>
        [DataMember(Name = "order")]
        public int Order
        {
            get;
            internal set;
        }

        /// <summary>
        /// Rune description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        /// Rune skill description
        /// </summary>
        [DataMember(Name = "simpleDescription")]
        public string SimpleDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// Rune's id in Blizzard's skill calculator
        /// </summary>
        [DataMember(Name = "skillCalcId")]
        public string SkillCalculatorId
        {
            get;
            set;
        }

        /// <summary>
        /// Tooltip parameters
        /// To retrieve the tooltip use the following format string
        /// Where 
        /// {0} is lang (en, es, pt, it, etc)
        /// {1} is the tooltip returned from this property
        /// {2} is the host (*.api.battle.net, etc)
        /// {3} is protocol (http or https)
        /// {4}://{2}/d3/{0}/tooltip/{1} 
        /// </summary>
        [DataMember(Name = "tooltipParams")]
        public string TooltipParameters
        {
            get;
            set;
        }

        /// <summary>
        /// rune type 
        /// </summary>
        [DataMember(Name = "type")]
        public string RuneType
        {
            get;
            set;
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
