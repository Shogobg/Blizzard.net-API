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
    public partial class GuildTabardTest : Page
    {
        public GuildTabardTest()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

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

        private void GetTabardButton_Click(object sender, RoutedEventArgs e)
        {
            ApiClient client = new ApiClient((Region)this.RegionCombo.SelectedValue);
            int width = 240;
            int height = 240;
            client.BeginGetGuild(this.RealmNameText.Text, this.GuildNameText.Text, GuildField.Members,
                ar =>
                {
                    try
                    {
                        var guild = client.EndGetGuild(ar);
                        client.BeginGetCharacter(guild.Members[0].Character.Realm, guild.Members[0].Character.Name, CharacterField.Guild,
                            (ar2) =>
                            {
                                var character = client.EndGetCharacter(ar2);
                                character.BeginGenerateTabardImage(width, height,
                                    (ar3) =>
                                    {
                                        Dispatcher.BeginInvoke(() =>
                                            {
                                                this.GuildTabard.Source = character.EndGenerateTabardImage(ar3);
                                            });
                                    }, null);
                            }, null);


                    }
                    catch (WebException ex)
                    {
                        Dispatcher.BeginInvoke(() => MainPage.Goto(new ErrorPage(ex.ToString())));
                        return;
                    }
                }, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.RegionCombo.ItemsSource = Region.AllRegions;
            this.RegionCombo.DisplayMemberPath = "Name";
            this.RegionCombo.SelectedValue = Region.Default;
        }

    }
}
