using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.App.Controllers
{
    public class DepartamentosController : BaseController
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IDepartamentoService _departamentoService;
        private readonly IMapper _mapper;

        public DepartamentosController(IDepartamentoRepository departamentoRepository,
                                    IDepartamentoService departamentoService,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _departamentoRepository = departamentoRepository;
            _departamentoService = departamentoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<DepartamentoViewModel>> (await _departamentoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var departamentoViewModel = await ObterDepartamentoProdutos(id);
            if (departamentoViewModel == null)
            {
                return NotFound();
            }

            return View(departamentoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartamentoViewModel departamentoViewModel)
        {
            if (!ModelState.IsValid) return View(departamentoViewModel);

            var departamento = _mapper.Map<Departamento>(departamentoViewModel);
            await _departamentoService.Adicionar(departamento);

            if (!OperacaoValida()) return View(departamentoViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var departamentoViewModel = await ObterDepartamentoProdutos(id);

            if (departamentoViewModel == null)
            {
                return NotFound();
            }

            return View(departamentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DepartamentoViewModel departamentoViewModel)
        {
            if (id != departamentoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(departamentoViewModel);

            var departamento = _mapper.Map<Departamento>(departamentoViewModel);
            await _departamentoService.Atualizar(departamento);

            if (!OperacaoValida()) return View(await ObterDepartamentoProdutos(id));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var departamentoViewModel = await ObterDepartamentoProdutos(id);

            if (departamentoViewModel == null)
            {
                return NotFound();
            }

            return View(departamentoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var departamentoViewModel = await ObterDepartamentoProdutos(id);

            if (departamentoViewModel == null) return NotFound();

            await _departamentoService.Remover(id);

            if (!OperacaoValida()) return View(departamentoViewModel);

            return RedirectToAction("Index");
        }

        private async Task<DepartamentoViewModel> ObterDepartamentoProdutos(Guid id)
        {
            return _mapper.Map<DepartamentoViewModel>(await _departamentoRepository.ObterDepartamentoProdutos(id));
        }
    }
}
