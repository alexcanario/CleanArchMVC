using Bogus;

using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.UnitTests.Fixtures;

public class ProductFixture : IClassFixture<Product>
{
	public Faker<Product> Build(ProductEnumError error = ProductEnumError.Ok)
	{
		var product = new Faker<Product>()
			//.CustomInstantiator(f => new Product(f.IndexFaker, f.Commerce.ProductName(), f.Commerce.ProductDescription(), f.Finance.Amount(1M, 1000M, 2), f.Random.Int(1, 10), "imagem.jpeg"));
			.RuleFor(p => p.Id, f => f.IndexFaker)
			.RuleFor(p => p.Name, f => f.Commerce.ProductName())
			.RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
			.RuleFor(p => p.Price, f => f.Finance.Amount(1M, 1000M, 2))
			.RuleFor(p => p.Stock, f => f.Random.Int(1, 10))
			.RuleFor(p => p.Image, f => "Image.jpeg")
			.RuleFor(p => p.CategoryId, f => 0);

		switch (error)
		{
			case ProductEnumError.InvalidName:
				product.RuleFor(p => p.Name, f => f.Random.String2(3));
				break;																																		
			case ProductEnumError.EmptyName:
				product.RuleFor(p => p.Name, f => string.Empty);
				break;
			case ProductEnumError.InvalidDescription:
				product.RuleFor(p => p.Description, f => f.Random.String2(4));
				break;
			case ProductEnumError.EmptyDescription:
				product.RuleFor(p => p.Description, f => string.Empty);
				break;
			case ProductEnumError.InvalidPrice:
				//product.CustomInstantiator(f => new Product(f.IndexFaker, f.Commerce.ProductName(), f.Commerce.ProductDescription(), f.Finance.Amount(1M, 1000M, 2), -1, "imagem.jpeg"));
				product.RuleFor(p => p.Price, f => -1);
				break;
			case ProductEnumError.InvalidStock:
				product.RuleFor(p => p.Stock, f => -1);
				break;
			case ProductEnumError.InvalidImage:
				product.RuleFor(p => p.Image, f => null);
				break;
			case ProductEnumError.InvalidImagePath:
				product.RuleFor(p => p.Image, f => f.Random.String2(251));
				break;
			case ProductEnumError.Ok:
			default:
				product.CustomInstantiator(f => new Product(f.IndexFaker, f.Commerce.ProductName(), f.Commerce.ProductDescription(), f.Finance.Amount(1M, 1000M, 2), f.Random.Int(1, 10), "imagem.jpeg"));
				break;
		}

		return product;
	}
}