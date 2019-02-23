using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI
{
    public class DishIngredientAssembly
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
