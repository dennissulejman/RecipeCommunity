using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI
{
    public class Cuisine
    {
        [Key]
        public string TypeOfCuisine { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
