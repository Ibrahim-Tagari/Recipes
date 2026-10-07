using PROG6221.POE.ST10062630;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
// Reset the quantities to the original values inserted by the user.
namespace PROG6221.POE.ST10062630
{
    public partial class ResetQuantities : UserControl
    {
        private Recipe selectedRecipe;
        private Dictionary<Ingredient, (double Quantity, string Unit, int Calories)> originalValues;

        public ResetQuantities()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            var recipes = RecipeRepository.GetRecipes();
            RecipeList.ItemsSource = recipes;
            RecipeList.DisplayMemberPath = "Name";
        }
        // Changes values
        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeList.SelectedItem is Recipe recipe)
            {
                selectedRecipe = recipe;
                SaveOriginalValues();
            }
        }
       
        private void SaveOriginalValues()
        {
            originalValues = new Dictionary<Ingredient, (double Quantity, string Unit, int Calories)>();
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                // Assuming IngredientControl exposes these properties correctly
                originalValues.Add(ingredient, (ingredient.Quantity, ingredient.Unit, ingredient.Calories));
            }
        }

        //Button code
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                ResetRecipeQuantities(selectedRecipe);
                DisplayRecipeDetails(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.");
            }
        }
        // Reset quantities method
        private void ResetRecipeQuantities(Recipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (originalValues.ContainsKey(ingredient))
                {
                    var originalValue = originalValues[ingredient];
                    ingredient.Quantity = originalValue.Quantity;
                    ingredient.Unit = originalValue.Unit;
                    ingredient.Calories = originalValue.Calories;
                }
            }
        }
        // Display method
        private void DisplayRecipeDetails(Recipe recipe)
        {
            ResetRecipeDetails.Text = $"Name: {recipe.Name}\n\nIngredients:\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                ResetRecipeDetails.Text += $"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})\n";
            }
            ResetRecipeDetails.Text += $"\nTotal Calories: {recipe.TotalCalories}\n\nSteps:\n";
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                ResetRecipeDetails.Text += $"{i + 1}. {recipe.Steps[i]}\n";
            }
        }
    }
}
