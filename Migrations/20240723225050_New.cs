﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 24, 1, 50, 49, 716, DateTimeKind.Local).AddTicks(919));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 24, 1, 45, 37, 918, DateTimeKind.Local).AddTicks(8142));
        }
    }
}
