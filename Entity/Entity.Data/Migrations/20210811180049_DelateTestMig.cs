using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Data.Migrations
{
    public partial class DelateTestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TestFild",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestFild",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
