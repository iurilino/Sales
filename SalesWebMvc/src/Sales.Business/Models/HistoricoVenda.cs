using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class HistoricoVenda : Entity
    {
        public DateTime Date { get; set; }
        public double Quantidade { get; set; }
        public VendaStatus Status { get; set; }


        /* EF Relations */
        public Vendedor Vendedor { get; set; }
        public Guid VendedorId { get; set; }

        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public Guid ProdutoId { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        /* EF Relations */
    }
}
