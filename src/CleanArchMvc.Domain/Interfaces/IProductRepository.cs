using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
	Task<Product> GetProductWithCategoryByIdAsync(int id);
}