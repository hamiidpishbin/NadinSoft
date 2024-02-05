using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NadinSoft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UncommentProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aaa41cfb-0a43-4811-a1fd-bba978dee77b", "AQAAAAIAAYagAAAAEFPzZiVMEVPsxXFFenn8+M49r7k81ftA2+4gjWojFK8BLheSEDv1cqWXcp35v9SZ9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8ea800a-4fb8-47b5-b3f3-af3f00741581", "AQAAAAIAAYagAAAAENsUSzIZPCeR7kw9aslyLJEZypqbhGn/aQqD6H9H8Fh+oPm/RZI2hMQCBUxWFFfGKA==" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0768c84-5a6c-481e-883c-cc50acbe73e3", "AQAAAAIAAYagAAAAELcRXxc1pEZKY7nY1D1ojPNXHm9ru8nYJ05pvVZJnpOb0gozsYS1ysgOUt3URAeGUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b728c074-69f7-4f73-8989-29f3c1e05765", "AQAAAAIAAYagAAAAEJSSYaSds/kDBzX8pr62mWpA/z/4L+wn21ecbvwwAARHhR1IIoiBrSMmw/UOODcORA==" });
        }
    }
}
