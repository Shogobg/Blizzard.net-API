using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// A battle.net account diablo season
	/// </summary>
	[DataContract]
	public class DiabloSeason
	{
		[DataMember(Name = "seasonId", IsRequired = true)]
		public string SeasonId
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profile season paragon level
		/// </summary>
		[DataMember(Name = "paragonLevel", IsRequired = true)]
		public int ParagonLevel
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profile season hardcore paragon level
		/// </summary>
		[DataMember(Name = "paragonLevelHardcore", IsRequired = true)]
		public int ParagonLevelHardcore
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profile kill statistics
		/// </summary>
		[DataMember(Name = "kills", IsRequired = false)]
		public KillStatistics Kills
		{
			get;
			internal set;
		}

		/// <summary>
		/// Time played statistics
		/// </summary>
		[DataMember(Name = "timePlayed", IsRequired = false)]
		public TimePlayedStatistics TimePlayed
		{
			get;
			internal set;
		}

		/// <summary>
		/// Highest level achieved in hardcore mode
		/// </summary>
		[DataMember(Name = "highestHardcoreLevel", IsRequired = false)]
		public int HighestHardcoreLevel
		{
			get;
			internal set;
		}

		/// <summary>
		/// Profiles progression
		/// </summary>
		[DataMember(Name = "progression", IsRequired = false)]
		public ProfileProgression Progression
		{
			get;
			internal set;
		}
	}
}
