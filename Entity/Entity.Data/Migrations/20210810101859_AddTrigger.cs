using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Data.Migrations
{
    public partial class AddTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER New_Person_Sam on Persons AFTER INSERT AS UPDATE Persons set About='Test_Triger' WHERE Name = 'Test'");
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "TestFild2",
                table: "Persons",
                newName: "TestFild");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER New_Person_Sam");
            migrationBuilder.RenameColumn(
                name: "TestFild",
                table: "Persons",
                newName: "TestFild2");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
