using CleanArchMvc.App.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.App.Products.Handlers;

public class GetProductByIdWithCategoryQueryHandler(IProductRepository repository) : IRequestHandler<GetProductByIdWithCategoryQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdWithCategoryQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetProductWithCategoryByIdAsync(request.Id);
    }
}