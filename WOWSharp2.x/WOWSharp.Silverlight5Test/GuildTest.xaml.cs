
using System.Linq;
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