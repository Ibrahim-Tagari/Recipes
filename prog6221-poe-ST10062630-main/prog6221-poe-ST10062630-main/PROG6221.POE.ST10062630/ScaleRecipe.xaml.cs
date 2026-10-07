using PROG6221.POE.ST10062630;
using System;
using System.Windows;
using System.Windows.Controls;
// Scalability of recipes , methods / functions are self explanatory.
namespace PROG6221.POE.ST10062630
{
    public partial class ScaleRecipe : UserControl
    {
        private Recipe selectedRecipe;

        public ScaleRecipe()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            var recipes = RecipeRepository.GetRecipes();
            RecipeList.ItemsSource = recipes;
        }

        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = RecipeList.SelectedItem as Recipe;
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null && double.TryParse(ScaleFactor.Text, out double scaleFactor))
            {
                DisplayScaledRecipe(selectedRecipe, scaleFactor);
            }
            else
            {
                MessageBox.Show("Please select a recipe and enter a valid scale factor.");
            }
        }

        private void DisplayScaledRecipe(Recipe recipe, double scaleFactor)
        {
            ScaledRecipeDetails.Text = $"Name: {recipe.Name}\n\nIngredients:\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                double scaledQuantity = ingredient.Quantity * scaleFactor;
                ScaledRecipeDetails.Text += $"- {scaledQuantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories * scaleFactor} calories, {ingredient.FoodGroup})\n";
            }
            ScaledRecipeDetails.Text += $"\nTotal Calories: {recipe.TotalCalories * scaleFactor}\n\nSteps:\n";
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                ScaledRecipeDetails.Text += $"{i + 1}. {recipe.Steps[i]}\n";
            }
        }
    }
}
