using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAPI.Infra.Migrations
{
    public partial class migrationtotalproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    cnpj = table.Column<string>(type: "NVARCHAR(14)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    manufacturingdate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    suppliercode = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.code);
                    table.ForeignKey(
                        name: "FK_product_supplier_suppliercode",
                        column: x => x.suppliercode,
                        principalTable: "supplier",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_suppliercode",
                table: "product",
                column: "suppliercode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
