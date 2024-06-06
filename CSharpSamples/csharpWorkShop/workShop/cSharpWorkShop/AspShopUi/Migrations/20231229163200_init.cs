using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspShopUi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mobile", "awsome", "apple 13", 1222220000 },
                    { 2, "Mobile", "good", "galaxy ultra", 22400000 },
                    { 3, "Mobile", "nice", "poco f12", 400000 },
                    { 4, "Mobile", "not bad", "hoawi", 550000 },
                    { 5, "LapTop", "gaming", "rog asus", 240000000 },
                    { 6, "Laptop", "mac book", "apple", 234440000 },
                    { 7, "SmartWatch", "4 inch", "apple", 224232 },
                    { 8, "SmartWatch", "andriod", "galaxyWatch", 233333333 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
