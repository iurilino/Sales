﻿using Sales.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.App.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "Entre com e-mail valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        //public IEnumerable<HistoricoVenda> HistoricoVendas { get; set; }
    }
}
