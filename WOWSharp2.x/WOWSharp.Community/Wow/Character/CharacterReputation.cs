using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a character's current standing with a faction
	/// </summary>
	[DataContract]
    public class CharacterReputation
    {
        /// <summary>
        ///   gets or sets faction id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets faction name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the current standing
        /// </summary>
        [DataMember(Name = "standing", IsRequired = true)]
        public Standing Standing
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the progress within the current standing
        /// </summary>
        [DataMember(Name = "value", IsRequired = true)]
        public int Value
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the max value to reach the next standing
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
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
            return string.Format(CultureInfo.CurrentCulture, "{0} {1} {2}/{3}", Name, Standing, Value, Maximum);
        }
    }
}