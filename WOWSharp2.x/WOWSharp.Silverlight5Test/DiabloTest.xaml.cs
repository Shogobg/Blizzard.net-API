using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
