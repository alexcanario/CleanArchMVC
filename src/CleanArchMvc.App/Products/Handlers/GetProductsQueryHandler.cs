using CleanArchMvc.App.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.App.Products.Handlers;

public class GetProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
    }
}