using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.Business.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task Adicionar(Departamento departamento)
        {
            await _departamentoRepository.Adicionar(departamento);
        }

        public async Task Atualizar(Departamento departamento)
        {
            await _departamentoRepository.Atualizar(departamento);
        }

        public async Task Remover(Guid id)
        {
            if (_departamentoRepository.ObterDepartamentoProdutos(id).Result.Produtos.Any())
            {
                throw new InvalidOperationException("Não é possível remover o departamento porque ele tem produtos associados.");
            }

            await _departamentoRepository.Remover(id);
        }
        public void Dispose()
        {
            _departamentoRepository?.Dispose();
        }
    }
}
