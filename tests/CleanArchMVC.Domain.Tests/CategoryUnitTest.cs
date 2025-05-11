using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;

using FluentAssertions;

namespace CleanArchMVC.Domain.Tests;

public class CategoryUnitTest
{
	[Fact]
	public void CreateCategory_WithValidNameParameter_ResultValidCategory()
	{
		Action action = () => Category.Create("Category 1");
		
		action.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateCategory_WithInvalidNameParameter_ResultInvalidCategory()
	{
		Action action = () => Category.Create(string.Empty);
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid , field is required.");
	}

	[Fact]
	public void CreateCategory_WithShortNameParameter_ResultInvalidCategory()
	{
		Action action = () => Category.Create("Ca");
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Ca, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void UpdateCategory_WithValidNameParameter_ResultValidCategory()
	{
		var category = Category.Create("Category 1");
		
		Action action = () => category.Update("Category 2");
		
		action.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void UpdateCategory_WithInvalidNameParameter_ResultInvalidCategory()
	{
		var category = Category.Create("Category 1");
		
		Action action = () => category.Update(string.Empty);
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid , field is required.");
	}

	[Fact]
	public void UpdateCategory_WithShortNameParameter_ResultInvalidCategory()
	{
		var category = Category.Create("Category 1");
		
		Action action = () => category.Update("Ca");
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Ca, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void CreateCategory_WithIdAndNameParameter_ResultValidCategory()
	{
		Action action = () => Category.Create(1, "Category 1");
		
		action.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateCategory_WithIdAndInvalidNameParameter_ResultInvalidCategory()
	{
		Action action = () => Category.Create(1, string.Empty);
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid , field is required.");
	}

	[Fact]
	public void CreateCategory_WithIdAndShortNameParameter_ResultInvalidCategory()
	{
		Action action = () => Category.Create(1, "Ca");
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Ca, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void CreateCategory_WithIdParameter_ResultValidCategory()
	{
		Action action = () => Category.Create(1, "Category 1");
		
		action.Should().NotThrow<DomainExceptionValidation>();
	}

	[Fact]
	public void CreateCategory_WithIdParameter_ResultInvalidCategory()
	{
		Action action = () => Category.Create(1, string.Empty);
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid , field is required.");
	}

	[Fact]
	public void CreateCategory_WithIdParameter_ResultShortNameCategory()
	{
		Action action = () => Category.Create(1, "Ca");
		
		action.Should().Throw<DomainExceptionValidation>()
			.WithMessage("Invalid Ca, field is too short, minimum 3 characters.");
	}

	[Fact]
	public void CreateCategory_WithIdParameter_ResultValidCategoryWithId()
	{
		var category = Category.Create(1, "Category 1");
		
		category.Id.Should().Be(1);
		category.Name.Should().Be("Category 1");
	}

	[Fact]
	public void CreateCategory_WithIdParameter_ResultValidCategoryWithName()
	{
		var category = Category.Create(1, "Category 1");
		
		category.Id.Should().Be(1);
		category.Name.Should().Be("Category 1");
	}
}