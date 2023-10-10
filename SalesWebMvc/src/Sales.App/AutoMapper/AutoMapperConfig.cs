﻿using Sales.Business.Models;
using AutoMapper;
using Sales.App.ViewModels;

namespace Sales.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            //CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}