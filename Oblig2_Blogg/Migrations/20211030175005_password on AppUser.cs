using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class passwordonAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 518, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 30, 19, 50, 4, 521, DateTimeKind.Local).AddTicks(7898));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

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
        }
    }
}
