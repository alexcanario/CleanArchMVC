using CleanArchMvc.App.Dtos;

namespace CleanArchMvc.App.Interfaces;

public interface ICategoryService
{
	Task<IEnumerable<CategoryDto>> GetAllAsync();
	Task<CategoryDto> GetCategoryByIdAsync(int id);
	Task<CategoryDto> GetCategoryByNameAsync(string name);
	Task CreateAsync(CategoryDto categoryDto);
	Task UpdateAsync(CategoryDto categoryDto);
	Task DeleteAsync(int id);
}