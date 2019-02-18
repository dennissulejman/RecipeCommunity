using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeWPFUI.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "RecipeLists");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Dishes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "RecipeLists",
                nullable: true);
        }
    }
}
