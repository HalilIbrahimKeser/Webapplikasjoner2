using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class postandtagstabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 685, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 688, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 688, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 688, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 16, 20, 27, 8, 689, DateTimeKind.Local).AddTicks(5273));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 650, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 653, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 653, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 653, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 16, 18, 34, 53, 654, DateTimeKind.Local).AddTicks(4777));
        }
    }
}
