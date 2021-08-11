using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Data.Migrations
{
    public partial class Triger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER New_Person_Sam on Persons AFTER INSERT AS UPDATE Persons set About='Test_Triger' WHERE Name = 'Test'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER New_Person_Sam");
        }
    }
}
