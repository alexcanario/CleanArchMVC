using AutoMapper;

using CleanArchMvc.App.Dto;
using CleanArchMvc.App.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.App.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
		return mapper.Map<IEnumerable<ProductDto>>(await productRepository.GetAllAsync()) ?? [];
	}

	public async Task<ProductDto> GetByIdAsync(int id)
	{
		return mapper.Map<ProductDto>(await productRepository.GetByIdAsync(id));
	}

	public async Task<ProductDto> GetProductCategoryByIdAsync(int id)
	{
		return mapper.Map<ProductDto>(await productRepository.GetProductWithCategoryByIdAsync(id));
	}

	public async Task Create(ProductDto productDto)
	{
		await productRepository.CreateAsync(mapper.Map<Product>(productDto));
	}

	public async Task Update(ProductDto categoryDto)
	{
		await productRepository.UpdateAsync(mapper.Map<Product>(categoryDto));
	}

	public async Task Delete(int id)
	{
		await productRepository.DeleteAsync(id);
	}
}