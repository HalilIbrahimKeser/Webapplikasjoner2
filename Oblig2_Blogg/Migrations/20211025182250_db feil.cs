using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class dbfeil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 513, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Created", "Modified", "OwnerId", "PostText" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(5771), null, null, "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide" },
                    { 2, 1, new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6613), null, null, "Melbourne på vei til Adelaide var et kjempefint sted" },
                    { 3, 2, new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6654), null, null, "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig" },
                    { 4, 3, new DateTime(2021, 10, 25, 20, 22, 49, 516, DateTimeKind.Local).AddTicks(6677), null, null, "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 603, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 12, 10, 606, DateTimeKind.Local).AddTicks(6009));
        }
    }
}
