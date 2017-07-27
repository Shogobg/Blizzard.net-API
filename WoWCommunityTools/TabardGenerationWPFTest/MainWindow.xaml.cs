using System;
using System.Windows;
using WOWSharp.Community;
using WOWSharp.Community.Wow;

namespace TabardGenerationWPFTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var client = new WowClient(Region.US, "", "pt", null);
			var character = client.GetCharacterAsync("doomhammer", "grendizer", CharacterFields.All).Result;
            //var res = character.BeginGenerateTabardImage(240, 240, null, null);
            try
            {
                //this.image1.Source = character.EndGenerateTabardImage(res);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
