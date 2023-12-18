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

            Fornecedor f1 = new Fornecedor { Id = Guid.NewGuid(), Documento = "05793192530", Nome = "Iuri", Ativo = true, Tipo = Tipo.PessoaFisica };
            Fornecedor f2 = new Fornecedor { Id = Guid.NewGuid(), Documento = "99798479", Nome = "Igor", Ativo = true, Tipo = Tipo.PessoaFisica };

            Departamento d1 = new Departamento { Id = Guid.NewGuid(), Ativo = true, Nome = "Livros" };
            Departamento d2 = new Departamento { Id = Guid.NewGuid(), Ativo = true, Nome = "Computadores" };
            Departamento d3 = new Departamento { Id = Guid.NewGuid(), Ativo = true, Nome = "Ferramentas" };

            Cliente c1 = new Cliente { Id = Guid.NewGuid(), Ativo = true, Nome = "Superman", Email = "superman@gmail.com", Documento = "654321", Tipo = Tipo.PessoaFisica };
            Cliente c2 = new Cliente { Id = Guid.NewGuid(), Ativo = true, Nome = "Batman", Email = "batman@gmail.com", Documento = "654321", Tipo = Tipo.PessoaFisica };

            Produto p1 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Nome do Vento",
                Descricao = "Livro Foda",
                Valor = 35,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f1,
                Departamento = d1
            };
            Produto p2 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "PC Streamer",
                Descricao = "PC para streamar",
                Valor = 15000,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f1,
                Departamento = d2
            };
            Produto p3 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Chave de Fenda",
                Descricao = "Chave de fenda",
                Valor = 15,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f1,
                Departamento = d3
            };
            Produto p4 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Harry Potter",
                Descricao = "Saga do bruxo",
                Valor = 55,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f2,
                Departamento = d1
            };
            Produto p5 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "PC Gamer",
                Descricao = "PC para gamers",
                Valor = 5000,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f2,
                Departamento = d2
            };
            Produto p6 = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Martelo",
                Descricao = "Martelo",
                Valor = 10,
                Imagem = "AS",
                Ativo = true,
                DataCadastro = DateTime.Now,
                Fornecedor = f2,
                Departamento = d3
            };

            HistoricoVenda h1 = new HistoricoVenda
            {
                Id = Guid.NewGuid(),
                DataVenda = DateTime.Now,
                Status = VendaStatus.Aprovada,
                Cliente = c1,
                ValorVenda = 5180
            };

            HistoricoVenda h2 = new HistoricoVenda
            {
                Id = Guid.NewGuid(),
                DataVenda = DateTime.Now,
                Status = VendaStatus.Aprovada,
                Cliente = c2,
                ValorVenda = 15480
            };

            ItemVenda i1 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p1,
                Quantidade = 3,
                ValorUnitario = p1.Valor,
                HistoricoVenda = h1
            };

            ItemVenda i2 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p3,
                Quantidade = 5,
                ValorUnitario = p3.Valor,
                HistoricoVenda = h1
            };

            ItemVenda i3 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p5,
                Quantidade = 1,
                ValorUnitario = p5.Valor,
                HistoricoVenda = h1
            };

            ItemVenda i4 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p2,
                Quantidade = 1,
                ValorUnitario = p2.Valor,
                HistoricoVenda = h2
            };

            ItemVenda i5 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p4,
                Quantidade = 6,
                ValorUnitario = p4.Valor,
                HistoricoVenda = h2
            };

            ItemVenda i6 = new ItemVenda
            {
                Id = Guid.NewGuid(),
                Produto = p6,
                Quantidade = 15,
                ValorUnitario = p6.Valor,
                HistoricoVenda = h2
            };

            _context.Fornecedores.AddRange(f1, f2);
            _context.Clientes.AddRange(c1, c2);
            _context.Departamentos.AddRange(d1, d2);
            _context.Produtos.AddRange(p1, p2, p3, p4, p5, p6);
            _context.HistoricoVendas.AddRange(h1, h2);
            _context.ItemVenda.AddRange(i1,i2,i3,i4,i5,i6);


            _context.SaveChanges();
        }
    }
}
