using Microsoft.EntityFrameworkCore;
using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Data.Context;

namespace Sales.Data.Repository
{
    public class HistoricoVendaRepository : Repository<HistoricoVenda>, IHistoricoVendaRepository
    {
        public HistoricoVendaRepository(SalesContext db) : base(db) { }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasPorCliente(Guid clienteId)
        {
            return await Buscar(h => h.ClienteId == clienteId);
        }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasProdutosVendedorCliente()
        {
            return await Db.HistoricoVendas
                .AsNoTracking()
                .Include(c => c.Cliente)
                .Include(i => i.ItensVenda)
                    .ThenInclude(item => item.Produto)
                .OrderBy(h => h.DataVenda)
                .ToListAsync();
        }
    }
}
