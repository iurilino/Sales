using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.App.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,                                  
                                  IDepartamentoRepository departamentoRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;            
            _departamentoRepository = departamentoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>> (await _produtoRepository.ObterProdutosFornecedoresDepartamento()));
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        public async Task<ActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedorDepartamento(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedorDepartamento(produtoViewModel);
            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizado = await ObterProduto(id);
            produtoViewModel.Fornecedor = produtoAtualizado.Fornecedor;
            produtoViewModel.Departamento = produtoAtualizado.Departamento;


            produtoAtualizado.Nome = produtoViewModel.Nome;
            produtoAtualizado.Descricao = produtoViewModel.Descricao;
            produtoAtualizado.Valor = produtoViewModel.Valor;
            produtoAtualizado.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizado));

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, ProdutoViewModel produtoViewModel)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _produtoService.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedorDepartamento(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            produto.Departamentos = _mapper.Map<IEnumerable<DepartamentoViewModel>>(await _departamentoRepository.ObterTodos());

            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedorDepartamento(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            produto.Departamentos = _mapper.Map<IEnumerable<DepartamentoViewModel>>(await _departamentoRepository.ObterTodos());

            return produto;
        }
    }
}
