using CleanArchMVC.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfig;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired(true);

        builder.HasData(
            Category.Create(1, "Material escolar"),
            Category.Create(2, "Art supplies"),
            Category.Create(3, "Office supplies"),  
            Category.Create(4, "Stationery supplies")
        );
    }
}