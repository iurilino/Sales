using Sales.Business.Interfaces;
using Sales.Business.Models;
using Sales.Business.Models.Validations;

namespace Sales.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if(_clienteRepository.Buscar(c => c.Documento == cliente.Documento).Result.Any())
            {
                Notificar("Já existe cliente com este documento informado!");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento && c.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe cliente com este documento informado!");
                return;
            }

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(Guid id)
        {
            if (_clienteRepository.ObterClienteHistoricoVendas(id).Result.HistoricoVendas.Any())
            {
                Notificar("Não é possível remover esse cliente porque ele tem vendas associadas!");
                return;
            }

            await _clienteRepository.Remover(id);
        }
        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
