using AutoMapper;

using CleanArchMvc.App.Dto;

namespace CleanArchMvc.App.Mapping;

public class CategoryToCategoryDto : Profile
{
	public CategoryToCategoryDto()
	{
		CreateMap<CategoryDto, CategoryDto>().ReverseMap();
	}
}