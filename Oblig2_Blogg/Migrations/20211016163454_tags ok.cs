using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class tagsok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 656, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 661, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2021, 10, 16, 12, 40, 52, 662, DateTimeKind.Local).AddTicks(4427));
        }
    }
}
