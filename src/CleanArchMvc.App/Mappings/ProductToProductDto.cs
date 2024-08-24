using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class ProductToProductDto : Profile
{
	public ProductToProductDto()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
	}
}