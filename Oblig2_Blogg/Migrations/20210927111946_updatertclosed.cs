using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class updatertclosed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "BlogViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "Blog",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 807, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 27, 13, 19, 45, 811, DateTimeKind.Local).AddTicks(5632));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "BlogViewModel",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "Blog",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 147, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 150, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 150, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 9, 26, 14, 14, 59, 151, DateTimeKind.Local).AddTicks(2094));
        }
    }
}
