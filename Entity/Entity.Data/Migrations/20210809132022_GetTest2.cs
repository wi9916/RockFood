using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Data.Migrations
{
    public partial class GetTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestFild",
                table: "Persons",
                newName: "TestFild2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestFild2",
                table: "Persons",
                newName: "TestFild");
        }
    }
}
