using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(Guid id)
        {
            if (_clienteRepository.ObterClienteHistoricoVendas(id).Result.HistoricoVendas.Any())
            {
                throw new InvalidOperationException("Não é possível remover esse cliente porque ele tem vendas associadas.");
            }

            await _clienteRepository.Remover(id);
        }
        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
