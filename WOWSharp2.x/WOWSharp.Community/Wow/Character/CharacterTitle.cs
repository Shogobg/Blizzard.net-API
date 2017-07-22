using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a character's title
	/// </summary>
	[DataContract]
    public class CharacterTitle
    {
        /// <summary>
        ///   Gets or sets the id of the title
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the name of the title. Note that %s is replaced with character's name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets whether this title is currently selected
        /// </summary>
        [DataMember(Name = "selected", IsRequired = false)]
        public bool IsSelected
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