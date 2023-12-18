using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Business.Models.Validations;

namespace Sales.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto produto)
        {
           if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

           await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            if (_produtoRepository.ObterProdutoHistoricoVendas(id).Result.ItemVendas.Any())
            {
                Notificar("Não é possível remover esse produto porque ele tem vendas associadas.");
            }

            await _produtoRepository.Remover(id);   
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
