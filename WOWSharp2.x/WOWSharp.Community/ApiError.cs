using System.Runtime.Serialization;

namespace WOWSharp.Community
{
	/// <summary>
	///   Represents an error returned in the content of a failed request by the battle.net community API
	/// </summary>
	[DataContract]
    public class ApiError : ApiResponse
    {
        /// <summary>
        ///   Error reason as returned by the Blizzard's battle.net community API
        /// </summary>
        private string _reason;

        /// <summary>
        ///   Error status as returned by the Blizzard's battle.net community API
        /// </summary>
        private string _status;

        /// <summary>
        ///   Default constructor
        /// </summary>
        public ApiError()
        {
        }

        /// <summary>
        ///   constructor
        /// </summary>
        /// <param name="status"> error status </param>
        /// <param name="reason"> error reason </param>
        public ApiError(string status, string reason)
        {
            Status = status;
            Reason = reason;
        }

        /// <summary>
        ///   Error status as returned by the Blizzard's battle.net community API
        /// </summary>
        [DataMember(IsRequired = true, Name = "status")]
        public string Status
        {
            get
            {
                return _status;
            }
            internal set
            {
                _status = value;
            }
        }

        /// <summary>
        ///   Error reason as returned by the Blizzard's battle.net community API
        /// </summary>
        [DataMember(IsRequired = true, Name = "reason")]
        public string Reason
        {
            get
            {
                return _reason;
            }
            internal set
            {
                _reason = value;
            }
        }
    }
}