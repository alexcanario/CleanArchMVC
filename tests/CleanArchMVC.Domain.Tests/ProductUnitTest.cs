using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;

using FluentAssertions;

namespace CleanArchMVC.Domain.Tests;

public class ProductUnitTest
{
	[Fact]
	public void CreateProduct_WithValidName_ShouldNotThrow()
	{
		Action act = () => Product.Create("Product 1");
		act.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateProduct_WithEmptyName_ShouldThrowRequired()
	{
		Action act = () => Product.Create(string.Empty);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name field is required.");
	}

	[Fact]
	public void CreateProduct_WithShortName_ShouldThrowTooShort()
	{
		Action act = () => Product.Create("Pr");
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void CreateProduct_WithValidIdAndName_ShouldNotThrow()
	{
		Action act = () => Product.Create(1, "Product 1");
		act.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateProduct_WithInvalidId_ShouldThrow()
	{
		Action act = () => Product.Create(0, "Product 1");
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid id");
	}

	[Fact]
	public void CreateProduct_WithInvalidName_ShouldThrow()
	{
		Action act = () => Product.Create(1, "");
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name field is required.");
	}

	[Fact]
	public void CreateProduct_WithAllValidParameters_ShouldNotThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, 5, 2);
		act.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateProduct_WithInvalidIdInAllParams_ShouldThrow()
	{
		Action act = () => Product.Create(0, "Product 1", "A valid description", "image.png", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid id");
	}

	[Fact]
	public void CreateProduct_WithEmptyNameInAllParams_ShouldThrow()
	{
		Action act = () => Product.Create(1, "", "A valid description", "image.png", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name field is required.");
	}

	[Fact]
	public void CreateProduct_WithShortNameInAllParams_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Pr", "A valid description", "image.png", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void CreateProduct_WithEmptyDescription_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "", "image.png", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Description field is required.");
	}

	[Fact]
	public void CreateProduct_WithShortDescription_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "desc", "image.png", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Description field is too short, minimum 5 characters.");
	}

	[Fact]
	public void CreateProduct_WithEmptyImage_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", "", 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid image");
	}

	[Fact]
	public void CreateProduct_WithNullEmptyImage_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", null, 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid image");
	}

	[Fact]
	public void CreateProduct_WithLargeImagePath_ShouldThrow()
	{
		var largeImagePath = new string('A', 251); // Assuming the maximum length is 250 characters
		Action act = () => Product.Create(1, "Product 1", "A valid description", largeImagePath, 10.5m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid image");
	}

	[Fact]
	public void CreateProduct_WithZeroPrice_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", "image.png", 0m, 5, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Price field is required.");
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(-2)]
	public void CreateProduct_WithNegativeStock_ShouldThrow(int value)
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, value, 2);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Stock field is required.");
	}

	[Fact]
	public void CreateProduct_WithInvalidCategoryId_ShouldThrow()
	{
		Action act = () => Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, 5, 0);
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Category field is required.");
	}

	[Fact]
	public void UpdateProduct_WithValidName_ShouldUpdate()
	{
		var product = Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, 5, 2);
		product.Update("Product 2");
		product.Name.Should().Be("Product 2");
	}

	[Fact]
	public void UpdateProduct_WithEmptyName_ShouldThrow()
	{
		var product = Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, 5, 2);
		Action act = () => product.Update("");
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name field is required.");
	}

	[Fact]
	public void UpdateProduct_WithShortName_ShouldThrow()
	{
		var product = Product.Create(1, "Product 1", "A valid description", "image.png", 10.5m, 5, 2);
		Action act = () => product.Update("Pr");
		act.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Name, field is too short, minimum 3 characters.");
	}
}