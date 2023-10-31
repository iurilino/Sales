using Newtonsoft.Json;
using Sales.App.ViewModels;
using Sales.Business.Models;

namespace Sales.App.Services
{
    public class CarrinhoService
    {
        private const string CarrinhoSessionKey = "Carrinho";

        private IHttpContextAccessor _httpContextAccessor;

        public CarrinhoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AdicionarItemAoCarrinho(ProdutoViewModel produto, int quantidade)
        {
            var carrinho = ObterCarrinhoDaSessao();

            // Verifique se o produto já existe no carrinho
            var itemExistente = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produto.Id);

            if (itemExistente != null)
            {
                // Se existir, atualize a quantidade
                itemExistente.Quantidade += quantidade;
            }
            else
            {
                // Caso contrário, adicione o item ao carrinho
                carrinho.Itens.Add(new ItemVendaViewModel { Produto = produto, Quantidade = quantidade, ValorUnitario = produto.Valor });
            }

            AtualizarCarrinhoNaSessao(carrinho);
        }

        public void RemoverItemDoCarrinho(Guid produtoId)
        {
            var carrinho = ObterCarrinhoDaSessao();
            var itemExistente = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (itemExistente != null)
            {
                // Remova o item do carrinho
                carrinho.Itens.Remove(itemExistente);
                AtualizarCarrinhoNaSessao(carrinho);
            }
        }

        public void LimparCarrinho()
        {
            var carrinho = ObterCarrinhoDaSessao();

            if (carrinho.Itens != null)
            {
                carrinho.Itens.Clear();
                AtualizarCarrinhoNaSessao(carrinho);
            }
        }

        public CarrinhoViewModel ObterCarrinhoDaSessao()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var carrinhoJson = session.GetString(CarrinhoSessionKey);
            if (carrinhoJson != null)
            {
                return JsonConvert.DeserializeObject<CarrinhoViewModel>(carrinhoJson);
            }

            var novoCarrinho = new CarrinhoViewModel();
            AtualizarCarrinhoNaSessao(novoCarrinho);
            return novoCarrinho;
        }

        public void AtualizarCarrinhoNaSessao(CarrinhoViewModel carrinho)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var carrinhoJson = JsonConvert.SerializeObject(carrinho);
            session.SetString(CarrinhoSessionKey, carrinhoJson);
        }

        public decimal ValorTotal()
        {
            var carrinho = ObterCarrinhoDaSessao();

            return carrinho.Itens.Sum(i => i.Quantidade * i.Produto.Valor);
        }
    }

}
