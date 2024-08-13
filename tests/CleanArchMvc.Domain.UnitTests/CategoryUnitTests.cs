using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.UnitTests;

public class CategoryUnitTests
{
	[Fact(DisplayName = "GIVEN a valid category WHEN create THEN does not throw exception")]
	[Trait("Category", "Create")]
	public void CreateCategory_WithValidParameters_ResultObjectValidState()
	{
		//Arrange & Action
		var exception = Record.Exception(() => new Category(1, "Category 1"));

		//Assert
		Assert.Null(exception);
	}

	[Fact(DisplayName = "GIVEN a invalid category with empty name WHEN create THEN throw exception")]
	[Trait("Category", "Create")]
	public void CreateCategory_WithEmptyName_ThrowException()
	{
		//Arrange, Action, Assert

		var exception = Assert.Throws<DomainExceptionValidation>(() => new Category(1, string.Empty));
		Assert.Equal("Invalid name, Name is required!", exception.Message);
	}

	[Fact(DisplayName = "GIVEN a invalid category with short name WHEN create THEN throw exception")]
	[Trait("Category", "Create")]
	public void CreateCategory_WithShortName_ThrowException()
	{
		//Arrange, Action
		var exception = Assert.Throws<DomainExceptionValidation>(() => new Category(1, "abc"));

		//Assert
		Assert.Equal("Invalid name, minimum 4 characters!", exception.Message);
	}

	[Fact(DisplayName = "GIVEN a invalid category with id lower then 0 WHEN create THEN throw exception")]
	[Trait("Category", "Create")]
	public void CreateCategory_WithLowerId_ThrowException()
	{
		//Arrange, Action
		var exception = Assert.Throws<DomainExceptionValidation>(() => new Category(-1, "Category 1"));

		//Assert
		Assert.Equal("Invalid id value! Id must be greater than 0", exception.Message);
	}

	[Fact(DisplayName = "GIVEN valid category WHEN update THEN does not throw exception'")]
	[Trait("Category", "Update")]
	public void UpdateCategory_WithValidParameters_DoesNotThrowException()
	{
		//Arrange
		var category = new Category(1, "Category 1");
		
		//Action
		var exception = Record.Exception(() => category.Update("Category 1 updated"));
		
		//Assert
		Assert.Null(exception);
	}
}