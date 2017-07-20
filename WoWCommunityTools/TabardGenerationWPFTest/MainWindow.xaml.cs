using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WOWSharp.Community;

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
            ApiClient client = new ApiClient();
            var character = client.GetCharacter("doomhammer", "grendizer", true);
            var res = character.BeginGenerateTabardImage(240, 240, null, null);
            try
            {
                this.image1.Source = character.EndGenerateTabardImage(res);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
