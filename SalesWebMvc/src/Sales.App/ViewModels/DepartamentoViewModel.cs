using Sales.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.App.ViewModels
{
    public class DepartamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        /* EF Relations */
    }
}
