using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public int QuantidadeEmEstoque {  get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Departamento Departamento { get; set; }
        public Guid DepartamentoId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Guid FornecedorId { get; set; }
        public IEnumerable<ItemVenda> ItemVendas { get; set; }
        /* EF Relations */
    }
}
