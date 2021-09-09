using Microsoft.EntityFrameworkCore.Migrations;

namespace MvCProductStore_1.Migrations
{
    public partial class Dbupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 3, null, "Dagligvarer" });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Address", "Description", "Name" },
                values: new object[] { 3, null, null, "Menu" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 2, 1 });
        }
    }
}
