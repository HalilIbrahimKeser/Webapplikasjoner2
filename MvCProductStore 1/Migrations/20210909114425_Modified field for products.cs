using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvCProductStore_1.Migrations
{
    public partial class Modifiedfieldforproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "modified",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modified",
                table: "Product");
        }
    }
}
