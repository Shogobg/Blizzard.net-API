﻿// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

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
        ///   The begin request method
        /// </summary>
        private static readonly MethodInfo _beginRequestMethod = typeof (ApiClient).GetMethod("BeginRequest");

        /// <summary>
        ///   The end request method
        /// </summary>
        private static readonly MethodInfo _endRequestMethod = typeof (ApiClient).GetMethod("EndRequest");

        private ApiClient _client;

        /// <summary>
        ///   Last Modified Date
        /// </summary>
        private DateTime _lastModifiedUtc;

        /// <summary>
        ///   The path used to fetch the object
        /// </summary>
        private string _path;

        /// <summary>
        ///   Last Modified Date
        /// </summary>
        public DateTime LastModifiedUtc
        {
            get
            {
                return _lastModifiedUtc;
            }
            protected internal set
            {
                _lastModifiedUtc = value;
            }
        }

        /// <summary>
        ///   The client used to get the object
        /// </summary>
        public ApiClient Client
        {
            get
            {
                return _client;
            }
            protected internal set
            {
                _client = value;
            }
        }

        /// <summary>
        ///   The path used to fetch the object
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }
            protected internal set
            {
                _path = value;
            }
        }

        /// <summary>
        ///   Performs additional processing after the object has been deserialized
        /// </summary>
        /// <param name="client"> The API client that requested the object </param>
        protected internal virtual void OnDeserialized(ApiClient client)
        {
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
        ///   begins an async operation to refresh an object
        /// </summary>
        /// <param name="callback"> Callback to execute when request ends </param>
        /// <param name="asyncState"> user defined state </param>
        /// <returns> The result of the async state </returns>
        public IAsyncResult BeginRefresh(AsyncCallback callback, object asyncState)
        {
            MethodInfo beginMethod = _beginRequestMethod.MakeGenericMethod(GetType());
            return (IAsyncResult) beginMethod.Invoke(Client, new[]
                                                                 {
                                                                     Path, this, callback, asyncState
                                                                 });
        }

        /// <summary>
        ///   Waits for refresh request to end and refreshes the object
        /// </summary>
        /// <param name="result"> The state of the async operation </param>
        public void EndRefresh(IAsyncResult result)
        {
            MethodInfo endMethod = _endRequestMethod.MakeGenericMethod(GetType());
            var response = (ApiResponse) endMethod.Invoke(Client, new object[] {result});
            if (response == this)
                return;
            PropertyInfo[] properties = GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                object[] attrs = properties[i].GetCustomAttributes(typeof (DataMemberAttribute), true);
                if (attrs != null && attrs.Length != 0)
                {
                    properties[i].SetValue(this, properties[i].GetValue(response, null), null);
                }
            }
        }

        /// <summary>
        ///   Refreshes object data from server
        /// </summary>
        public void Refresh()
        {
            IAsyncResult result = BeginRefresh(null, null);
            EndRefresh(result);
        }
    }
}