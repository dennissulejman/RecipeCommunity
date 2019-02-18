using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class NinthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLists_Dishes_DishID",
                table: "RecipeLists");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "RecipeLists",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLists_DishID",
                table: "RecipeLists",
                newName: "IX_RecipeLists_DishId");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "Ingredients",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients",
                newName: "IX_Ingredients_DishId");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "Dishes",
                newName: "DishId");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLists_Dishes_DishId",
                table: "RecipeLists",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLists_Dishes_DishId",
                table: "RecipeLists");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "RecipeLists",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLists_DishId",
                table: "RecipeLists",
                newName: "IX_RecipeLists_DishID");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Ingredients",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_DishId",
                table: "Ingredients",
                newName: "IX_Ingredients_DishID");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Dishes",
                newName: "DishID");

            migrationBuilder.AlterColumn<int>(
                name: "DishID",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishID",
                table: "Ingredients",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLists_Dishes_DishID",
                table: "RecipeLists",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
