using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Business.Models.Validations;

namespace Sales.Business.Services
{
    public class DepartamentoService : BaseService, IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository,
                                   INotificador notificador) : base(notificador)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task Adicionar(Departamento departamento)
        {
            if (!ExecutarValidacao(new DepartamentoValidation(), departamento)) return;

            if (_departamentoRepository.Buscar(d => d.Nome == departamento.Nome).Result.Any())
            {
                Notificar("Já existe departamento com este nome");
                return;
            }

            await _departamentoRepository.Adicionar(departamento);
        }

        public async Task Atualizar(Departamento departamento)
        {
            if (!ExecutarValidacao(new DepartamentoValidation(), departamento)) return;

            if (_departamentoRepository.Buscar(d => d.Nome == departamento.Nome && d.Id != departamento.Id).Result.Any())
            {
                Notificar("Já existe departamento com este nome");
                return;
            }

            await _departamentoRepository.Atualizar(departamento);
        }

        public async Task Remover(Guid id)
        {
            if (_departamentoRepository.ObterDepartamentoProdutos(id).Result.Produtos.Any())
            {
               Notificar("Não é possível remover o departamento porque ele tem produtos associados.");
                return;
            }

            await _departamentoRepository.Remover(id);
        }
        public void Dispose()
        {
            _departamentoRepository?.Dispose();
        }
    }
}
