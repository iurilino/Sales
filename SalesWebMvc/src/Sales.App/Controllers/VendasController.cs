using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.App.Services;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Data.Repository;

namespace Sales.App.Controllers
{
    public class VendasController : Controller
    {
        private readonly IHistoricoVendaRepository _historicoVendaRepository;
        private readonly IHistoricoVendaService _historicoVendaService;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoService _carrinhoService;
        private readonly IMapper _mapper;

        public IProdutoRepository ProdutoRepository { get; }

        public VendasController(IHistoricoVendaRepository historicoVendaRepository,
                                IHistoricoVendaService historicoVendaService,                                
                                IClienteRepository clienteRepository,
                                IVendedorRepository vendedorRepository,
                                IProdutoRepository produtoRepository,
                                CarrinhoService carrinhoService,
                                IMapper mapper)
        {
            _historicoVendaRepository = historicoVendaRepository;
            _historicoVendaService = historicoVendaService;
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
            _produtoRepository = produtoRepository;
            _carrinhoService = carrinhoService;
            _mapper = mapper;            
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VendaViewModel>>(await _historicoVendaRepository.ObterVendasProdutosVendedorCliente()));
        }

        public async Task<IActionResult> Create()
        {
            var carrinho = _carrinhoService.ObterCarrinhoDaSessao();
            var vendaViewModel = await PopularVendedorCliente(new VendaViewModel());


            vendaViewModel.ItensVenda = carrinho.Itens;


            return View(vendaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaViewModel vendaViewModel)
        {
            //if (!ModelState.IsValid) return View(vendaViewModel);

            var venda = _mapper.Map<HistoricoVenda>(vendaViewModel);

            //foreach (var item in venda.ItensVenda)
            //{
            //    var produto = await _produtoRepository.ObterPorID(item.Produto.Id);

            //    _produtoRepository.Detach(produto);

            //    item.Produto = produto;                
            //}

            await _historicoVendaService.Adicionar(venda);

            return RedirectToAction("Index");
        }

        private async Task<VendaViewModel> PopularVendedorCliente(VendaViewModel venda)
        {
            venda.Vendedores = _mapper.Map<IEnumerable<VendedorViewModel>>(await _vendedorRepository.ObterTodos());
            venda.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());

            return venda;
        }
    }
}
