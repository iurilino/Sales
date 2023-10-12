using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto produto)
        {
           await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            if (_produtoRepository.ObterProdutoHistoricoVendas(id).Result.ItemVendas.Any())
            {
                throw new InvalidOperationException("Não é possível remover esse produto porque ele tem vendas associadas.");
            }

            await _produtoRepository.Remover(id);   
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
