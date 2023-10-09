using Microsoft.EntityFrameworkCore;
using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Repository
{
    public class HistoricoVendaRepository : Repository<HistoricoVenda>, IHistoricoVendaRepository
    {
        public HistoricoVendaRepository(SalesContext db) : base(db) { }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasPorCliente(Guid clienteId)
        {
            return await Buscar(h => h.ClienteId == clienteId);
        }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasPorVendedor(Guid vendedorId)
        {
            return await Buscar(h => h.VendedorId == vendedorId);
        }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasProduto(Guid produtoId)
        {
            return await Buscar(h => h.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<HistoricoVenda>> ObterVendasProdutosVendedorCliente()
        {
            return await Db.HistoricoVendas
                .AsNoTracking()
                .Include(c => c.ClienteId)
                .Include(v => v.VendedorId)
                .Include(p => p.ProdutoId)
                .OrderBy(h => h.Date)
                .ToListAsync();
        }
    }
}
