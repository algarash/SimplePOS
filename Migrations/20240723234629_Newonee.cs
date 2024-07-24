using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class Newonee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 24, 2, 46, 28, 604, DateTimeKind.Local).AddTicks(7564));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 24, 2, 20, 41, 539, DateTimeKind.Local).AddTicks(1012));
        }
    }
}
