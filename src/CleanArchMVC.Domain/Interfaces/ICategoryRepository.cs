using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces;

public interface ICategoryRepository
{
	Task<IEnumerable<Category?>> GetAllAsync();
	Task<Category?> GetByIdAsync(int id);
	Task<Category> CreateAsync(Category category);
	Task UpdateAsync(Category category);
	Task DeleteAsync(int id);
}