using CleanArchMvc.App.Dtos;

namespace CleanArchMvc.App.Interfaces;

public interface IProductService
{
	Task<IEnumerable<ProductDto>> GetAllAsync();
	Task<ProductDto> GetByIdAsync(int id);
	Task<ProductDto> GetProductCategoryByIdAsync(int id);
	Task CreateAsync(ProductDto productDto);
	Task UpdateAsync(ProductDto productDto);
	Task DeleteAsync(int id);
}