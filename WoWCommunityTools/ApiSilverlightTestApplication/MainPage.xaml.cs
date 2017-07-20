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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WOWSharp.Community;
using WOWSharp.Community.ObjectModel;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace ApiSilverlightTestApplication
{
    /// <summary>
    /// Main page
    /// </summary>
    public partial class MainPage : UserControl
    {
        private static UserControl _main;

        public static Dispatcher MainDispatcher
        {
            get
            {
                return _main.Dispatcher;
            }
        }

        public static void Goto(UserControl control)
        {
            if (_main != null)
            {
                _main.Content = control;
                _main = control;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Go To Guild test page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestGuildButton_Click(object sender, RoutedEventArgs e)
        {
            Goto(new GuildTest());
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (_main == null)
                _main = this;

        }

        private void TestTabardsButton_Click(object sender, RoutedEventArgs e)
        {
            Goto(new GuildTabardTest());
        }
    }
}
