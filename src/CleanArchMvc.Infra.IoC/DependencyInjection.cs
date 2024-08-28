using CleanArchMvc.App.Interfaces;
using CleanArchMvc.App.Services;
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
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArchMvc.App")));
        services.AddRepositories();
    }

    public static void AddAppServices(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("CleanArchMvc.App");
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(assembly);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}