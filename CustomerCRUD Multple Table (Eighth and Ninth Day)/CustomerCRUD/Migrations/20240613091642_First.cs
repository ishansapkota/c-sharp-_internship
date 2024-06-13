using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCRUD.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsID = table.Column<int>(type: "int", nullable: false),
                    GoodsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    GoodsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGoods_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGoods_Goods_GoodsID",
                        column: x => x.GoodsID,
                        principalTable: "Goods",
                        principalColumn: "GoodsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGoods_CustomerID",
                table: "CustomerGoods",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGoods_GoodsID",
                table: "CustomerGoods",
                column: "GoodsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGoods");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
