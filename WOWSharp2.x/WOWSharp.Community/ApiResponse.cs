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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
            object response = await client.GetAsync(Path, this.GetType(), forceRefresh ? null : this);
            if (response == this)
                return;
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