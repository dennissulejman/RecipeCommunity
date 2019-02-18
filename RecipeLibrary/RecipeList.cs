using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI
{
    public class RecipeList
    {
        public int RecipeListId { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        public Dish Dish { get; set; }

    }
}
