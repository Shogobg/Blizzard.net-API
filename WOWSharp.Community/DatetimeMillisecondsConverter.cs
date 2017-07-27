namespace WOWSharp.Community
{
	/// <summary>
	/// Json date converter for wow APIs where time stamps are returned in milliseconds
	/// </summary>
	internal class DatetimeMillisecondsConverter : DatetimeConverter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DatetimeMillisecondsConverter() : base(true)
        {

        }
    }
}
