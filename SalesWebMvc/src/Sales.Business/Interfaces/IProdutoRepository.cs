using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterProdutoFornecedorDepartamento(Guid id);

        Task<Produto> ObterProdutoHistoricoVendas(Guid id);

        Task<IEnumerable<Produto>> ObterProdutosFornecedoresDepartamento();
        

        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);


        Task<IEnumerable<Produto>> ObterProdutosPorDepartamento(Guid departamentoId);
    }
}
