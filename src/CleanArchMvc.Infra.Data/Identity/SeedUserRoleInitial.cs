using CleanArchMvc.Domain.Accounts;

using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager) : ISeedUserRoleInitial
{
    public void SeedUsers()
    {
        SeedOwn();
        SeedAdmin();
    }

    public void SeedRoles()
    {
       SeedRole("Admin");
       SeedRole("User");
    }

    private void SeedAdmin()
    {
        const string email = "sysuser@gmail.com";
        const string password = "Ca151867";

        if (userManager.FindByEmailAsync(email: email).Result != null) return;
        Account account = new()
        {
            UserName = email,
            Email = email,
            NormalizedUserName = email.ToUpper(),
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = userManager.CreateAsync(account, password).Result;
        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(account, "Admin").Wait();
        }
    }

    private void SeedOwn()
    {
        const string email = "alexcanario@gmail.com";
        const string password = "Ca151867";

        if (userManager.FindByEmailAsync(email: email).Result != null) return;
        Account account = new()
        {
            UserName = "Alex Canario",
            Email = email,
            NormalizedUserName = "ALEX CANARIO",
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = userManager.CreateAsync(account, password).Result;
        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(account, "User").Wait();
        }
    }
    
    private void SeedRole(string roleName)
    {
        if (roleManager.FindByNameAsync(roleName).Result == null) return;

        var role = new IdentityRole()
        {
            Name = roleName,
            NormalizedName = roleName.ToUpper(),
        };

        var roleResult = roleManager.CreateAsync(role).Result;
    }
}