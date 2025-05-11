using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces;

public interface IProductRepository
{
	Task<IEnumerable<Product>> GetAllAsync();
	Task<Product> GetByIdAsync(int id);
	Task CreateAsync(Product product);
	Task UpdateAsync(Product product);
	Task DeleteAsync(int id);
}