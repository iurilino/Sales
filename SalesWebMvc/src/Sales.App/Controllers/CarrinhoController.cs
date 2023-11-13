using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.App.Services;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.App.Controllers
{
    public class CarrinhoController : Controller
    {

        private readonly CarrinhoService _carrinhoService;
        private readonly IMapper _mapper;

        public CarrinhoController(CarrinhoService carrinhoService,
                                  IMapper mapper)
        {
            _carrinhoService = carrinhoService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {           
            var carrinho = _carrinhoService.ObterCarrinhoDaSessao();

            ViewBag.Valor = _carrinhoService.ValorTotal();            

            return View(carrinho);
        }

        [HttpPost]
        public IActionResult AdicionarAoCarrinho(ProdutoViewModel produto, int quantidade)
        {
            if (quantidade <= 0)
            {
                TempData["ErrorMessage"] = "A quantidade deve ser maior que zero.";
                return RedirectToAction("Details", "Produtos",new { id = produto.Id });
            }

            _carrinhoService.AdicionarItemAoCarrinho(produto, quantidade);
            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Remover(Guid id)
        {
            _carrinhoService.RemoverItemDoCarrinho(id);

            return RedirectToAction("Index");
        }

        public IActionResult ConcluirCompra()
        {
            var carrinho = _carrinhoService.ObterCarrinhoDaSessao();

            if(carrinho.Itens.IsNullOrEmpty())
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Vendas");
        }

        [HttpPost]
        public IActionResult AtualizarQuantidade(Guid produtoId, int novaQuantidade)
        {
            if (novaQuantidade <= 0)
            {
                return Json(new { success = false, message = "Quantidade não pode ser menor do que 0!" });
            }
            _carrinhoService.AtualizarQuantidade(produtoId, novaQuantidade);

            var url = Url.Action("Index", "Carrinho");

            return Json(new { success = true, url, message = "Quantidade atualizada com sucesso!" });
        }
    }
}
