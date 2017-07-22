using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A diablo quest
	/// </summary>
	[DataContract]
    public class Quest
    {
        /// <summary>
        /// Gets or sets quest name (this is localized in the request's locale)
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets quest slug (language independent identifier)
        /// </summary>
        [DataMember(Name = "slug", IsRequired = true)]
        public string Slug
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
            return Name;
        }
    }
}
