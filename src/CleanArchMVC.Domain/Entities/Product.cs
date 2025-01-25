namespace CleanArchMVC.Domain.Entities;

public sealed class Product
{
    public Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Product(string name) => Name = name;

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; } = string.Empty;
    public int CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public void Update(int id, string name)
    {
        Id = id; Name = name;
    }
}