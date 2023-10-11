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
    public class ItemVendaRepository : Repository<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(SalesContext db) : base(db) { }

        public async Task<IEnumerable<ItemVenda>> ObterVendasProduto(Guid produtoId)
        {
            return await Buscar(i => i.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<ItemVenda>> ObterVendasProdutos()
        {
            return await Db.ItemVenda
                .AsNoTracking()
                .Include(p => p.Produto)
                .ToListAsync();
        }
    }
}
