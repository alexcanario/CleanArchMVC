using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class CategoryToCategoryDto : Profile
{
	public CategoryToCategoryDto()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
	}
}