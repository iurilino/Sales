using Microsoft.EntityFrameworkCore;
using Sales.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sales.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : N => Fornecedor : Produto
            builder.HasMany(p => p.Produtos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);
        }
    }
}
