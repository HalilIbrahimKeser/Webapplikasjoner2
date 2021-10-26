using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class addedapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
