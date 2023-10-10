using Sales.Business.Interfaces;
using Sales.Business.Models;

namespace Sales.Business.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public Task Atualizar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }

        public Task Remover(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
