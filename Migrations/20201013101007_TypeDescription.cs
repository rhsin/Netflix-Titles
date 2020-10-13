using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTitle.Migrations
{
    public partial class TypeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Title",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Title",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Title");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Title");
        }
    }
}
