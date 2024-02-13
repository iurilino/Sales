using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantidadeEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "QuantidadeEmEstoque",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEmEstoque",
                table: "Produtos");
        }
    }
}
