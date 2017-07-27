using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	public class CharacterBase
	{
		/// <summary>
		///   Gets or sets the race id of the character
		/// </summary>
		[DataMember(Name = "race", IsRequired = true)]
		public Race Race
		{
			get;
			internal set;
		}

		/// <summary>
		///   Gets the character faction
		/// </summary>
		public Faction Faction
		{
			get
			{
				if (Race == Race.NeutralPandaren)
				{
					return Faction.Neutral;
				}

				return Race == Race.Worgen
					   || Race == Race.NightElf
					   || Race == Race.Human
					   || Race == Race.Gnome
					   || Race == Race.Dwarf
					   || Race == Race.Draenei
					   || Race == Race.AlliancePandaren
						   ? Faction.Alliance
						   : Faction.Horde;
			}
		}
	}
}
