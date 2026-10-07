using PROG6221.POE.ST10062630; // Ensure this using directive is added

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
// Code to filter the recipes by each or all options.
namespace PROG6221.POE.ST10062630
{
    public partial class FilterRecipe : UserControl
    {
        public FilterRecipe()
        {
            InitializeComponent();
        }
        // Hardcoded filter options
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            var recipes = RecipeRepository.GetRecipes();

            if (!string.IsNullOrEmpty(IngredientFilter.Text))
            {
                recipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.Contains(IngredientFilter.Text))).ToList();
            }

            if (FoodGroupFilter.SelectedItem is ComboBoxItem selectedFoodGroupItem && selectedFoodGroupItem.Content.ToString() != "None")
            {
                var selectedFoodGroup = selectedFoodGroupItem.Content.ToString();
                recipes = recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup == selectedFoodGroup)).ToList();
            }

            if (int.TryParse(MaxCaloriesFilter.Text, out int maxCalories))
            {
                recipes = recipes.Where(r => r.TotalCalories <= maxCalories).ToList();
            }

            DisplayFilteredRecipes(recipes);
        }
        // Displays the recipe according to filter
        private void DisplayFilteredRecipes(List<Recipe> recipes)
        {
            FilteredRecipes.Text = "Filtered Recipes:\n";
            foreach (var recipe in recipes)
            {
                FilteredRecipes.Text += $"Name: {recipe.Name}, Total Calories: {recipe.TotalCalories}\n";
            }
        }
    }
}
