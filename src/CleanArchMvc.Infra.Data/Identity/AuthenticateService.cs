using CleanArchMvc.Domain.Accounts;

using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class AuthenticateService(UserManager<Account> userManager, SignInManager<Account> signInManager) : IAuthenticate
{
    public async Task<bool> Login(string email, string password)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<bool> Register(string email, string password)
    {
        var account = new Account() { UserName = email, Email = email };
        var result = await userManager.CreateAsync(account);

        if (!result.Succeeded) return false;
        
        await signInManager.SignInAsync(account, isPersistent: false);
        
        return true;
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }
}