using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class EleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredientAssembly_Dishes_DishId",
                table: "DishIngredientAssembly");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredientAssembly_Ingredients_IngredientId",
                table: "DishIngredientAssembly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredientAssembly",
                table: "DishIngredientAssembly");

            migrationBuilder.RenameTable(
                name: "DishIngredientAssembly",
                newName: "DishIngredientAssemblies");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredientAssembly_DishId",
                table: "DishIngredientAssemblies",
                newName: "IX_DishIngredientAssemblies_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredientAssemblies",
                table: "DishIngredientAssemblies",
                columns: new[] { "IngredientId", "DishId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredientAssemblies_Dishes_DishId",
                table: "DishIngredientAssemblies",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredientAssemblies_Ingredients_IngredientId",
                table: "DishIngredientAssemblies",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredientAssemblies_Dishes_DishId",
                table: "DishIngredientAssemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredientAssemblies_Ingredients_IngredientId",
                table: "DishIngredientAssemblies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredientAssemblies",
                table: "DishIngredientAssemblies");

            migrationBuilder.RenameTable(
                name: "DishIngredientAssemblies",
                newName: "DishIngredientAssembly");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredientAssemblies_DishId",
                table: "DishIngredientAssembly",
                newName: "IX_DishIngredientAssembly_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredientAssembly",
                table: "DishIngredientAssembly",
                columns: new[] { "IngredientId", "DishId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredientAssembly_Dishes_DishId",
                table: "DishIngredientAssembly",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredientAssembly_Ingredients_IngredientId",
                table: "DishIngredientAssembly",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
