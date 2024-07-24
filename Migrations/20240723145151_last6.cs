using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class last6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inwards",
                columns: table => new
                {
                    InwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inwards", x => x.InwardId);
                    table.ForeignKey(
                        name: "FK_Inwards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inwards_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inwards",
                columns: new[] { "InwardId", "Date", "ProductId", "Quantity", "SupplierId" },
                values: new object[] { 1, new DateTime(2024, 7, 23, 17, 51, 51, 224, DateTimeKind.Local).AddTicks(304), 1, 100, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_ProductId",
                table: "Inwards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_SupplierId",
                table: "Inwards",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inwards");
        }
    }
}
