using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IItemVendaRepository : IRepository<ItemVenda>
    {
        Task<IEnumerable<ItemVenda>> ObterVendasProdutos();

        Task<IEnumerable<ItemVenda>> ObterVendasProduto(Guid produtoId);
    }
}
