using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Attribute value range
	/// </summary>
	[DataContract]
    public class AttributeValue
    {
        /// <summary>
        /// Attribute's minimum value
        /// </summary>
        [DataMember(Name = "min")]
        public double MinimumValue
        {
            get;
            internal set;
        }

        /// <summary>
        /// Attribute's maximum value
        /// </summary>
        [DataMember(Name = "max")]
        public double MaximumValue
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
            return MinimumValue.ToString(CultureInfo.InvariantCulture) + "-" + MaximumValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}
