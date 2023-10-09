using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class Fonecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoDocumento Tipo { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations*/
        public IEnumerable<Produto> Produtos { get; set; }
        /* EF Relations*/
    }
}
