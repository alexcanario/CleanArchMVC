using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public decimal Price { get; private set; }
	public int Stock { get; private set; }
	public string Image { get; private set; } = string.Empty;

	public int CategoryId { get; set; }
	public Category? Category { get; set; }

	public Product(string name, string description, decimal price, int stock, string image) : this(0, name, description, price, stock, image) {}

	public Product(int id, string name, string description, decimal price, int stock, string image)
	{
		ValidateAndSetProduct(id, name, description, price, stock, image, -1);
	}

	public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
	{
		ValidateAndSetProduct(this.Id, name, description, price, stock, image, categoryId);

		CategoryId = categoryId;
	}

	private void ValidateAndSetProduct(int id, string name, string description, decimal price, int stock, string image, int categoryId)
	{
		DomainExceptionValidation.When(id < 0, "Invalid id, Id must be greater 0");
		Id = id == 0 ? 0 : id;

		ValidateAndSetProduct(name, description, price, stock, image, categoryId);
	}

	private void ValidateAndSetProduct(string name, string description, decimal price, int stock, string? image, int categoryId)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required!");
		DomainExceptionValidation.When(name.Length < 4, "Invalid name, minimum name, 3 characters!");

		DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required!");
		DomainExceptionValidation.When(description.Length < 5, "Invalid description, minimum description, 5 characters!");

		DomainExceptionValidation.When(price < 0, "Invalid price value");
		DomainExceptionValidation.When(stock < 0, "Invalid stock value");

		DomainExceptionValidation.When(image == null, "Invalid image!");
		DomainExceptionValidation.When(image?.Length > 250, "Invalid image path, maximum 250 characters!");

		Name = name;
		Description = description;
		Price = price;
		Stock = stock;
		Image = image;
		CategoryId = categoryId;
	}
}