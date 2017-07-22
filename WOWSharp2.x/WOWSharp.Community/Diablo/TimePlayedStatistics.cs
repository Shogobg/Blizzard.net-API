
using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// The time played statistics for different classes
	/// </summary>
	[DataContract]
    public class TimePlayedStatistics
    {
        /// <summary>
        /// Time played with barbarian
        /// </summary>
        [DataMember(Name = "barbarian", IsRequired = false)]
        public double Barbarian
        {
            get;
            internal set;
        }

		/// <summary>
		/// Time played with crusader
		/// </summary>
		[DataMember(Name = "crusader", IsRequired = false)]
		public double Crusader
		{
			get;
			internal set;
		}

		/// <summary>
		/// Time played with demon hunter
		/// </summary>
		[DataMember(Name = "demon-hunter", IsRequired = false)]
        public double DemonHunter
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with monk
        /// </summary>
        [DataMember(Name = "monk", IsRequired = false)]
        public double Monk
        {
            get;
            internal set;
        }

		/// <summary>
		/// Time played with necromancer
		/// </summary>
		[DataMember(Name = "necromancer", IsRequired = false)]
		public double Necromancer
		{
			get;
			internal set;
		}

		/// <summary>
		/// Time played with witch doctor
		/// </summary>
		[DataMember(Name = "witch-doctor", IsRequired = false)]
        public double Witchdoctor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Time played with wizard
        /// </summary>
        [DataMember(Name = "wizard", IsRequired = false)]
        public double Wizard
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets string representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
				"Barbarian {0}, Demon Hunter {1}, Monk {2}, Witch Doctor {3}, Wizard {4}, Crusader {5}, Necromancer {6}",
				Barbarian, DemonHunter, Monk, Wizard, Witchdoctor, Crusader, Necromancer);
        }
    }
}
