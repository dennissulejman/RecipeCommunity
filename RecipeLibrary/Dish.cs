using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Instructions { get; set; }
        public Cuisine Cuisine { get; set; }
    }
}
