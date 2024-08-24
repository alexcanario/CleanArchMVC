using AutoMapper;

using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class ProductToProductCommand : Profile
{
    public ProductToProductCommand()
    {
        CreateMap<Product, ProductCommand>()
            .ReverseMap();
    }
}