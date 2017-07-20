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
using System.Windows.Navigation;
using WOWSharp.Community;
using WOWSharp.Community.ObjectModel;

namespace ApiSilverlightTestApplication
{
    /// <summary>
    /// Guild test page
    /// </summary>
    public partial class GuildTest : Page
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GuildTest()
        {
            InitializeComponent();
        }

        
        
        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// fills the regions combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.RegionCombo.ItemsSource = Region.AllRegions;
            this.RegionCombo.DisplayMemberPath = "Name";
            this.RegionCombo.SelectedValue = Region.Default;
        }

        /// <summary>
        /// Fills the realm list auto complete box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApiClient client = new ApiClient((Region)this.RegionCombo.SelectedValue);
            client.BeginGetRealmStatus(ar =>
                {
                    var realms = client.EndGetRealmStatus(ar);
                    Dispatcher.BeginInvoke(() =>
                    this.RealmNameText.ItemsSource = realms.Realms.Select(realm => realm.Name));
                }, null);
        }

        /// <summary>
        /// Gets guild members
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetMembersButton_Click(object sender, RoutedEventArgs e)
        {
            ApiClient client = new ApiClient((Region)this.RegionCombo.SelectedValue);
            client.BeginGetGuild(this.RealmNameText.Text, this.GuildNameText.Text, GuildField.Members,
                ar =>
                {
                    try
                    {
                        var guild = client.EndGetGuild(ar);
                        Dispatcher.BeginInvoke(() =>
                        {
                            this.GuildMembersGrid.ItemsSource = guild.Members.Select(member => member.Character);
                        }
                        );
                    }
                    catch (WebException ex)
                    {
                        Dispatcher.BeginInvoke(() => MainPage.Goto(new ErrorPage(ex.ToString())));
                        return;
                    }
                }, null);
        }

    }
}
