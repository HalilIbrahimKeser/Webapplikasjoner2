using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class addedMoreClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostText",
                table: "Post",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostText",
                table: "Post",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
