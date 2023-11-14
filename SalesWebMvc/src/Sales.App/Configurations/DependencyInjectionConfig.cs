using Sales.App.Data;
using Sales.App.Services;
using Sales.Business.Interfaces;
using Sales.Business.Notificacoes;
using Sales.Business.Services;
using Sales.Data.Context;
using Sales.Data.Repository;

namespace Sales.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SalesContext>();
            services.AddScoped<SeedingService>();
            services.AddScoped<CarrinhoService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IHistoricoVendaRepository, HistoricoVendaRepository>();
            services.AddScoped<IHistoricoVendaService, HistoricoVendaService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
