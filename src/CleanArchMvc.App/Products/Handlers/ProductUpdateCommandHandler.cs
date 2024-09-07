using AutoMapper;

using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.App.Products.Handlers;

public class ProductUpdateCommandHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<ProductUpdateCommand>
{
    public async Task Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(mapper.Map<Product>(request));
    }
}