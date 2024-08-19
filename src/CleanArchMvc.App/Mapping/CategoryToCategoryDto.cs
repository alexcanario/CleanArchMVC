using AutoMapper;

using CleanArchMvc.App.Dto;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mapping;

public class CategoryToCategoryDto : Profile
{
	public CategoryToCategoryDto()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
	}
}