using CleanArchMvc.App.Products.Commands;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.App.Products.Handlers;

public class ProductRemoveCommandHandler(IProductRepository repository) : IRequestHandler<ProductRemoveCommand>
{
    public async Task Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
    }
}