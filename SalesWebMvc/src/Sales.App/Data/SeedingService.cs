using Sales.Business.Models;
using Sales.Data.Context;

namespace Sales.App.Data
{
    public class SeedingService
    {
        private SalesContext _context;

        public SeedingService(SalesContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Fornecedores.Any())
            {
                return; //DB has been seeded
            }

            Fornecedor f1 = new Fornecedor { Id = Guid.NewGuid(), Documento = "05793192530", Nome = "Iuri", Ativo = true, Tipo = 0 };

            _context.Fornecedores.AddRange(f1);


            _context.SaveChanges();
        }
    }
}
