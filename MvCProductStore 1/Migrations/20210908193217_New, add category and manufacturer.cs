using Microsoft.EntityFrameworkCore.Migrations;

namespace MvCProductStore_1.Migrations
{
    public partial class Newaddcategoryandmanufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Verktøy" },
                    { 2, null, "Kjøretøy" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Address", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Volvo" },
                    { 2, null, null, "Bosch" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Class", "Description", "ManufacturerId", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 2, null, null, 1, "Volvo XC90", 990000m },
                    { 4, 2, null, null, 1, "Volvo XC60", 620000m },
                    { 5, 2, null, null, 1, "Brød", 25.50m },
                    { 1, 1, null, null, 2, "Hammer", 121.50m },
                    { 2, 1, null, null, 2, "Vinkelsliper", 1520.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
