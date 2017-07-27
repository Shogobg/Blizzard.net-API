
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WOWSharp.Community
{
	/// <summary>
	///   Base class for objects returned by battle.net community API
	/// </summary>
	[DataContract]
    [KnownType("RetrieveKnownTypes")]
    public class ApiResponse
    {
        /// <summary>
        ///   known types cache
        /// </summary>
        private static readonly ReadOnlyCollection<Type> _knownTypesCache =
            new ReadOnlyCollection<Type>(typeof (ApiResponse).Assembly.GetTypes().Where(
                t => t != typeof (ApiResponse)
                     && typeof (ApiResponse).IsAssignableFrom(t)).ToList());

        /// <summary>
        ///   Last Modified Date
        /// </summary>
        [DataMember(Name = "lastModified", IsRequired = false)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime LastModifiedUtc
        {
            get;
            protected internal set;
        }

        /// <summary>
        ///   The path used to fetch the object
        /// </summary>
        [DataMember(Name = "path", IsRequired = false)]
        public string Path
        {
            get;
            protected internal set;
        }

        /// <summary>
        ///   Gets known types
        /// </summary>
        /// <returns> get known types </returns>
        protected internal static IList<Type> RetrieveKnownTypes()
        {
            return _knownTypesCache;
        }
		
		/// <summary>
		///   Refreshes object data from server
		/// </summary>
		public Task RefreshAsync(ApiClient client)
        {
            return RefreshAsync(client, false);
        }

        /// <summary>
        ///   Refreshes object data from server
        /// </summary>
        /// <param name="forceRefresh">if true will not set the If-Modified-Since header, and will force the client to refetch all data from server.</param>
        public async Task RefreshAsync(ApiClient client, bool forceRefresh)
        {
            object response = await client.GetAsync(Path, GetType(), forceRefresh ? null : this);

			if (response == this)
			{
				return;
			}

            PropertyInfo[] properties = GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                object[] attrs = properties[i].GetCustomAttributes(typeof(DataMemberAttribute), true);
                if (attrs != null && attrs.Length != 0)
                {
                    properties[i].SetValue(this, properties[i].GetValue(response, null), null);
                }
            }
        }
    }
}