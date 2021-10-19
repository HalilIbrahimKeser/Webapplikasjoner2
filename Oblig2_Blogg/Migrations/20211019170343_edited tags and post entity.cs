using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class editedtagsandpostentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AspNetUsers_OwnerId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogViewModel_Blog_BlogId",
                table: "BlogViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_OwnerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_OwnerId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tag_TagId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "PostsAndTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_PostId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_TagId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_Post_OwnerId",
                table: "Posts",
                newName: "IX_Posts_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_BlogId",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OwnerId",
                table: "Comments",
                newName: "IX_Comments_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_OwnerId",
                table: "Blogs",
                newName: "IX_Blogs_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogId");

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsPostId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsPostId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 220, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 224, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 225, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 225, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2021, 10, 19, 19, 3, 43, 226, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsTagId",
                table: "PostTag",
                column: "TagsTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_OwnerId",
                table: "Blogs",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogViewModel_Blogs_BlogId",
                table: "BlogViewModel",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_OwnerId",
                table: "Comments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_OwnerId",
                table: "Posts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_OwnerId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogViewModel_Blogs_BlogId",
                table: "BlogViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_OwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_OwnerId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_OwnerId",
                table: "Post",
                newName: "IX_Post_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                table: "Post",
                newName: "IX_Post_BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comment",
                newName: "IX_Comment_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_OwnerId",
                table: "Comment",
                newName: "IX_Comment_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_OwnerId",
                table: "Blog",
                newName: "IX_Blog_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogId");

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
                    { 6, 3, 6 },
                    { 5, 3, 5 },
                    { 4, 2, 4 },
                    { 3, 2, 3 },
                    { 2, 1, 2 },
                    { 7, 1, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 484, DateTimeKind.Local).AddTicks(9070), 1 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(75), 1 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(119), 2 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(143), 2 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(165), 3 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(193), 3 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 7,
                columns: new[] { "Created", "PostId" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 15, 42, 485, DateTimeKind.Local).AddTicks(214), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_PostId",
                table: "Tag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TagId",
                table: "Post",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AspNetUsers_OwnerId",
                table: "Blog",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogViewModel_Blog_BlogId",
                table: "BlogViewModel",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_OwnerId",
                table: "Comment",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_OwnerId",
                table: "Post",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Tag_TagId",
                table: "Post",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
