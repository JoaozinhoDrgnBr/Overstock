using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Overstock.Migrations
{
    /// <inheritdoc />
    public partial class Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendaStatus",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompraStatus",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendaStatus",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CompraStatus",
                table: "Compras");
        }
    }
}
