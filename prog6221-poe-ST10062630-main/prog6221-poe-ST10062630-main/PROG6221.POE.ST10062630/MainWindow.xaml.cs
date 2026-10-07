using PROG6221.POE.ST10062630;
using System.Windows;
// Main window that houses the basic functionality of the app , each other control belongs to or
    // becomes part of the main window when it is in use. 
namespace PROG6221.POE.ST10062630
{
    public partial class MainWindow : Window
    {
        //Shows the menu options and then directs you to each respective control when an option is selected
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuEnterRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EnterRecipeDetails();
        }

        private void MenuDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DisplayRecipe();
        }

        private void MenuScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ScaleRecipe();
        }

        private void MenuResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ResetQuantities();
        }

        private void MenuFilterRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new FilterRecipe();
        }

        private void MenuClearData_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClearData();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
