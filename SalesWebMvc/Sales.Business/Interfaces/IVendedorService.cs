using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IVendedorService : IDisposable
    {
        Task Adicionar(Vendedor vendedor);
        Task Atualizar(Vendedor vendedor);
        Task Remover(Vendedor vendedor);
    }
}
