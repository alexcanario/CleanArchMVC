using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Extensions;
using CleanArchMvc.Infra.Data.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Account>(options)
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		modelBuilder.Sow();
	}
}