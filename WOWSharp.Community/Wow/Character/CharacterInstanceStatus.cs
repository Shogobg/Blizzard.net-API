
namespace WOWSharp.Community.Wow
{
    /// <summary>
    ///   Enumeration representing the character current progress in the instance
    /// </summary>
    public enum CharacterInstanceStatus
    {
        /// <summary>
        ///   Not started. Either the character never sets foot in the instance, or entered the instance and never killed any bosses, or this mode is not available (for example heroic progression status for instances that don't have heroic modes).
        /// </summary>
        NotStarted = 0,

        /// <summary>
        ///   Progressions. The character has killed at least 1 boss in the instance in that mode.
        /// </summary>
        Progressing = 1,

        /// <summary>
        ///   Completed. The character has killed all the non optional bosses in the instance in that mode.
        /// </summary>
        Completed = 2
    }
}