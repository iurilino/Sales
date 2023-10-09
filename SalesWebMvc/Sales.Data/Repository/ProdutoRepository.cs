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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SalesContext db) : base(db) { }

        public async Task<Produto> ObterProdutoFornecedorDepartamento(Guid id)
        {
            return await Db.Produtos
                .AsNoTracking()
                .Include(f => f.Fornecedor)
                .Include(d => d.Departamento)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedoresDepartamento()
        {
            return await Db.Produtos
                .AsNoTracking()
                .Include(f => f.Fornecedor)
                .Include(d => d.Departamento)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorDepartamento(Guid departamentoId)
        {
            return await Buscar(p => p.DepartamentoId == departamentoId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
