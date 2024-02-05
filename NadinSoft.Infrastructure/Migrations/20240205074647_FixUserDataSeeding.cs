using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NadinSoft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "c0768c84-5a6c-481e-883c-cc50acbe73e3", "Hamid", "hamidpishbin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELcRXxc1pEZKY7nY1D1ojPNXHm9ru8nYJ05pvVZJnpOb0gozsYS1ysgOUt3URAeGUw==", null, false, null, false, "hamidpishbin" },
                    { 2, 0, "b728c074-69f7-4f73-8989-29f3c1e05765", "Hanie", "haniepishbin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJSSYaSds/kDBzX8pr62mWpA/z/4L+wn21ecbvwwAARHhR1IIoiBrSMmw/UOODcORA==", null, false, null, false, "haniepishbin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
