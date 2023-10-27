using Sales.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Sales.App.ViewModels
{
    public class ItemVendaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }


        /* EF Relations */
        public ProdutoViewModel Produto { get; set; }




        //public Guid ProdutoId { get; set; }
        //public Guid VendaId { get; set; }
        //public VendaViewModel Venda { get; set; }
    }
}
