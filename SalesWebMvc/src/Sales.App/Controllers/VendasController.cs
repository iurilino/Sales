using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.App.Services;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Data.Repository;

namespace Sales.App.Controllers
{
    public class VendasController : BaseController
    {
        private readonly IHistoricoVendaRepository _historicoVendaRepository;
        private readonly IHistoricoVendaService _historicoVendaService;
        private readonly IClienteRepository _clienteRepository;
        private readonly CarrinhoService _carrinhoService;
        private readonly IMapper _mapper;

        public IProdutoRepository ProdutoRepository { get; }

        public VendasController(IHistoricoVendaRepository historicoVendaRepository,
                                IHistoricoVendaService historicoVendaService,                                
                                IClienteRepository clienteRepository,
                                IProdutoRepository produtoRepository,
                                CarrinhoService carrinhoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _historicoVendaRepository = historicoVendaRepository;
            _historicoVendaService = historicoVendaService;
            _clienteRepository = clienteRepository;
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
            var vendaViewModel = await PopularCliente(new VendaViewModel());


            vendaViewModel.ItensVenda = carrinho.Itens;


            return View(vendaViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaViewModel vendaViewModel)
        {
            vendaViewModel = await PopularCliente(vendaViewModel);

            for (int i = 0; i < vendaViewModel.ItensVenda.Count; i++)
            {
                ModelState.Remove($"ItensVenda[{i}].Produto.Descricao");
            }

            if (!ModelState.IsValid) return View(vendaViewModel);            

            var venda = _mapper.Map<HistoricoVenda>(vendaViewModel);

            await _historicoVendaService.Adicionar(venda);

            if (!OperacaoValida()) return View(vendaViewModel);           

            _carrinhoService.LimparCarrinho();

            return RedirectToAction("Index");
        }

        private async Task<VendaViewModel> PopularCliente(VendaViewModel venda)
        {
            venda.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());

            return venda;
        }
    }
}
