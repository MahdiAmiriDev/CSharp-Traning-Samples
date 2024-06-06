using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfMigration.Migrations
{
    public partial class emptytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("create proc SelectAllPeople as select * from People go");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop Proc SelectAllPeople");
        }
    }
}
