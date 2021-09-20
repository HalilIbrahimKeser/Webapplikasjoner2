using Microsoft.EntityFrameworkCore.Migrations;

namespace MvCProductStore_1.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OwnerId",
                table: "Product",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_OwnerId",
                table: "Product",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_OwnerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OwnerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Product");
        }
    }
}
