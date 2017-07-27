

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// Helper class for item types
	/// </summary>
	public static class ItemHelper
    {
		// N = Not Used (Bit 31)
		// F = Future Class (Bits 26-30)
		// ? = Necromancer (Bit 27)
		// C = Crusader (Bit 25)
		// Z = Wizard (Bit 24)
		// W = Witchdoctor (Bit 23)
		// M = Monk (Bit 22)
		// D = Demon Hunter (Bit 21)
		// B = Barbarian (Bit 20)
		// 2 = Twohanded Flag (Bit 19)
		// O = Commodity Flag (Bit 18)
		// T = Sellable Flag (Bit 17)
		// N = Not Used (Bit 16)
		// S = Equipment Slot (Bits 11-15)
		// L = Follower (Bit 8 = Templar, Bit 9 = Scoundrel, Bit 10 = Enchantress)
		// 0 = Type unique Id
		// NFFF FFCZ WMDB 2OTN SSSS SLLL 0000 0000

		// Classes are bits 20-30 (Which should support up to 11 classes)
		internal const int ClassesShift = 19;
        internal const int FollowerShift = 7;
        
        internal const int Barbarian = 1 << ((int)HeroClass.Barbarian + ClassesShift);
        internal const int DemonHunter = 1 << ((int)HeroClass.DemonHunter + ClassesShift);
        internal const int Monk = 1 << ((int)HeroClass.Monk + ClassesShift);
        internal const int Witchdoctor = 1 << ((int)HeroClass.Witchdoctor + ClassesShift);
        internal const int Wizard = 1 << ((int)HeroClass.Wizard + ClassesShift);
        internal const int Crusader = 1 << ((int)HeroClass.Crusader + ClassesShift);
		internal const int Necromancer = 1 << ((int)HeroClass.Necromancer + ClassesShift);

		internal const int Templar = 1 << ((int)FollowerType.Templar + FollowerShift);
        internal const int Scoundrel = 1 << ((int)FollowerType.Scoundrel + FollowerShift);
        internal const int Enchantress = 1 << ((int)FollowerType.Enchantress + FollowerShift);

        internal const int AllFollowers = Templar + Scoundrel + Enchantress;
        internal const int AllClassesMask = Barbarian + DemonHunter + Monk + Witchdoctor + Wizard + Crusader;



        // Two handed flag is bit 19
        internal const int TwoHanded = 1 << 18;
        // Commodity flag is bit 18
        internal const int Commodity = 1 << 17;
        // Tradeable flag is bit 17
        internal const int Tradable = 1 << 16;

        internal const int EquipmentSlotShift = 14;
        internal const int EquipmentSlotMask = 0x0000F800;

        internal const int Boots = ((int)EquipmentSlot.Feet << EquipmentSlotShift);
        internal const int Bracers = ((int)EquipmentSlot.Bracers << EquipmentSlotShift);
        internal const int Follower = ((int)EquipmentSlot.FollowerSpecial << EquipmentSlotShift);
        internal const int Hands = ((int)EquipmentSlot.Hands << EquipmentSlotShift);
        internal const int Head = ((int)EquipmentSlot.Head << EquipmentSlotShift);
        internal const int Finger = ((int)EquipmentSlot.LeftFinger << EquipmentSlotShift);
        internal const int Legs = ((int)EquipmentSlot.Legs << EquipmentSlotShift);
        internal const int MainHand = ((int)EquipmentSlot.MainHand << EquipmentSlotShift);
        internal const int Neck = ((int)EquipmentSlot.Neck << EquipmentSlotShift);
        internal const int OffHand = ((int)EquipmentSlot.Offhand << EquipmentSlotShift);
        internal const int Shoulders = ((int)EquipmentSlot.Shoulders << EquipmentSlotShift);
        internal const int Torso = ((int)EquipmentSlot.Torso << EquipmentSlotShift);
        internal const int Waist = ((int)EquipmentSlot.Waist << EquipmentSlotShift);

        /// <summary>
        /// Gets whether a class can equip an item
        /// </summary>
        /// <param name="heroClass">class</param>
        /// <param name="type">item type</param>
        /// <returns>true if the class can equip an item</returns>
        public static bool CanEquip(HeroClass heroClass, ItemType type)
        {
            int typeInt = (int)type;

			if ((typeInt & EquipmentSlotMask) == 0)
			{
				return false;
			}

            return ((1 << ((int)heroClass + ClassesShift)) & typeInt) != 0;
        }

        /// <summary>
        /// Gets whether a class can equip an item
        /// </summary>
        /// <param name="heroClass">class</param>
        /// <param name="type">item type</param>
        /// <returns>true if the class can equip an item</returns>
        public static bool CanEquip(FollowerType followerType, ItemType type)
        {
            int typeInt = (int)type;

			if ((typeInt & EquipmentSlotMask) == 0)
			{
				return false;
			}

            return ((1 << ((int)followerType + FollowerShift)) & typeInt) != 0;
        }

        /// <summary>
        /// Is item tradable
        /// </summary>
        /// <param name="type">item type</param>
        /// <returns>true if item is tradable</returns>
        public static bool IsTradable(ItemType type)
        {
            int typeInt = (int)type;
            return (typeInt & Tradable) != 0;
        }

        /// <summary>
        /// Is item tradable
        /// </summary>
        /// <param name="type">item type</param>
        /// <returns>true if item is commodity</returns>
        public static bool IsCommodity(ItemType type)
        {
            int typeInt = (int)type;
            return (typeInt & Commodity) != 0;
        }
    }
}
