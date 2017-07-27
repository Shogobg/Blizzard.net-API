using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents information about a spell
	/// </summary>
	[DataContract]
    public class Spell : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the spell's id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's sub text (typically the spell rank)
        /// </summary>
        [DataMember(Name = "subtext", IsRequired = false)]
        public string Subtext
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's range
        /// </summary>
        [DataMember(Name = "range", IsRequired = false)]
        public string Range
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the spell's cast time
        /// </summary>
        [DataMember(Name = "castTime", IsRequired = false)]
        public string CastTime
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets power cost
        /// </summary>
        [DataMember(Name = "powerCost", IsRequired = false)]
        public string PowerCost
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets cool down
        /// </summary>
        [DataMember(Name = "cooldown", IsRequired = false)]
        public string Cooldown
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
            return Name;
        }
    }
}