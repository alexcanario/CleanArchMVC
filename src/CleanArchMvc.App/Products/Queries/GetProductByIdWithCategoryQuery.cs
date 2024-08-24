using CleanArchMvc.Domain.Entities;

using MediatR;

namespace CleanArchMvc.App.Products.Queries;

public class GetProductByIdWithCategoryQuery(int id) : IRequest<Product>
{
    public int Id { get; set; } = id;
}