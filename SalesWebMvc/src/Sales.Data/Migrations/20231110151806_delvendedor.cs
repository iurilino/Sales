using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Data.Migrations
{
    /// <inheritdoc />
    public partial class delvendedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoVendas_Vendedores_VendedorId",
                table: "HistoricoVendas");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoVendas_VendedorId",
                table: "HistoricoVendas");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "HistoricoVendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VendedorId",
                table: "HistoricoVendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioBase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVendas_VendedorId",
                table: "HistoricoVendas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoVendas_Vendedores_VendedorId",
                table: "HistoricoVendas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id");
        }
    }
}
