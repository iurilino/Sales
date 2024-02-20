using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Business.Models;

namespace Sales.Data.Mappings
{
    public class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Departamento : Produto
            builder.HasMany(p => p.Produtos)
                .WithOne(x => x.Departamento)
                .HasForeignKey(x => x.DepartamentoId);
        }
    }
}
