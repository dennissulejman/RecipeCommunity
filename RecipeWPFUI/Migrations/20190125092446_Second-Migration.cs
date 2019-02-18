using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisines_Dishes_DishName",
                table: "Cuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_DishName",
                table: "Cuisines");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Cuisines");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Dishes",
                newName: "CuisineTypeOfCuisine");

            migrationBuilder.AlterColumn<string>(
                name: "CuisineTypeOfCuisine",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CuisineTypeOfCuisine",
                table: "Dishes",
                column: "CuisineTypeOfCuisine");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Cuisines_CuisineTypeOfCuisine",
                table: "Dishes",
                column: "CuisineTypeOfCuisine",
                principalTable: "Cuisines",
                principalColumn: "TypeOfCuisine",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Cuisines_CuisineTypeOfCuisine",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CuisineTypeOfCuisine",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "CuisineTypeOfCuisine",
                table: "Dishes",
                newName: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Cuisines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_DishName",
                table: "Cuisines",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisines_Dishes_DishName",
                table: "Cuisines",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
