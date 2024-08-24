using MediatR;

namespace CleanArchMvc.App.Products.Commands;

public class ProductRemoveCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}