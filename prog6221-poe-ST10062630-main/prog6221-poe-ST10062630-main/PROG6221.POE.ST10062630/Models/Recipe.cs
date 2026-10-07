using System.Collections.Generic;
// This class is created to handle the insertion and displaying of Ingredients and steps
namespace PROG6221.POE.ST10062630
{
    // Retrieves and displays the recipe details
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public int TotalCalories
        {
            get
            {
                int total = 0;
                foreach (var ingredient in Ingredients)
                {
                    total += ingredient.Calories;
                }
                return total;
            }
        }
    }
    // Retrieve and display information for the ingredients
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }  // Add Quantity property
        public string Unit { get; set; }      // Add Unit property
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
