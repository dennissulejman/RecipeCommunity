using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace RecipeWPFUI
{
    public class RecipeContext : DbContext
    {
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<RecipeList> RecipeLists { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DishIngredientAssembly> DishIngredientAssemblies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["RecipeContext"]
            .ConnectionString, options => options.EnableRetryOnFailure())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredientAssembly>().HasKey(dia => new { dia.IngredientId, dia.DishId });
        }
    }
}
