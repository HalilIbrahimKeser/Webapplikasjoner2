using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class kontrollavdbførWebAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 219, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 224, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 224, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2021, 10, 21, 14, 30, 8, 225, DateTimeKind.Local).AddTicks(7613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 220, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 224, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 225, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 225, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8648));
        }
    }
}
