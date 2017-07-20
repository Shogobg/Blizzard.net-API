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
using System.Windows.Data;

namespace System.Windows.Media
{
    /// <summary>
    /// Color converter class implementation since it doesn't exist in silverlight
    /// </summary>
    public class ColorConverter
    {
        /// <summary>
        /// Attempts to convert a string to a Color. 
        /// </summary>
        /// <param name="val">The string to convert to a Color. </param>
        /// <returns>color object</returns>
        public static object ConvertFromString(string val)
        {
            val = val.Replace("#", "");

            byte a = Convert.ToByte("ff", 16);
            byte pos = 0;
            if (val.Length == 8)
            {
                a = Convert.ToByte(val.Substring(pos, 2), 16);
                pos = 2;
            }

            byte r = Convert.ToByte(val.Substring(pos, 2), 16);
            pos += 2;

            byte g = Convert.ToByte(val.Substring(pos, 2), 16);
            pos += 2;

            byte b = Convert.ToByte(val.Substring(pos, 2), 16);

            Color col = Color.FromArgb(a, r, g, b);

            return col;
        }
    }
}
