namespace RecipeLibrary
{
    public partial class DishIngredientList
    {
        public int IngredientId { get; set; }
        public int DishId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
