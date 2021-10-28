using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 301, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 28, 20, 25, 2, 307, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ApplicationUserId",
                table: "Blogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BlogId",
                table: "AspNetUsers",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Blogs_BlogId",
                table: "AspNetUsers",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_ApplicationUserId",
                table: "Blogs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Blogs_BlogId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BlogId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 666, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 28, 13, 40, 12, 670, DateTimeKind.Local).AddTicks(5148));
        }
    }
}
