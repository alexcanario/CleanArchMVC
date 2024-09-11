using CleanArchMvc.App.Interfaces;
using CleanArchMvc.App.Services;
using CleanArchMvc.Domain.Accounts;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;

using Microsoft.AspNetCore.Identity;
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

        services.AddSecurity();

        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArchMvc.App")));
        services.AddRepositories();
    }

    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddAutoMapper(AppDomain.CurrentDomain.Load("CleanArchMvc.App"));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddSecurity(this IServiceCollection services)
    {
        services.AddIdentity<Account, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");
    }
}