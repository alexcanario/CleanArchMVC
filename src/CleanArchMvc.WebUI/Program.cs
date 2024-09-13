using CleanArchMvc.Domain.Accounts;
using CleanArchMvc.Infra.IoC;
using CleanArchMvc.WebUI.Config;

namespace CleanArchMvc.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfra(builder.Configuration);

        builder.Services.AddAppServices();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        app.ConfigureRoles();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}