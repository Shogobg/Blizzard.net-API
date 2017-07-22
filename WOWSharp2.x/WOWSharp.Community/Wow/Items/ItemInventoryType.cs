namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Item inventory types
	/// </summary>
	public enum ItemInventoryType
    {
        /// <summary>
        ///   None (for items that cannot be equipped)
        /// </summary>
        None = 0,

        /// <summary>
        ///   Head
        /// </summary>
        Head = 1,

        /// <summary>
        ///   Neck
        /// </summary>
        Neck = 2,

        /// <summary>
        ///   Shoulder
        /// </summary>
        Shoulder = 3,

        /// <summary>
        ///   Shirt
        /// </summary>
        Shirt = 4,

        /// <summary>
        ///   Chest (same slot as Body but doesn't cover the legs)
        /// </summary>
        Chest = 5,

        /// <summary>
        ///   Waist
        /// </summary>
        Waist = 6,

        /// <summary>
        ///   Legs
        /// </summary>
        Legs = 7,

        /// <summary>
        ///   Feet
        /// </summary>
        Feet = 8,

        /// <summary>
        ///   Wrist
        /// </summary>
        Wrist = 9,

        /// <summary>
        ///   Hands
        /// </summary>
        Hands = 10,

        /// <summary>
        ///   Finger
        /// </summary>
        Finger = 11,

        /// <summary>
        ///   Trinket
        /// </summary>
        Trinket = 12,

        /// <summary>
        ///   One Handed Weapon
        /// </summary>
        OneHanded = 13,

        /// <summary>
        ///   Shield
        /// </summary>
        Shield = 14,

        /// <summary>
        ///   For bows
        /// </summary>
        Ranged = 15,

        /// <summary>
        ///   Back
        /// </summary>
        Back = 16,

        /// <summary>
        ///   Two Handed Weapon
        /// </summary>
        TwoHanded = 17,

        /// <summary>
        ///   Bag
        /// </summary>
        Bag = 18,

        /// <summary>
        ///   Tabard
        /// </summary>
        Tabard = 19,

        /// <summary>
        ///   Robe (Same as chest, the difference is that body covers the legs too)
        /// </summary>
        Robe = 20,

        /// <summary>
        ///   Main hand
        /// </summary>
        MainHand = 21,

        /// <summary>
        ///   Off Hand Weapon
        /// </summary>
        OffhandWeapon = 22,

        /// <summary>
        ///   Held in Off Hand
        /// </summary>
        HeldInOffhand = 23,

        ///// <summary>
        /////   Ammo
        ///// </summary>
        //Ammo = 24,

        ///// <summary>
        /////   Thrown
        ///// </summary>
        //Thrown = 25,

        ///// <summary>
        /////   Ranged
        ///// </summary>
        //RangedRight = 26,

        ///// <summary>
        /////   Relic
        ///// </summary>
        //Relic = 28
    }
}