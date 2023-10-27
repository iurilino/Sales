using Sales.Business.Interfaces;
using Sales.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Services
{
    public class HistoricoVendaService : IHistoricoVendaService
    {
        private readonly IHistoricoVendaRepository _historicoVendaRepository;

        public HistoricoVendaService(IHistoricoVendaRepository historicoVendaRepository)
        {
            _historicoVendaRepository = historicoVendaRepository;
        }

        public async Task Adicionar(HistoricoVenda historicoVenda)
        {
            historicoVenda.DataVenda = DateTime.Now;
            historicoVenda.Status = 0;
            historicoVenda.ValorVenda = ValorTotal(historicoVenda);

            foreach (var item in historicoVenda.ItensVenda)
            {
                // Defina o estado do Produto como Detached
                item.Produto = null;
            }           

            await _historicoVendaRepository.Adicionar(historicoVenda);
        }

        public async Task Remover(Guid id)
        {
           await _historicoVendaRepository.Remover(id);
        }

        public void Dispose()
        {
            _historicoVendaRepository?.Dispose();
        }

        public decimal ValorTotal(HistoricoVenda historicoVenda)
        {
            return historicoVenda.ItensVenda.Sum(x => x.Quantidade * x.ValorUnitario);
        }
    }
}
