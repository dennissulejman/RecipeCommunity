using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI
{
    public class Dish
    {
        [Key]
        public string DishName { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Amount { get; set; }
        public string Instructions { get; set; }
    }
}
