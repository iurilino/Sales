using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemodelandoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_HistoricoVendas_HistoricoVendaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_HistoricoVendaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "HistoricoVendaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "HistoricoVendas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "HistoricoVendas");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Vendedores",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "BaseSalary",
                table: "Vendedores",
                newName: "SalarioBase");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "HistoricoVendas",
                newName: "DataVenda");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorVenda",
                table: "HistoricoVendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricoVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_HistoricoVendas_HistoricoVendaId",
                        column: x => x.HistoricoVendaId,
                        principalTable: "HistoricoVendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_HistoricoVendaId",
                table: "ItemVenda",
                column: "HistoricoVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "HistoricoVendas");

            migrationBuilder.RenameColumn(
                name: "SalarioBase",
                table: "Vendedores",
                newName: "BaseSalary");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Vendedores",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "HistoricoVendas",
                newName: "Date");

            migrationBuilder.AddColumn<Guid>(
                name: "HistoricoVendaId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "HistoricoVendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "HistoricoVendas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_HistoricoVendaId",
                table: "Produtos",
                column: "HistoricoVendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_HistoricoVendas_HistoricoVendaId",
                table: "Produtos",
                column: "HistoricoVendaId",
                principalTable: "HistoricoVendas",
                principalColumn: "Id");
        }
    }
}
