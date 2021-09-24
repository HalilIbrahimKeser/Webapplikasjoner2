using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class problemmedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 864, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 870, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 870, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 870, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 24, 16, 14, 56, 869, DateTimeKind.Local).AddTicks(8061));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 391, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 396, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 396, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 396, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 23, 18, 29, 58, 395, DateTimeKind.Local).AddTicks(8218));
        }
    }
}
