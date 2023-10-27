using Sales.Business.Models;
using AutoMapper;
using Sales.App.ViewModels;

namespace Sales.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            CreateMap<Vendedor, VendedorViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<HistoricoVenda, VendaViewModel>().ReverseMap();
            CreateMap<ItemVenda, ItemVendaViewModel>().ReverseMap();
        }
    }
}
