using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.App.Mappings;

public class CategoryMappings : Profile
{
	public CategoryMappings()
	{
		CategoryToCategoryDto();
	}

    private void CategoryToCategoryDto()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}