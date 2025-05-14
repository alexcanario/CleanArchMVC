using CleanArchMVC.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfig;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
        builder.Property(p => p.Description).HasMaxLength(100).IsRequired(false);
        builder.Property(p => p.Image).HasMaxLength(250).IsRequired(false);
        builder.Property(p => p.Price).HasColumnType("money").IsRequired(true);
        builder.HasOne(e => e.Category).WithMany(c => c.Products).HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            Product.Create(1, "Caderno", "Caderno brochura 10x1", "caderno.jpg", 7.99m, 100, 1),
            Product.Create(2, "Caneta", "Caneta esferográfica azul", "caneta.jpg", 2.50m, 200, 1),
            Product.Create(3, "Lápis", "Lápis grafite HB", "lapis.jpg", 1.50m, 300, 1),
            Product.Create(4, "Papel A4", "Papel sulfite A4", "papel.jpg", 20.00m, 50, 1)
        );

        builder.HasData(
            Product.Create(5, "Pincel", "Pincel redondo 0", "pincel.jpg", 5.00m, 150, 2),
            Product.Create(6, "Tinta Acrílica", "Tinta acrílica azul", "tinta.jpg", 15.00m, 80, 2),
            Product.Create(7, "Cola Branca", "Cola branca escolar", "cola.jpg", 3.50m, 120, 2),
            Product.Create(8, "Canetinha", "Canetinha hidrocor", "canetinha.jpg", 10.00m, 60, 2)
        );
    }
}