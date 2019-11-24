using Microsoft.EntityFrameworkCore;

namespace RecipeLibrary
{
    public partial class RecipeContext : DbContext
    {
        public RecipeContext()
        {
        }

        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishIngredientList> DishIngredientLists { get; set; }
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<RecipeList> RecipeLists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecipeContext;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.HasKey(e => e.CuisineId);

                entity.ToTable("cuisines");

                entity.Property(e => e.CuisineId)
                    .HasColumnName("cuisineid")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeOfCuisine)
                    .HasColumnName("typeofcuisine")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.DishId);

                entity.HasIndex(e => e.CuisineId)
                    .HasName("IX_Dishes_CuisineTypeOfCuisine");

                entity.Property(e => e.DishId).HasColumnName("dishid");

                entity.Property(e => e.CuisineId).HasColumnName("cuisineid");

                entity.Property(e => e.DishName)
                    .HasColumnName("dishname")
                    .IsUnicode(false);

                entity.Property(e => e.IngredientListId).HasColumnName("ingredientlistid");

                entity.Property(e => e.Instructions)
                    .HasColumnName("instructions")
                    .IsUnicode(false);

                entity.Property(e => e.Picture).HasColumnName("picture");
            });

            modelBuilder.Entity<DishIngredientList>(entity =>
            {
                entity.HasKey(e => new { e.IngredientId, e.DishId })
                    .HasName("PK_DishIngredientAssemblies");

                entity.ToTable("dishingredientlists");

                entity.HasIndex(e => e.DishId)
                    .HasName("IX_DishIngredientAssemblies_DishId");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientid");

                entity.Property(e => e.DishId).HasColumnName("dishid");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("ingredientcategories");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryid")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("PK_Ingredients");

                entity.ToTable("ingredients");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientid");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipeList>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.DishId)
                    .HasName("IX_RecipeLists_DishId");

                entity.Property(e => e.DishId).HasColumnName("dishid");

                entity.Property(e => e.RecipeListId)
                    .HasColumnName("recipelistid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("userid");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("userid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
