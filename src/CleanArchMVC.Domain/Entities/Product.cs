using System.Runtime.CompilerServices;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities;

//todo: implement Entity<TKey>
public sealed class Product
{
    private Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private Product(int id, string name, string description, string image, decimal price, int stock, int categoryId)
    {
		ValidateDomain(id, name, description, image, price, stock, categoryId);
	    
		Id = id;
		Name = name;
		Description = description;
		Image = image;
		Price = price;
	    Stock = stock;
	    CategoryId = categoryId;
    }

    private Product(string name)
    {
		ValidateDomain(name);
	    Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; } = string.Empty;
    public int CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public void Update(string name)
    {
		ValidateDomain(name);
        Name = name;
    }

	public static Product Create(string name) => new(name);
	public static Product Create(int id, string name)
	{
		ValidateDomain(id);
		ValidateDomain(name);
		return new Product(id, name);
	}

	public static Product Create(int id, string name, string description, string image, decimal price, int stock,
		int categoryId) => new(id, name, description, image, price, stock, categoryId);

	private static void ValidateDomain(string name)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"Invalid {nameof(Name)} field is required.");
		DomainExceptionValidation.When(name.Length is > 0 and < 3, $"Invalid {nameof(Name)}, field is too short, minimum 3 characters.");
	}

	private static void ValidateDomain(int id)
	{
		DomainExceptionValidation.When(id < 1, "Invalid Id");
	}

	private static void ValidateDomain(string description, string image, decimal price, int stock, int categoryId)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(description), $"Invalid {description}, field is required.");
		DomainExceptionValidation.When(description.Length < 5, $"Invalid {description}, field is too short, minimum 5 characters.");
		DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image");
		DomainExceptionValidation.When(price <= 0, $"Invalid {price}, field is required.");
		DomainExceptionValidation.When(stock < 0, $"Invalid {stock}, field is required.");
		DomainExceptionValidation.When(categoryId <= 0, $"Invalid {categoryId}, field is required.");
	}
	
	private static void ValidateDomain(int id, string name, string description, string image, decimal price, int stock,
		int categoryId)
	{
		ValidateDomain(id);
		ValidateDomain(name);
		ValidateDomain(description, image, price, stock, categoryId);
	}
}