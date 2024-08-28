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