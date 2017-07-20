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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Globalization;

namespace WOWSharp.Community
{
    /// <summary>
    /// Helper class to allow custom parsing of enumeration
    /// </summary>
    /// <typeparam name="T">The enumeration type</typeparam>
    internal static class EnumHelper<T> where T : struct
    {
        /// <summary>
        /// Caches String -> EnumValue data
        /// </summary>
        private static readonly Dictionary<string, T> _stringDict = InitializeStringDict();

        /// <summary>
        /// Caches EnumValue -> String data
        /// </summary>
        private static readonly Dictionary<T, string> _enumDict = InitializeEnumDict();

        /// <summary>
        /// Initializes String -> EnumValue cache
        /// </summary>
        /// <returns>String -> EnumValue cache</returns>
        private static Dictionary<string, T> InitializeStringDict()
        {
            Dictionary<string, T> dict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            Type enumType = typeof(T);
            FieldInfo[] fields = enumType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                object[] attrs = fields[i].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;
                EnumMemberAttribute attr = attrs[0] as EnumMemberAttribute;
                if (attr == null)
                    continue;
                dict.Add(attr.Value, (T)Enum.Parse(enumType, fields[i].Name, true));
            }
            return dict;
        }

        /// <summary>
        /// Initializes EnumValue -> String cache
        /// </summary>
        /// <returns>EnumValue -> String cache</returns>
        private static Dictionary<T, string> InitializeEnumDict()
        {
            Dictionary<T, string> dict = new Dictionary<T, string>();
            Type enumType = typeof(T);
            FieldInfo[] fields = enumType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                object[] attrs = fields[i].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (attrs == null || attrs.Length == 0)
                    continue;
                EnumMemberAttribute attr = attrs[0] as EnumMemberAttribute;
                if (attr == null)
                    continue;
                dict.Add((T)Enum.Parse(enumType, fields[i].Name, true), attr.Value);
            }
            return dict;
        }

        /// <summary>
        /// Returns EnumValue from String representation
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>Enum value</returns>
        public static T ParseEnum(string value)
        {
            int intVal;
            if (int.TryParse(value, out intVal))
                return (T)_enumDict.Keys.Where(k => Convert.ToInt32(k, CultureInfo.InvariantCulture) == intVal).FirstOrDefault();
            return _stringDict[value];
        }

        /// <summary>
        /// Returns string value from Enum value
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>String value</returns>
        public static string EnumToString(T value)
        {
            return _enumDict[value];
        }

        /// <summary>
        /// Gets all the names in an enumeration type
        /// </summary>
        /// <returns></returns>
        /// <remarks>Implemented for Silverlight support</remarks>
        public static string[] GetNames()
        {
            Type enumType = typeof(T);
            var fields = enumType.GetFields().Where(f => f.IsLiteral);
            return fields.Select(field => field.Name).ToArray();
        }

        /// <summary>
        /// Gets all the values in an enumeration type
        /// </summary>
        /// <returns></returns>
        /// <remarks>Implemented for Silverlight support</remarks>
        public static IEnumerable<T> GetValues()
        {
            return GetNames().Select(n => (T)Enum.Parse(typeof(T), n, true));
        }
    }
}


