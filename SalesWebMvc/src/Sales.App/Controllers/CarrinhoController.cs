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
    }
}
