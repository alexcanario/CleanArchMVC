using AutoMapper;

using CleanArchMvc.App.Dto;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mapping;

public class ProductToProductDto : Profile
{
	public ProductToProductDto()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
	}
}