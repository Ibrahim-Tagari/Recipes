using System.Windows.Controls;

namespace PROG6221.POE.ST10062630
{
    public partial class IngredientControl : UserControl
    {
        public IngredientControl()
        {
            InitializeComponent();
        }

        public string IngredientName => IngredientNameTextBox.Text;
        public double IngredientQuantity => double.TryParse(IngredientQuantityTextBox.Text, out double quantity) ? quantity : 0;
        public string IngredientUnit => IngredientUnitTextBox.Text;
        public int IngredientCalories => int.TryParse(IngredientCaloriesTextBox.Text, out int calories) ? calories : 0;
        public string FoodGroup => FoodGroupComboBox.SelectedItem.ToString();
    }
}
