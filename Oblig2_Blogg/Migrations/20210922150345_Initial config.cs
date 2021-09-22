using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class Initialconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blog_IdentityUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_IdentityUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_IdentityUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "BlogId", "Closed", "Created", "Description", "Modified", "Name", "OwnerId" },
                values: new object[] { 1, false, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fortelling av turopplevelser", null, "Tur til Australia", null });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "BlogId", "Closed", "Created", "Description", "Modified", "Name", "OwnerId" },
                values: new object[] { 2, false, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Møtet med Taliban", null, "Tur til Afganistan", null });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "BlogId", "Closed", "Created", "Description", "Modified", "Name", "OwnerId" },
                values: new object[] { 3, false, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barna likte båttur", null, "Tur til Thailand", null });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "BlogId", "Created", "Modified", "OwnerId", "PostText" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide" },
                    { 2, 1, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Melbourne på vei til Adelaide var et kjempefint sted" },
                    { 3, 2, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig" },
                    { 4, 3, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentText", "Created", "Modified", "OwnerId", "PostId" },
                values: new object[,]
                {
                    { 1, "Så heldige dere er :)", new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 2, "Dere må innom den store parken i byen", new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 3, "Hvem er Taliban??", new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 4, "Husk å ikke gi mat til apene..)", new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_OwnerId",
                table: "Blog",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OwnerId",
                table: "Comment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId",
                table: "Post",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_OwnerId",
                table: "Post",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
