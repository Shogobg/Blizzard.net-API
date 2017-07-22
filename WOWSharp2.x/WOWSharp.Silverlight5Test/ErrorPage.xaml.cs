
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