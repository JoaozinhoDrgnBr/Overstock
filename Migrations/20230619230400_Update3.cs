using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Overstock.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "VendaProduto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendaId1",
                table: "VendaProduto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompraId1",
                table: "CompraProduto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "CompraProduto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_ProdutoId1",
                table: "VendaProduto",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_VendaId1",
                table: "VendaProduto",
                column: "VendaId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_CompraId1",
                table: "CompraProduto",
                column: "CompraId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_ProdutoId1",
                table: "CompraProduto",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProduto_Compras_CompraId1",
                table: "CompraProduto",
                column: "CompraId1",
                principalTable: "Compras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProduto_Produtos_ProdutoId1",
                table: "CompraProduto",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProduto_Produtos_ProdutoId1",
                table: "VendaProduto",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProduto_Vendas_VendaId1",
                table: "VendaProduto",
                column: "VendaId1",
                principalTable: "Vendas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraProduto_Compras_CompraId1",
                table: "CompraProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_CompraProduto_Produtos_ProdutoId1",
                table: "CompraProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaProduto_Produtos_ProdutoId1",
                table: "VendaProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaProduto_Vendas_VendaId1",
                table: "VendaProduto");

            migrationBuilder.DropIndex(
                name: "IX_VendaProduto_ProdutoId1",
                table: "VendaProduto");

            migrationBuilder.DropIndex(
                name: "IX_VendaProduto_VendaId1",
                table: "VendaProduto");

            migrationBuilder.DropIndex(
                name: "IX_CompraProduto_CompraId1",
                table: "CompraProduto");

            migrationBuilder.DropIndex(
                name: "IX_CompraProduto_ProdutoId1",
                table: "CompraProduto");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "VendaId1",
                table: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "CompraId1",
                table: "CompraProduto");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "CompraProduto");
        }
    }
}
