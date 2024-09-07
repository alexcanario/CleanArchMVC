using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        MapProductToProductDto();
        MapProductDtoToProductCreateCommand();
        MapProductCreateCommandToProduct();
        MapProductUpdateCommandToProduct();
        MapProductDtoToProductUpdateCommand();
    }

    private void MapProductDtoToProductCreateCommand()
    {
        CreateMap<ProductDto, ProductCreateCommand>().ReverseMap();
    }

    private void MapProductCreateCommandToProduct()
    {
        CreateMap<ProductCreateCommand, Product>().ReverseMap();
    }

    private void MapProductDtoToProductUpdateCommand()
    {
        CreateMap<ProductDto, ProductUpdateCommand>().ReverseMap();
    }

    private void MapProductUpdateCommandToProduct()
    {
        CreateMap<ProductUpdateCommand, Product>().ReverseMap();
    }

    private void MapProductToProductDto()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}