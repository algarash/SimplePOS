using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class last5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inwards");

            migrationBuilder.DropTable(
                name: "Outwards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inwards",
                columns: table => new
                {
                    InwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Outwards",
                columns: table => new
                {
                    OutwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outwards", x => x.OutwardId);
                    table.ForeignKey(
                        name: "FK_Outwards_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outwards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inwards",
                columns: new[] { "InwardId", "Date", "ProductId", "Quantity", "SupplierId" },
                values: new object[] { 1, new DateTime(2024, 7, 23, 17, 25, 46, 589, DateTimeKind.Local).AddTicks(7668), 1, 100, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_ProductId",
                table: "Inwards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_SupplierId",
                table: "Inwards",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Outwards_OrderId",
                table: "Outwards",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Outwards_ProductId",
                table: "Outwards",
                column: "ProductId");
        }
    }
}
