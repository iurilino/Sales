using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<HistoricoVenda> HistoricoVendas { get;set; }
        /* EF Relations */
    }
}
