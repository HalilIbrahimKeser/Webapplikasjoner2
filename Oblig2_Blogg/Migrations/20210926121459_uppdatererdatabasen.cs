using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class uppdatererdatabasen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogViewModel",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BlogViewModel_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BlogViewModel_OwnerId",
                table: "BlogViewModel",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogViewModel");

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
    }
}
