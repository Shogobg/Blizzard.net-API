using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents gem information
	/// </summary>
	[DataContract]
    public class GemInfo
    {
        /// <summary>
        ///   gets or sets the gem's bonus
        /// </summary>
        [DataMember(Name = "bonus", IsRequired = false)]
        public GemBonus Bonus
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the gem's type
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public GemType TypeOfGem
        {
            get;
            internal set;
        }

        /// <summary>
        /// Minimum item level for which the gem can be applied
        /// </summary>
        [DataMember(Name = "minItemLevel", IsRequired = false)]
        public int MinimumItemLevel
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
            return TypeOfGem + ": " + Bonus;
        }
    }
}