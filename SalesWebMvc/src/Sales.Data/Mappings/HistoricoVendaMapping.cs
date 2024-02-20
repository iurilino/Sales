using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Business.Models;

namespace Sales.Data.Mappings
{
    public class HistoricoVendaMapping : IEntityTypeConfiguration<HistoricoVenda>
    {
        public void Configure(EntityTypeBuilder<HistoricoVenda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataVenda)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.ValorVenda)
                .IsRequired()
                .HasColumnType("decimal");

            // 1 : N => HistoricoVenda : ItensVenda
            builder.HasMany(i => i.ItensVenda)
                .WithOne(x => x.HistoricoVenda)
                .HasForeignKey(x => x.HistoricoVendaId);
        }
    }
}
