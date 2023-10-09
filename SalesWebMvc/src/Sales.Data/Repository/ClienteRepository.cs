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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SalesContext db) : base(db){ }

        public async Task<Cliente> ObterClienteHistoricoVendas(Guid id)
        {
            return await Db.Clientes
                .AsNoTracking()
                .Include(h => h.HistoricoVendas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
