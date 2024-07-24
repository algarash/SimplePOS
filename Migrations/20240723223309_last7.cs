using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePOS.Migrations
{
    /// <inheritdoc />
    public partial class last7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inwards_Products_ProductId",
                table: "Inwards");

            migrationBuilder.DropIndex(
                name: "IX_Inwards_ProductId",
                table: "Inwards");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Inwards");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Inwards");

            migrationBuilder.CreateTable(
                name: "InwardProducts",
                columns: table => new
                {
                    InwardProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InwardId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardProducts", x => x.InwardProductId);
                    table.ForeignKey(
                        name: "FK_InwardProducts_Inwards_InwardId",
                        column: x => x.InwardId,
                        principalTable: "Inwards",
                        principalColumn: "InwardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InwardProducts",
                columns: new[] { "InwardProductId", "InwardId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 100 });

            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 24, 1, 33, 9, 589, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.CreateIndex(
                name: "IX_InwardProducts_InwardId",
                table: "InwardProducts",
                column: "InwardId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardProducts_ProductId",
                table: "InwardProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InwardProducts");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Inwards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Inwards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inwards",
                keyColumn: "InwardId",
                keyValue: 1,
                columns: new[] { "Date", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 7, 23, 17, 51, 51, 224, DateTimeKind.Local).AddTicks(304), 1, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_ProductId",
                table: "Inwards",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inwards_Products_ProductId",
                table: "Inwards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
