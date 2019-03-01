using System.Collections.Generic;
namespace RecipeWPFUI
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<DishIngredientAssembly> DishIngredientAssemblies { get; set; } = new List<DishIngredientAssembly>();
    }
}
