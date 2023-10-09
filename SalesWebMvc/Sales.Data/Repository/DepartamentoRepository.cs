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
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(SalesContext db) : base(db) { }

        public Task<Departamento> ObterDepartamentoProdutos(Guid id)
        {
            return Db.Departamentos
                .AsNoTracking()
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(d => d.Id == id);                
        }
    }
}
