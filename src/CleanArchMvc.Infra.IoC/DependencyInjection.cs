using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
	public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("Default")
				, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
		});

		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
	}
}