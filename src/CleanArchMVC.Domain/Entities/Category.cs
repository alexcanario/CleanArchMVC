using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities;

public sealed class Category
{
    public Category(string name) => Validate(name);

    public Category(int id, string? name)
    {
        Id = id;
        Validate(name);
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Product>? Products { get; private set; }

    private void Validate(string? name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"Invalid {name}, field is required.");
        DomainExceptionValidation.When(name?.Length < 3, $"Invalid {name}, field is too short, minimum 3 characters.");
        Name = name;
    }
}