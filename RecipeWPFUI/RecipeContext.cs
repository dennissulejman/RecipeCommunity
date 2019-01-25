using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RecipeWPFUI
{
    public class RecipeContext : DbContext
    {
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Dish> Dishes { get; set; } 
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["RecipeContext"]
            .ConnectionString, options => options.EnableRetryOnFailure())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }

}
