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
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(SalesContext db) : base(db) { }

        public async Task<Vendedor> ObterVendedorHistoricoVendas(Guid id)
        {
            return await Db.Vendedores
                .AsNoTracking()
                .Include(c => c.HistoricoVendas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
