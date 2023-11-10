using Sales.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.App.ViewModels
{
    public class VendaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Data")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorVenda { get; set; }
        public VendaStatus Status { get; set; }


        /* EF Relations */

        [DisplayName("Cliente")]
        public ClienteViewModel Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }

        public ItemVendaViewModel Item { get; set; }
        public List<ItemVendaViewModel> ItensVenda { get; set; } = new List<ItemVendaViewModel>();
        /* EF Relations */
    }
}
