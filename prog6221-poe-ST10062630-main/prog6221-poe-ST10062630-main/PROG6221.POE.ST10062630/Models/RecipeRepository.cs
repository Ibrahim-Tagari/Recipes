using PROG6221.POE.ST10062630;
using System.Collections.Generic;
// This class is created to keep track and do error handlind of the recipes as a whole
namespace PROG6221.POE.ST10062630
{
    public static class RecipeRepository
    {
        private static List<Recipe> recipes = new List<Recipe>();

        //Add recipe
        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static List<Recipe> GetRecipes()
        {
            return recipes;
        }

        // Clear recipe details
        public static void ClearRecipes()
        {
            recipes.Clear();
         /* Recipes.Clear(); */
        }


    }
}
