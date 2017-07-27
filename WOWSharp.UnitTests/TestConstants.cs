using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.UnitTests
{
	internal static class TestConstants
    {
        public const string TestRealmName = "Kazzak";
        public const string TestRegionName = "EU";
        public const string TestCharacterName = "Grendiser";
        public const string TestGuildName = "Immortalis";
        public const string TestHunter = "Karkoor";
        public const ClassKey TestClass = ClassKey.Druid;
        public const Race TestRace = Race.Troll;
        public const CharacterGender TestGender = CharacterGender.Male;
        public const Skill TestProfession1 = Skill.Alchemy;
        public const Skill TestProfession2 = Skill.Leatherworking;

        public const string TestAuctionHouseRealm = "Echsenkessel"; // Need to test witha  low pop realm
        public static readonly Region TestRegion = Region.EU;

        public static readonly string TestBattleTag = System.Configuration.ConfigurationManager.AppSettings.Get("battleNetTag");

        //public const string TestRealmName = "";
        //public const string TestRegionName = "US";
        //public static readonly Region TestRegion = Region.US;
        //public const string TestCharacterName = "";
        //public const string TestGuildName = "";
        //public const string TestHunter = "";
        //public const ClassKey TestClass = ClassKey.Druid;
        //public const Race TestRace = Race.Tauren;
        //public const CharacterGender TestGender = CharacterGender.Female;
        //public const Skill TestProfession1 = Skill.JewelCrafting;
        //public const Skill TestProfession2 = Skill.Blacksmithing;
		
		public static readonly string apiKey = System.Configuration.ConfigurationManager.AppSettings.Get("apiKey");
    }
}