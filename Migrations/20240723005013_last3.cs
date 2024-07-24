using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class last3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 3, 50, 13, 607, DateTimeKind.Local).AddTicks(7344));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 3, 48, 37, 939, DateTimeKind.Local).AddTicks(6370));
        }
    }
}
