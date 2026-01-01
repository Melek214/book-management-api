using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(5490), new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(5710), new DateTime(2025, 12, 12, 21, 20, 48, 717, DateTimeKind.Utc).AddTicks(5720) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(5730), new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(5730) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(5950), new DateTime(2025, 12, 12, 21, 16, 36, 116, DateTimeKind.Utc).AddTicks(5950) });
        }
    }
}
