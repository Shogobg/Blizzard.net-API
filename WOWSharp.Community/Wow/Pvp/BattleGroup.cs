
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Battle group information
    /// </summary>
    [DataContract]
    public class BattleGroup
    {
        /// <summary>
        ///   Gets or sets the name of the battlegroup
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            internal set;

        }

        /// <summary>
        ///   Gets or sets the slug of the battlegroup
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug
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
            return Name;
        }
    }
}