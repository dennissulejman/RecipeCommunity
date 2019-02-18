using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLists_Dishes_DishName",
                table: "RecipeLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLists_DishName",
                table: "RecipeLists");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "RecipeLists");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "RecipeLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishName",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "Dishes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLists_DishID",
                table: "RecipeLists",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients",
                column: "DishID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLists_Dishes_DishID",
                table: "RecipeLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLists_DishID",
                table: "RecipeLists");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "RecipeLists");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "RecipeLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishName",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLists_DishName",
                table: "RecipeLists",
                column: "DishName");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLists_Dishes_DishName",
                table: "RecipeLists",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "DishName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
