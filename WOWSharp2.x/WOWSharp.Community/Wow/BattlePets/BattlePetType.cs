using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   information about a battle pet type
	/// </summary>
	[DataContract]
    public class BattlePetType
    {
        /// <summary>
        ///   gets or sets id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets key (culture independent name)
        /// </summary>
        [DataMember(Name = "key", IsRequired = false)]
        public string Key
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets name
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets strong against type id
        /// </summary>
        [DataMember(Name = "strongAgainstId", IsRequired = false)]
        public int StrongAgainstId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets type ability id
        /// </summary>
        [DataMember(Name = "typeAbilityId", IsRequired = false)]
        public int TypeAbilityId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets Weak against id
        /// </summary>
        [DataMember(Name = "weakAgainstId", IsRequired = false)]
        public int WeakAgainstId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}