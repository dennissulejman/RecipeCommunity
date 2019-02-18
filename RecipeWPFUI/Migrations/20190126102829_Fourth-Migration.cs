using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dishes_DishName",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Users_DishName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeLists",
                columns: table => new
                {
                    RecipeListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Instructions = table.Column<string>(nullable: true),
                    DishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLists", x => x.RecipeListId);
                    table.ForeignKey(
                        name: "FK_RecipeLists_Dishes_DishName",
                        column: x => x.DishName,
                        principalTable: "Dishes",
                        principalColumn: "DishName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipeListId",
                table: "Users",
                column: "RecipeListId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RecipeListId",
                table: "Dishes",
                column: "RecipeListId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLists_DishName",
                table: "RecipeLists",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_RecipeLists_RecipeListId",
                table: "Dishes",
                column: "RecipeListId",
                principalTable: "RecipeLists",
                principalColumn: "RecipeListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RecipeLists_RecipeListId",
                table: "Users",
                column: "RecipeListId",
                principalTable: "RecipeLists",
                principalColumn: "RecipeListId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_RecipeLists_RecipeListId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RecipeLists_RecipeListId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RecipeLists");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecipeListId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RecipeListId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    DishName = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_Dishes_DishName",
                        column: x => x.DishName,
                        principalTable: "Dishes",
                        principalColumn: "DishName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DishName",
                table: "Users",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DishName",
                table: "Recipes",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dishes_DishName",
                table: "Users",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
