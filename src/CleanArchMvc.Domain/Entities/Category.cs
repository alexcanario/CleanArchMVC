using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{
	public string Name { get; private set; }

	public IEnumerable<Product>? Products { get; set; }

	public Category(int id, string name) : this(name)
	{
		ValidateCategory(id, name);

		Id = id;
		Name = name;
	}

	public Category(string name)
	{
		ValidateCategory(0, name);
		
		Name = name;
	}

	public void Update(string name)
	{
		ValidateCategory(this.Id, name);

		Name = name;
	}

	private void ValidateCategory(int id, string name)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required!");
		DomainExceptionValidation.When(name.Length <= 3, "Invalid name, minimum 4 characters!");
		DomainExceptionValidation.When(id < 0, "Invalid id value! Id must be greater than 0");
	}
}