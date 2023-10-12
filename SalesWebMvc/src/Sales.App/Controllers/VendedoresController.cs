using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.App.ViewModels;
using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.App.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IVendedorService _vendedorService;
        private readonly IMapper _mapper;

        public VendedoresController(IVendedorRepository vendedorRepository,
                                 IVendedorService vendedorService,
                                 IMapper mapper)
        {
            _vendedorRepository = vendedorRepository;
            _vendedorService = vendedorService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VendedorViewModel>> (await _vendedorRepository.ObterTodos()));
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var vendedorViewModel = _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterPorID(id));
            if (vendedorViewModel == null)
            {
                return NotFound();
            }

            return View(vendedorViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid) return View(vendedorViewModel);

            var vendedor = _mapper.Map<Vendedor>(vendedorViewModel);
            await _vendedorService.Adicionar(vendedor);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var vendedorViewModel = _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterPorID(id));

            if (vendedorViewModel == null)
            {
                return NotFound();
            }

            return View(vendedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, VendedorViewModel vendedorViewModel)
        {
            if (id != vendedorViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(vendedorViewModel);

            var vendedor = _mapper.Map<Vendedor>(vendedorViewModel);
            await _vendedorService.Atualizar(vendedor);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var vendedorViewModel = _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterPorID(id));

            if (vendedorViewModel == null)
            {
                return NotFound();
            }

            return View(vendedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, VendedorViewModel vendedorViewModel)
        {
            if (vendedorViewModel == null) return NotFound();

            await _vendedorService.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<VendedorViewModel> ObterVendedorHistoricoVendas(Guid id)
        {
            return _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterVendedorHistoricoVendas(id));
        }
    }
}
