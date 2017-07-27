using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Represents a character's profession
	/// </summary>
	[DataContract]
    public class CharacterProfession
    {
        /// <summary>
        ///   gets or sets profession id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public Skill Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession icon
        /// </summary>
        [DataMember(Name = "icon", IsRequired = true)]
        public string Icon
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession rank reached by the character
        /// </summary>
        [DataMember(Name = "rank", IsRequired = true)]
        public int Rank
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the profession's max skill level (the API seems to return zero for that field)
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Maximum
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the list of recipes learned by the character
        /// </summary>
        [DataMember(Name = "recipes", IsRequired = true)]
        public IList<int> Recipes
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
            return string.Format(CultureInfo.CurrentCulture, "{0} {1}/{2} {3} Recipes", Name, Rank, Maximum,
                                 Recipes == null ? 0 : Recipes.Count);
        }
    }
}