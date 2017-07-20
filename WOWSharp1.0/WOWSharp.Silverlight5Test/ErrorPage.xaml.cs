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

using System.Windows;
using System.Windows.Navigation;

namespace WOWSharp.Silverlight5Test
{
    /// <summary>
    ///   Error PAge
    /// </summary>
    public partial class ErrorPage
    {
        /// <summary>
        ///   ctor
        /// </summary>
        /// <param name="errorText"> error message </param>
        public ErrorPage(string errorText)
        {
            InitializeComponent();
            ErrorText.Text = errorText;
        }


        // Executes when the user navigates to this page.
        /// <summary>
        ///   Handles navigate event
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        ///   Back to main
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void BackToMainButtonClick(object sender, RoutedEventArgs e)
        {
            MainPage.Goto(new MainPage());
        }
    }
}