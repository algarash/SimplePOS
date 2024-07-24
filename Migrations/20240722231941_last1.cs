using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class last1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "ContactInfo", "Name" },
                values: new object[] { 1, "123 Supplier St", "123-456-7890", "Supplier A" });

            migrationBuilder.InsertData(
                table: "Inwards",
                columns: new[] { "InwardId", "Date", "ProductId", "Quantity", "SupplierId" },
                values: new object[] { 1, new DateTime(2024, 7, 23, 2, 19, 40, 890, DateTimeKind.Local).AddTicks(9687), 1, 100, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);
        }
    }
}
