using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class addedFKoncomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 570, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2021, 10, 25, 17, 54, 46, 574, DateTimeKind.Local).AddTicks(8090));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 460, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 464, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 464, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2021, 10, 25, 16, 41, 43, 465, DateTimeKind.Local).AddTicks(6744));
        }
    }
}
