using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Interfaces
{
    public interface IDepartamentoService : IDisposable
    {
        Task Adicionar(Departamento departamento);
        Task Atualizar(Departamento departamento);
        Task Remover(Guid id);
    }
}
