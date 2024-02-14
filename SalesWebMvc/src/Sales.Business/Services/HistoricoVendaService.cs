using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Business.Models.Validations;

namespace Sales.Business.Services
{
    public class HistoricoVendaService : BaseService,IHistoricoVendaService
    {
        private readonly IHistoricoVendaRepository _historicoVendaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public HistoricoVendaService(IHistoricoVendaRepository historicoVendaRepository
                                     ,IProdutoRepository produtoRepository
                                     ,INotificador notificador) : base(notificador)
        {
            _historicoVendaRepository = historicoVendaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(HistoricoVenda historicoVenda)
        {
            historicoVenda.DataVenda = DateTime.Now;
            historicoVenda.Status = 0;
            historicoVenda.ValorVenda = ValorTotal(historicoVenda);

            foreach (var entidade in historicoVenda.ItensVenda)
            {
                if (!ExecutarValidacao(new ItemVendaValidation(), entidade)) return;
                
                if (entidade.Quantidade > entidade.Produto.QuantidadeEmEstoque)
                {
                    Notificar("Quantidade indisponivel em estoque!");
                    return;
                }

                await AtualizarProduto(entidade.Produto.Id, entidade.Quantidade);
            }

            foreach (var entidade in historicoVenda.ItensVenda)
            {
                // Defina o estado do Produto como Detached
                entidade.Produto = null;
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

        public async Task AtualizarProduto(Guid id, int quantidade)
        {
            Produto produto = await _produtoRepository.ObterPorID(id);

            produto.QuantidadeEmEstoque -= quantidade;

            await _produtoRepository.Atualizar(produto);
        }
    }
}
