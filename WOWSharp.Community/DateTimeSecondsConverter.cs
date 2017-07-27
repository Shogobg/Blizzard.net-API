namespace WOWSharp.Community
{
	/// <summary>
	/// Json date converter for diablo APIs where time stamps are returned in seconds
	/// </summary>
	internal class DateTimeSecondsConverter : DatetimeConverter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTimeSecondsConverter() : base(false)
        {

        }
    }
}
