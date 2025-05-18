using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities;

public sealed class Category
{
    private Category(string name) => Validate(name);

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ICollection<Product>? Products { get; private set; }

    private void Validate(string? name)
    {
        //todo: implement validation using FluentValidation
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"Invalid {name}, field is required.");
        DomainExceptionValidation.When(name?.Length < 3, $"Invalid {name}, field is too short, minimum 3 characters.");
        Name = name ?? string.Empty;
    }

    public void Update(string name) => Validate(name);

    public static Category Create(int id, string name) => new(name) { Id = id };

    public static Category Create(string name) => new(name);
}