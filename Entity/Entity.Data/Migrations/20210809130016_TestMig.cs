using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Data.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestFild",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestFild",
                table: "Persons");
        }
    }
}