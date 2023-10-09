using Microsoft.EntityFrameworkCore;
using Sales.Business.Models;
using System.Linq;

namespace Sales.Data.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions options) : base(options){ }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<HistoricoVenda> HistoricoVendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
