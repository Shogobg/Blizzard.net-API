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
using WOWSharp.Community.Diablo;
using System.Threading.Tasks;

namespace WOWSharp.Silverlight5Test
{
    public partial class DiabloTest : Page
    {
        public DiabloTest()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// Load all items
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private Task LoadAllItems(DiabloClient client, Hero hero)
        {
            var tasks = hero.Items.AllItems.Select(i => i.RefreshAsync(client, true));
            var whenAll = new Task(() => Task.WaitAll(tasks.ToArray()));
            whenAll.Start();
            return whenAll;
        }

        /// <summary>
        /// Load all heroes
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        private async Task LoadAllHeroes(DiabloClient client, DiabloProfile profile)
        {
            var tasks = profile.Heroes.Take(1).Select(
                async h => 
                    {
                        await h.RefreshAsync(client, true);
                        await LoadAllItems(client, h);
                    });

            var whenAll = new Task(() => Task.WaitAll(tasks.ToArray()));
            whenAll.Start();
            await whenAll;
        }

        /// <summary>
        /// Loads a hero then loads all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new DiabloClient();
            var profile = await client.GetProfileAsync(BattleTag.Text);
            Characters.ItemsSource = profile.Heroes;
            await LoadAllHeroes(client, profile);
            Items.ItemsSource = profile.Heroes.Take(1).SelectMany(h => h.Items.AllItems);
        }

    }
}