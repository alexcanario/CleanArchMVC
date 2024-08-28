using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        ProductToProductDto();
        CreateMapProductDtoToProductCreateCommand();
        ProductCreateCommandToProduct();
    }

    private void CreateMapProductDtoToProductCreateCommand()
    {
        CreateMap<ProductDto, ProductCreateCommand>();
        //.ForMember(p => p.Name, f => f.MapFrom(c => c.Name))
        //.ForMember(p => p.Description, f => f.MapFrom(c => c.Description))
        //.ForMember(p => p.Image, f => f.MapFrom(c => c.Image))
        //.ForMember(p => p.Price, f => f.MapFrom(c => c.Price))
        //.ForMember(p => p.Stock, f => f.MapFrom(c => c.Stock))
        //.ForMember(p => p.CategoryId, f => f.MapFrom(c => c.CategoryId));
    }

    private void ProductToProductDto()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }

    private void ProductCreateCommandToProduct()
    {
        CreateMap<ProductCreateCommand, Product>();
    }
}