using CleanArchMvc.Domain.Accounts;

namespace CleanArchMvc.WebUI.Config;

public static class ExtensionMethods
{
    public static void ConfigureRoles(this IApplicationBuilder app)
    {
        var seedUserRoleInitial = GetISeedUserRoleInitial(app);

        if (seedUserRoleInitial == null) return;
        
        seedUserRoleInitial.SeedRoles();
        seedUserRoleInitial.SeedUsers();
    }

    private static ISeedUserRoleInitial? GetISeedUserRoleInitial(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        
        return serviceScope.ServiceProvider.GetService<ISeedUserRoleInitial>();
    }
}