using AutoMapper;

using CleanArchMvc.App.Dtos;
using CleanArchMvc.App.Interfaces;
using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.App.Products.Queries;

using MediatR;

namespace CleanArchMvc.App.Services;

public class ProductService(IMediator mediator, IMapper mapper) : IProductService
{
	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
        var products = await mediator.Send(new GetProductsQuery());
        return products.Any() ? mapper.Map<IEnumerable<ProductDto>>(products) : [];
    }

	public async Task<ProductDto> GetByIdAsync(int id)
	{
        return mapper.Map<ProductDto>(await mediator.Send(new GetProductByIdQuery(id)));
    }

	public async Task<ProductDto> GetProductCategoryByIdAsync(int id)
	{
        return mapper.Map<ProductDto>(await mediator.Send(new GetProductByIdWithCategoryQuery(id)));
    }

	public async Task CreateAsync(ProductDto productDto)
	{
        await mediator.Send(mapper.Map<ProductCreateCommand>(productDto));
    }

	public async Task UpdateAsync(ProductDto productDto)
	{
        await mediator.Send(mapper.Map<ProductUpdateCommand>(productDto));
    }

	public async Task Delete(int id)
	{
        await mediator.Send(new ProductUpdateCommand(id));
    }
}