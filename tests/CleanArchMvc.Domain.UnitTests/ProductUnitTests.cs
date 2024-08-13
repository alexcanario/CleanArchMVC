using System.Diagnostics;
using System.Text;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.UnitTests.Fixtures;
using CleanArchMvc.Domain.Validation;

using FluentAssertions;

public class ProductUnitTests(ProductFixture productFixture) : IClassFixture<ProductFixture>
{
	[Fact]
	[Trait("Product","Create")]
	public void CreateProduct_WithValidParameters_ShouldCreateProduct()
	{
		// Arrange, Act
		var product = productFixture.Build().Generate();

		// Assert (Verificação)
		product.Id.Should().Be(0); 
		product.Name.Should().NotBeEmpty();
		product.Description.Should().NotBeEmpty();
		product.Price.Should().BeGreaterThan(0);
		product.Stock.Should().BeGreaterThan(0);
		product.Image.Should().NotBeEmpty();
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithInvalidName_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = ""; // Nome vazio
		var description = "Descrição do produto";
		var price = 10.50m;
		var stock = 15;
		var image = "imagem.jpg";

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image);

		// Act (Ação)
		act.Invoking(x => x()).Should().Throw<DomainExceptionValidation>()
				.WithMessage("Invalid name, name is required!");
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithShortName_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "ABC"; // Nome curto
		var description = "Descrição do produto";
		var price = 10.50m;
		var stock = 15;
		var image = "imagem.jpg";

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image);

		// Act (Ação)
		act.Invoking(x => x()).Should().Throw<DomainExceptionValidation>()
				.WithMessage("Invalid name, minimum name, 3 characters!");
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithInvalidDescription_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "Produto Teste";
		var description = ""; // Descrição vazia
		var price = 10.50m;
		var stock = 15;
		var image = "imagem.jpg";

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image);

		// Act (Ação)
		act.Invoking(x => x()).Should().Throw<DomainExceptionValidation>()
				.WithMessage("Invalid description, description is required!");
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithShortDescription_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "Produto Teste";
		var description = "Desc"; // Descrição curta
		var price = 10.50m;
		var stock = 15;
		var image = "imagem.jpg";

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image);

		// Act (Ação)
		act.Invoking(x => x()).Should().Throw<DomainExceptionValidation>()
				.WithMessage("Invalid description, minimum description, 5 characters!");
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithNegativePrice_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "Produto Teste";
		var description = "Descricao"; // Descrição curta
		var price = -1M;
		var stock = 15;
		var image = "imagem.jpg";

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image);

		//Assert
		act.Should().Throw<DomainExceptionValidation>();
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithNullImage_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "Produto Teste";
		var description = "Descricao"; // Descrição curta
		var price = 1M;
		var stock = 15;

		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, null);

		//Assert
		act.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image!");
	}

	[Fact]
	[Trait("Product", "Create")]
	public void CreateProduct_WithInvalidImagePath_ShouldThrowException()
	{
		// Arrange (Preparação)
		var name = "Produto Teste";
		var description = "Descrição"; // Descrição curta
		var price = 1M;
		var stock = 15;
		var image = new StringBuilder(253);
		for (int i = 0; i < 252; i++)
		{
			image.Append('A');
		}
		// Assert (Verificação)
		Action act = () => new Product(name, description, price, stock, image.ToString());

		//Assert
		act.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image path, maximum 250 characters!");
	}
}