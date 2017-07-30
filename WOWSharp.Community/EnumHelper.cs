using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Helper class to allow custom parsing of enumeration
    /// </summary>
    /// <typeparam name="T"> The enumeration type </typeparam>
    internal static class EnumHelper<T> where T : struct
    {
        /// <summary>
        ///   Caches String -> EnumValue data
        /// </summary>
        private static readonly Dictionary<string, T> _stringDict = InitializeStringDict();

        /// <summary>
        ///   Caches EnumValue -> String data
        /// </summary>
        private static readonly Dictionary<T, string> _enumDict = InitializeEnumDict();

        /// <summary>
        ///   Initializes String -> EnumValue cache
        /// </summary>
        /// <returns> String -> EnumValue cache </returns>
        private static Dictionary<string, T> InitializeStringDict()
        {
            var dict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            Type enumType = typeof (T);
            FieldInfo[] fields = enumType.GetFields();
            foreach (var field in fields)
            {
                object[] attrs = field.GetCustomAttributes(typeof (EnumMemberAttribute), false);
				if (attrs == null || attrs.Length == 0)
				{
					continue;
				}

                var attr = attrs[0] as EnumMemberAttribute;
				if (attr == null)
				{
					continue;
				}

                dict.Add(attr.Value, (T) Enum.Parse(enumType, field.Name, true));
            }

            return dict;
        }

        /// <summary>
        ///   Initializes EnumValue -> String cache
        /// </summary>
        /// <returns> EnumValue -> String cache </returns>
        private static Dictionary<T, string> InitializeEnumDict()
        {
            var dict = new Dictionary<T, string>();
            Type enumType = typeof (T);
            FieldInfo[] fields = enumType.GetFields();
            foreach (var field in fields)
            {
                object[] attrs = field.GetCustomAttributes(typeof (EnumMemberAttribute), false);
				if (attrs == null || attrs.Length == 0)
				{
					continue;
				}

                var attr = attrs[0] as EnumMemberAttribute;
				if (attr == null)
				{
					continue;
				}

                dict.Add((T) Enum.Parse(enumType, field.Name, true), attr.Value);
            }
            return dict;
        }

        /// <summary>
        ///   Returns EnumValue from String representation
        /// </summary>
        /// <param name="value"> string value </param>
        /// <returns> Enum value </returns>
        public static T ParseEnum(string value)
        {
            int intVal;

			if (int.TryParse(value, out intVal))
			{
				return _enumDict.Keys.Where(k => Convert.ToInt32(k, CultureInfo.InvariantCulture) == intVal).FirstOrDefault();
			}

            T enumValue;

			if (_stringDict.TryGetValue(value, out enumValue))
			{
				return enumValue;
			}

            throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.InvariantCulture, ErrorMessages.EnumValueInvalid, value, typeof(T).Name));
        }

        /// <summary>
        ///   Returns string value from Enum value
        /// </summary>
        /// <param name="value"> string value </param>
        /// <returns> String value </returns>
        public static string EnumToString(T value)
        {
            return _enumDict[value];
        }

        /// <summary>
        ///   Gets all the names in an enumeration type
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        ///   Implemented for Silverlight support
        /// </remarks>
        public static string[] GetNames()
        {
            Type enumType = typeof (T);
            var fields = enumType.GetFields().Where(f => f.IsLiteral);
            return fields.Select(field => field.Name).ToArray();
        }

        /// <summary>
        ///   Gets all the values in an enumeration type
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        ///   Implemented for Silverlight support
        /// </remarks>
        public static IEnumerable<T> GetValues()
        {
            return GetNames().Select(n => (T) Enum.Parse(typeof (T), n, true));
        }
    }
}