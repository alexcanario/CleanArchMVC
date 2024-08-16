using CleanArchMvc.App.Dto;

namespace CleanArchMvc.App.Interfaces;

public interface IProductService
{
	Task<IEnumerable<ProductDto>> GetAllAsync();
	Task<ProductDto> GetByIdAsync(int id);
	Task<ProductDto> GetProductCategoryByIdAsync(int id);
	Task Create(ProductDto productDto);
	Task Update(ProductDto productDto);
	Task Delete(int id);
}