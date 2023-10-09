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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SalesContext context) : base(context){ }

        public async Task<Fornecedor> ObterFornecedorProdutos(Guid id)
        {
            return await Db.Fornecedores
                .AsNoTracking()
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
