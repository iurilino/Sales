using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantidadeEstoqueInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeEmEstoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "QuantidadeEmEstoque",
                table: "Produtos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
