
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   The API response for Realm status
    /// </summary>
    [DataContract]
    public class RealmStatusResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the realm s returned from the realm status request
        /// </summary>
        [DataMember(IsRequired = true, Name = "realms")]
        public IList<Realm> Realms
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
            return string.Format(CultureInfo.CurrentCulture, "Realm Count = {0}", Realms == null ? 0 : Realms.Count);
        }
    }
}