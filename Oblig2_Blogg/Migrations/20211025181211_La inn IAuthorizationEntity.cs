using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oblig2_Blogg.Migrations
{
    public partial class LainnIAuthorizationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 7);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 828, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 831, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 831, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Created", "Modified", "OwnerId", "PostText" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 25, 20, 4, 19, 831, DateTimeKind.Local).AddTicks(9764), null, null, "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide" },
                    { 4, 3, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(724), null, null, "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat" },
                    { 3, 2, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(701), null, null, "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig" },
                    { 2, 1, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(661), null, null, "Melbourne på vei til Adelaide var et kjempefint sted" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Created", "Modified", "TagLabel" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4298), null, "Ørken" },
                    { 6, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4354), null, "Sykling" },
                    { 7, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4370), null, "Gåtur" },
                    { 2, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4263), null, "Fjell" },
                    { 1, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(3753), null, "Natur" },
                    { 4, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4316), null, "Farlig" },
                    { 5, new DateTime(2021, 10, 25, 20, 4, 19, 832, DateTimeKind.Local).AddTicks(4333), null, "Løping" }
                });
        }
    }
}
