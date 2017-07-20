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

using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace WOWSharp.Silverlight5Test
{
    /// <summary>
    ///   Guild test page
    /// </summary>
    public partial class GuildTest
    {
        /// <summary>
        ///   ctor
        /// </summary>
        public GuildTest()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        /// <summary>
        ///   Navigated to event
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        /// <summary>
        ///   Pages loaded
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            RegionCombo.ItemsSource = Region.AllRegions;
            RegionCombo.DisplayMemberPath = "Name";
            RegionCombo.SelectedValue = Region.Default;
        }

        /// <summary>
        ///   Fills the realm list auto complete box
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private async void RegionComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = new WowClient((Region) RegionCombo.SelectedValue);
            var result = await client.GetRealmStatusAsync();
            RealmNameText.ItemsSource = result.Realms.Select(realm => realm.Name);
            
        }

        /// <summary>
        ///   Gets guild members
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private async void GetMembersButtonClick(object sender, RoutedEventArgs e)
        {
            var client = new WowClient((Region) RegionCombo.SelectedValue);
            var guild = await client.GetGuildAsync(RealmNameText.Text, GuildNameText.Text, GuildFields.Members);
            GuildMembersGrid.ItemsSource = guild.Members.Select(member => member.Character);
        }
    }
}