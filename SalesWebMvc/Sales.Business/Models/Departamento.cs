using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class Departamento : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<Vendedor> Vendedores { get; set; }
        /* EF Relations */
    }
}
