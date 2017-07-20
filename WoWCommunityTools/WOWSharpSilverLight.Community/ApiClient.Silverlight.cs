/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace WOWSharp.Community
{
    /// <summary>
    /// Methods that request special handling in silverlight
    /// </summary>
    public partial class ApiClient
    {
        private static string _proxyHandlerUrl = "WOWSharpHandler.axd";
        
        /// <summary>
        /// Gets or set the url of the HttpHandler that routes the requests to Blizzard's site
        /// </summary>
        public static string ProxyHandlerUrl
        {
            get
            {
                return _proxyHandlerUrl;
            }
            set
            {
                _proxyHandlerUrl = value;
            }
        }

        private const string RegionNameHttpHeader = "X-WOWSharpProxy-Region";
        private const string ApiUrlHttpHeader = "X-WOWSharpProxy-Url";
        private const string LocaleHttpHeader = "X-WOWSharpProxy-Locale";

        /// <summary>
        /// The host uri
        /// </summary>
        private static Uri _hostUrl;

        /// <summary>
        /// The host uri
        /// </summary>
        public static Uri HostUrl
        {
            get
            {
                if (_hostUrl == null)
                {
                    _hostUrl = Application.Current.Host.Source;
                }
                return _hostUrl;
            }
        }

        /// <summary>
        /// Creates a GET request
        /// </summary>
        /// <param name="path">url</param>
        /// <returns>the HTTP request object</returns>
        protected virtual HttpWebRequest CreateGetRequest(string path)
        {
            // If we have elevated permissions make the application directly to Blizzard sites
            if (Application.Current.HasElevatedPermissions)
            {
                Uri uri = new Uri("http://" + Region.HostUrl + path);
                if (!string.IsNullOrEmpty(uri.Query))
                {
                    uri = new Uri(uri.ToString() + "&locale=" + this.Locale.Replace('-', '_'));
                }
                else
                {
                    uri = new Uri(uri.ToString() + "?locale=" + this.Locale.Replace('-', '_'));
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                return request;
            }
            else
            {
                Uri uri = new Uri(HostUrl, ProxyHandlerUrl);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers[RegionNameHttpHeader] = Region.Name;
                request.Headers[ApiUrlHttpHeader] = path;
                request.Headers[LocaleHttpHeader] = Locale;
                return request;
            }
        }
    }
}
