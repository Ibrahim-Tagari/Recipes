using PROG6221.POE.ST10062630;
using System.Windows;
using System.Windows.Controls;
// Menu option to clear the system of all existing data.
namespace PROG6221.POE.ST10062630
{
    public partial class ClearData : UserControl
    {
        public ClearData()
        {
            InitializeComponent();
        }

        // Button code
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            RecipeRepository.ClearRecipes();
            MessageBox.Show("All recipes have been cleared.");
        }
    }
}
