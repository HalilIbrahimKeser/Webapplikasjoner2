using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class subscibedBlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 173, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 27, 19, 45, 9, 181, DateTimeKind.Local).AddTicks(2365));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 513, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6677));
        }
    }
}
