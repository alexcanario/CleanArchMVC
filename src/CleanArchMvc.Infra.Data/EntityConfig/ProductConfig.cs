using CleanArchMvc.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntityConfig;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Products");
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
		builder.Property(p => p.Description).HasMaxLength(150).IsRequired(true);
		builder.Property(p => p.Image).HasMaxLength(255);
		builder.Property(p => p.Price).HasPrecision(10, 2);

		builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}