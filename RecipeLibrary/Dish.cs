namespace RecipeLibrary
{
    public partial class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int? CuisineId { get; set; }
        public string Instructions { get; set; }
        public byte[] Picture { get; set; }
        public int? IngredientListId { get; set; }
    }
}
