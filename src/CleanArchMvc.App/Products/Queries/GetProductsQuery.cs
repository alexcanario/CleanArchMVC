using CleanArchMvc.Domain.Entities;

using MediatR;

namespace CleanArchMvc.App.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>> { }