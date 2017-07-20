// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Configuration;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.ApiClient.UnitTests
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
        public const string TestAuctionHouseRealm = "Doomhammer";
        public static readonly Region TestRegion = Region.EU;

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

        public static readonly string PrivateKey = ConfigurationManager.AppSettings["PrivateKey"];
        public static readonly string PublicKey = ConfigurationManager.AppSettings["PublicKey"];

        public static readonly ApiKeyPair Credentials = new ApiKeyPair(PublicKey, PrivateKey);
    }
}