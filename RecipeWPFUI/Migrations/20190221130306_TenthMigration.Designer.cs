﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeWPFUI;

namespace RecipeWPFUI.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20190221130306_TenthMigration")]
    partial class TenthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeWPFUI.Cuisine", b =>
                {
                    b.Property<string>("TypeOfCuisine")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TypeOfCuisine");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("RecipeWPFUI.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CuisineTypeOfCuisine");

                    b.Property<string>("DishName");

                    b.Property<string>("Instructions");

                    b.Property<int?>("RecipeListId");

                    b.HasKey("DishId");

                    b.HasIndex("CuisineTypeOfCuisine");

                    b.HasIndex("RecipeListId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("RecipeWPFUI.DishIngredientAssembly", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("DishId");

                    b.HasKey("IngredientId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishIngredientAssembly");
                });

            modelBuilder.Entity("RecipeWPFUI.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeWPFUI.RecipeList", b =>
                {
                    b.Property<int>("RecipeListId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DishId");

                    b.HasKey("RecipeListId");

                    b.HasIndex("DishId");

                    b.ToTable("RecipeLists");
                });

            modelBuilder.Entity("RecipeWPFUI.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int?>("RecipeListId");

                    b.HasKey("Username");

                    b.HasIndex("RecipeListId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeWPFUI.Dish", b =>
                {
                    b.HasOne("RecipeWPFUI.Cuisine", "Cuisine")
                        .WithMany("Dishes")
                        .HasForeignKey("CuisineTypeOfCuisine");

                    b.HasOne("RecipeWPFUI.RecipeList")
                        .WithMany("Dishes")
                        .HasForeignKey("RecipeListId");
                });

            modelBuilder.Entity("RecipeWPFUI.DishIngredientAssembly", b =>
                {
                    b.HasOne("RecipeWPFUI.Dish", "Dish")
                        .WithMany("DishIngredientAssemblies")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecipeWPFUI.Ingredient", "Ingredient")
                        .WithMany("DishIngredientAssemblies")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeWPFUI.RecipeList", b =>
                {
                    b.HasOne("RecipeWPFUI.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId");
                });

            modelBuilder.Entity("RecipeWPFUI.User", b =>
                {
                    b.HasOne("RecipeWPFUI.RecipeList", "RecipeList")
                        .WithMany()
                        .HasForeignKey("RecipeListId");
                });
#pragma warning restore 612, 618
        }
    }
}
