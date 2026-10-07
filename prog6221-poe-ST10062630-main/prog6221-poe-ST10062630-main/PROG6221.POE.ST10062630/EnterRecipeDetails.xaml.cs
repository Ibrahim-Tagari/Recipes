using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
// Prompts the user to enter the recipe details then click a button to save such details
// into a recipe format, this happens when the user selects the Enter recipe details option from the menu.
namespace PROG6221.POE.ST10062630
{
    public partial class EnterRecipeDetails : UserControl
    {
        private List<IngredientControl> ingredientControls = new List<IngredientControl>();
        private List<TextBox> stepTextBoxes = new List<TextBox>();

        public EnterRecipeDetails()
        {
            InitializeComponent();
            AddPlaceholderText(RecipeName, null);
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            int numIngredients = int.TryParse(NumIngredients.Text, out int result) ? result : 0;
            IngredientsPanel.Children.Clear();
            ingredientControls.Clear();
            for (int i = 0; i < numIngredients; i++)
            {
                var ingredientControl = new IngredientControl();
                ingredientControls.Add(ingredientControl);
                IngredientsPanel.Children.Add(ingredientControl);
            }
        }

        private void AddSteps_Click(object sender, RoutedEventArgs e)
        {
            int numSteps = int.TryParse(NumSteps.Text, out int result) ? result : 0;
            StepsPanel.Children.Clear();
            stepTextBoxes.Clear();
            for (int i = 0; i < numSteps; i++)
            {
                var stepTextBox = new TextBox { Margin = new Thickness(5), Text = $"Step {i + 1}" };
                stepTextBox.GotFocus += RemovePlaceholderText;
                stepTextBox.LostFocus += AddPlaceholderText;
                stepTextBoxes.Add(stepTextBox);
                StepsPanel.Children.Add(stepTextBox);
            }
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipe = new Recipe
            {
                Name = RecipeName.Text,
                Ingredients = new List<Ingredient>(),
                Steps = new List<string>()
            };

            foreach (var control in ingredientControls)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    Name = control.IngredientName,
                    Quantity = control.IngredientQuantity,
                    Unit = control.IngredientUnit,
                    Calories = control.IngredientCalories,
                    FoodGroup = control.FoodGroup
                });
            }

            foreach (var textBox in stepTextBoxes)
            {
                recipe.Steps.Add(textBox.Text);
            }

            RecipeRepository.AddRecipe(recipe);
            MessageBox.Show("Recipe saved successfully!");
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Recipe Name" || textBox.Text.StartsWith("Step "))
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == RecipeName)
                {
                    textBox.Text = "Recipe Name";
                }
                else if (textBox.Text.StartsWith("Step "))
                {
                    textBox.Text = textBox.Text;
                }
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
