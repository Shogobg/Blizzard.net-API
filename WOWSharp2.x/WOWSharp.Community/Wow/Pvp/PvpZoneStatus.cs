
namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   PvP zone Status enumeration
    /// </summary>
    public enum PvpZoneStatus
    {
        /// <summary>
        ///   Unknown status
        /// </summary>
        Unknown = -1,

        /// <summary>
        ///   Idle (There is no battle atm)
        /// </summary>
        Idle = 0,

        /// <summary>
        ///   Populating (The battle is about to start)
        /// </summary>
        Populating = 1,

        /// <summary>
        ///   Active (there is a battle atm, Go HORDE)
        /// </summary>
        Active = 2,

        /// <summary>
        ///   The battle has just concluded
        /// </summary>
        Concluded = 3
    }
}