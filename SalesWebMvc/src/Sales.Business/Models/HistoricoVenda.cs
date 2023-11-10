using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class HistoricoVenda : Entity
    {
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        public VendaStatus Status { get; set; }


        /* EF Relations */
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public IEnumerable<ItemVenda> ItensVenda { get; set; }
        /* EF Relations */
    }
}
