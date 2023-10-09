using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IHistoricoVendaRepository : IRepository<HistoricoVenda>
    {
        Task<IEnumerable<HistoricoVenda>> ObterVendasProdutosVendedorCliente();

        Task<IEnumerable<HistoricoVenda>> ObterVendasProduto(Guid produtoId);

        Task<IEnumerable<HistoricoVenda>> ObterVendasPorVendedor(Guid vendedorId);

        Task<IEnumerable<HistoricoVenda>> ObterVendasPorCliente(Guid clienteId);
    }
}
