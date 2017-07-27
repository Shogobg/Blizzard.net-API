
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Information about item set's bonus
    /// </summary>
    [DataContract]
    public class ItemSetBonus
    {
        /// <summary>
        ///   Gets or sets the description of the set's bonus
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the number of items that should be equipped to get the effect of the set's bonus
        /// </summary>
        [DataMember(Name = "threshold")]
        public int Threshold
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}:{1}", Threshold, Description);
        }
    }
}