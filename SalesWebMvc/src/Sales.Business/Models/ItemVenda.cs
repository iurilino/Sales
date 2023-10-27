using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class ItemVenda : Entity
    {        
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }


        /* EF Relations */
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public HistoricoVenda HistoricoVenda { get; set; }
        /* EF Relations */



        //public Guid HistoricoVendaId { get; set; }
    }
}
