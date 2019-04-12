using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;

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

        public void DetachAllEntities()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)

                .ToList();
            foreach (var entry in changedEntries)
                entry.State = EntityState.Detached;
        }
    }
}
