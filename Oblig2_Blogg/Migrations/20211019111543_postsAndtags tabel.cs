using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class postsAndtagstabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostsAndTags",
                columns: table => new
                {
                    PostsAndTagsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsAndTags", x => x.PostsAndTagsId);
                });

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 479, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.InsertData(
                table: "PostsAndTags",
                columns: new[] { "PostsAndTagsId", "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 7, 1, 7 },
                    { 6, 3, 6 },
                    { 5, 3, 5 },
                    { 4, 2, 4 },
                    { 3, 2, 3 },
                    { 2, 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "Created", "Modified", "PostId", "TagLabel" },
                values: new object[] { 7, new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(214), null, 1, "Gåtur" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsAndTags");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 7);

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
    }
}
