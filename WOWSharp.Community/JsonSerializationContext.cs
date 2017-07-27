using System.Net.Http;

namespace WOWSharp.Community
{
	/// <summary>
	/// Serialization context that contains information about ApiClient, Response and Path
	/// </summary>
	internal class JsonSerializationContext
    {
        /// <summary>
        /// The api client used for serialization
        /// </summary>
        public ApiClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// Path used to download the information
        /// </summary>
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Response message
        /// </summary>
        public HttpResponseMessage MyProperty
        {
            get;
            set;
        }


    }
}
