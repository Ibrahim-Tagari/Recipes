using PROG6221.POE.ST10062630;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
// Displays the recipe when the Display recipe otion is selected , prompts the user to select a recipe
//  then click a button which will then display the selected recipe.
namespace PROG6221.POE.ST10062630
{
    public partial class DisplayRecipe : UserControl
    {
        public DisplayRecipe()
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

        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeList.SelectedItem is Recipe selectedRecipe)
            {
                DisplayRecipeDetails(selectedRecipe);
            }
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            RecipeDetails.Inlines.Clear();
            var boldUnderline = new Bold(new Underline(new Run(recipe.Name))) { Foreground = Brushes.Black };
            RecipeDetails.Inlines.Add(boldUnderline);
            RecipeDetails.Inlines.Add(new Run("\n\nIngredients:\n"));
            foreach (var ingredient in recipe.Ingredients)
            {
                RecipeDetails.Inlines.Add(new Run($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})\n"));
            }
            RecipeDetails.Inlines.Add(new Run($"\nTotal Calories: {recipe.TotalCalories}\n\nSteps:\n"));
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                RecipeDetails.Inlines.Add(new Run($"{i + 1}. {recipe.Steps[i]}\n"));
            }
        }
    }
}
