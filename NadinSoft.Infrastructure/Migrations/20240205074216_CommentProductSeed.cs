using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NadinSoft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommentProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsAvailable", "ManufactureEmail", "ManufacturePhone", "Name", "ProductDate", "UserId" },
                values: new object[,]
                {
                    { 1, true, "product1email@gmail.com", "09110111111", "Product 1", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, true, "product2email@gmail.com", "09120121212", "Product 2", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, true, "product3email@gmail.com", "09130131313", "Product 3", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 4, true, "product4email@gmail.com", "09140141414", "Product 4", new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 2 }
                });
        }
    }
}
