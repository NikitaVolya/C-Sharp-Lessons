using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть додаток для роботи з колекцією рецептів. Рецепт
//містить наступні дані:
// назву рецепту;
// назву кухні, звідки родом рецепт (наприклад, італійська або
//японська);
// назву інгредієнтів;
// час приготування;
// покроковий опис процесу приготування.
//Додаток має давати можливість:
// додавати рецепти;
// видаляти рецепти;
// змінювати рецепти;
// шукати рецепти за різними характеристиками;
// зберігати рецепти у файл;
// завантажувати рецепти з файлу.

namespace Exercice1
{
    class Recipe
    {

        public string RecipeName { get; set; }
        public string RecipeOrigin { get; set; }
        public string[] RecipeIngredients { get; set; }
        public int RecipeCookingTime { get; set; }
        public string[] RecipeCookingProcedure { get; set; }

        public void SaveInFile(StreamWriter sw)
        {
            sw.WriteLine("------------ New Recipe ------------");
            sw.WriteLine(RecipeName);
            sw.WriteLine(RecipeOrigin);
            sw.WriteLine(RecipeCookingTime);
            sw.WriteLine("------ Ingredients ------");
            foreach (string ingredient in RecipeIngredients)
                sw.WriteLine(ingredient);
            sw.WriteLine("------ Cooking procedure ------");
            foreach (string procedure in RecipeCookingProcedure)
                sw.WriteLine(procedure);
        }

        public Recipe(string recipeName, string recipe_origin, string[] recipeingredients, 
            int recipe_cooking_time, string[] recipe_cooking_procedure)
        {
            RecipeName = recipeName;
            RecipeOrigin = recipe_origin;
            RecipeIngredients = recipeingredients;
            RecipeCookingTime = recipe_cooking_time;
            RecipeCookingProcedure = recipe_cooking_procedure;
        }

    }

    class RecipeList
    {
        List<Recipe> _recipes;

        public RecipeList()
        {
            _recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe) => _recipes.Add(recipe);
        public void RemoveRecipe(int index) => _recipes.RemoveAt(index);
        public void RemoveRecipe(Recipe recipe) => _recipes.Remove(recipe);
        public Recipe GetRecipe(int index) => this[index];
        public Recipe this[int index]
        {
            get => _recipes[index];
            set => _recipes[index] = value;
        }
        public List<Recipe> GetRecipes(Predicate<Recipe> predicate)
        {
            List<Recipe> rep = new List<Recipe>();
            foreach (Recipe recipe in _recipes)
                if (predicate(recipe))
                    rep.Add(recipe);
            return rep;
        }
        public void SaveToFile(string filepatch)
        {
            using (StreamWriter sw = new StreamWriter(filepatch))
                foreach (Recipe recipe in _recipes)
                    recipe.SaveInFile(sw);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeList recipe_list = new RecipeList();
            recipe_list.AddRecipe(new Recipe("Creamy Garlic Pasta", "Italia", 
                new string[] { "2 teaspoons olive oil", "4 garlic cloves, minced", "2 tablespoons butter", 
                    "3 cups chicken broth, or more as needed", "½ teaspoon ground black pepper", "¼ teaspoon salt", 
                    "½ pound spaghetti", "1 cup grated Parmesan cheese", "¾ cup heavy cream", "1 ½ tablespoons dried parsley" },
                30, 
                new string[] { "Gather all ingredients",
                    "Heat olive oil in a medium pan over medium heat. Add garlic and stir until fragrant, 1 to 2 minutes. Add butter and stir constantly until melted. ", 
                    "Pour in 3 cups chicken broth; add pepper and salt. Bring to a boil. Add spaghetti and cook, stirring occasionally, until tender yet firm to the bite, about 12 minutes. Add more chicken broth if pasta starts to stick to the pan. ",
                    "Add Parmesan cheese, cream, and parsley and mix until thoroughly combined. Serve immediately. "}));
            
            recipe_list.AddRecipe(new Recipe("Taiwanese Egg Crepe Ingredients", "Taiwan",
                new string[] { "4 tbsp of Flour or Cake Flour", "2 tbsp of Sweet Potato Starch/Tapioca Starch ** use this brand*", 
                    "½ cup of Water", "1 tsp of Salt", "1 tsp of White Pepper", "Green Onion", "2 Eggs " },
                15, 
                new string[] { "Mix flour, sweet potato flour, water, salt, and white pepper until it is a running consistency, then mix in the chopped green onions.", 
                    "In a pan, turn the heat up to medium-high and drizzle in a little bit of oil. Once the pan is hot, pour the pancake mixture in the pan and let it sit for around 2-3 minutes.", 
                    "Let it sit for another 1-2 minutes and set aside.", 
                    "Drizzle in a little bit more oil and pour in 1 beaten egg, and add back in the pancake", 
                    "Let it sit for around 30 seconds – 1 minute or until the egg is stuck to the pancake and flip.", 
                    "Roll up the pancake and add in any topping of your choice. " }));

            recipe_list.SaveToFile("recipes.txt");
        }
    }
}
