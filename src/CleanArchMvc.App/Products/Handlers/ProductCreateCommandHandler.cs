using AutoMapper;

using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.App.Products.Handlers;

public class ProductCreateCommandHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<ProductCreateCommand>
{
    public async Task Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(mapper.Map<Product>(request));
    }
}