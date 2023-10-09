﻿using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        Task<Vendedor> ObterClienteHistoricoVendas(Guid id);
    }
}
