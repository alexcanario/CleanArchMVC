using AutoMapper;

using CleanArchMvc.App.Dto;
using CleanArchMvc.App.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.App.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
	public async Task<IEnumerable<CategoryDto>> GetAllAsync()
	{
		return mapper.Map<IEnumerable<CategoryDto>>(await categoryRepository.GetAllAsync());
	}

	public async Task<CategoryDto> GetCategoryByIdAsync(int id)
	{
		return mapper.Map<CategoryDto>(await categoryRepository.GetByIdAsync(id));
	}

	public async Task<CategoryDto> GetCategoryByNameAsync(string name)
	{
		return mapper.Map<CategoryDto>(await categoryRepository.GetByNameAsync(name));
	}

	public async Task CreateAsync(CategoryDto categoryDto)
	{
		await categoryRepository.CreateAsync(mapper.Map<Category>(categoryDto));
	}

	public async Task UpdateAsync(CategoryDto categoryDto)
	{
		await categoryRepository.UpdateAsync(mapper.Map<Category>(categoryDto));
	}

	public async Task DeleteAsync(int id)
	{
		await categoryRepository.DeleteAsync(id);
	}
}