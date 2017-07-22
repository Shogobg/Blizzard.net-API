
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WOWSharp.Silverlight5Test
{
    /// <summary>
    ///   Main page
    /// </summary>
    public partial class MainPage
    {
        /// <summary>
        ///   singleton reference to main page
        /// </summary>
        private static UserControl _main;

        /// <summary>
        ///   ctor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   Dispatcher for main page
        /// </summary>
        public static Dispatcher MainDispatcher
        {
            get
            {
                return _main.Dispatcher;
            }
        }

        /// <summary>
        ///   Go to a page
        /// </summary>
        /// <param name="control"> </param>
        public static void Goto(UserControl control)
        {
            if (_main != null)
            {
                _main.Content = control;
                _main = control;
            }
        }

        /// <summary>
        ///   Go To Guild test page
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void TestGuildButtonClick(object sender, RoutedEventArgs e)
        {
            Goto(new GuildTest());
        }

        /// <summary>
        ///   Load event to set the singleton reference
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void LayoutRootLoaded(object sender, RoutedEventArgs e)
        {
            if (_main == null)
                _main = this;
            //TestTabardsButton.Content = typeof (Application).AssemblyQualifiedName;
        }

        /// <summary>
        ///   Tabards test page
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void TestTabardsButtonClick(object sender, RoutedEventArgs e)
        {
            //Goto(new GuildTabardTest());
        }

        private void TestDiablo_Click(object sender, RoutedEventArgs e)
        {
            Goto(new DiabloTest());
        }
    }
}